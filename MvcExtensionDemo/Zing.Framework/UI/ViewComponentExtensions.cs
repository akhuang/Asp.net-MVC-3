namespace Zing.Framework.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using Zing.Framework.Utility.Extensions;

    internal static class ViewComponentExtensions
    {
        public static string SanitizeId(this IViewComponent instance, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "";
            }

            StringBuilder builder = new StringBuilder(id.Length);
            int startSharpIndex = id.IndexOf("<#");
            int endSharpIndex = id.LastIndexOf("#>");

            if (endSharpIndex > startSharpIndex)
            {
                ReplaceInvalidCharacters(id.Substring(0, startSharpIndex), builder);
                builder.Append(id.Substring(startSharpIndex, endSharpIndex - startSharpIndex + 1));
                ReplaceInvalidCharacters(id.Substring(endSharpIndex + 1), builder);
            }
            else
            {
                ReplaceInvalidCharacters(id, builder);
            }

            return builder.ToString();
        }

        private static void ReplaceInvalidCharacters(string part, StringBuilder builder)
        {
            for (int i = 0; i < part.Length; i++)
            {
                char character = part[i];
                if (IsValidCharacter(character))
                {
                    builder.Append(character);
                }
                else
                {
                    builder.Append(HtmlHelper.IdAttributeDotReplacement);
                }
            }
        }

        private static bool IsValidCharacter(char c)
        {
            if (c == '?' || c == '!' || c == '#' || c == '.')
            {
                return false;
            }

            return true;
        }

        public static string GetValue<T>(this IViewComponent instance, T value)
        {
            return instance.GetValue<T>(instance.Name, value);
        }

        public static string GetValue<T>(this IViewComponent instance, string name, T value)
        {
            ModelState state;
            string formattedValue = string.Empty;
            ViewDataDictionary viewData = instance.ViewContext.ViewData;

            object valueFromViewData = name.HasValue() ? viewData.Eval(name) : null;

            if (name.HasValue() && viewData.ModelState.TryGetValue(name, out state) && (state.Value != null))
            {
                formattedValue = state.Value.AttemptedValue;
                if (viewData.ModelState.IsValidField(name))
                {
                    formattedValue = "{0}".FormatWith(state.Value.ConvertTo(typeof(T), state.Value.Culture));
                }
            }
            else if (value != null)
            {
                formattedValue = "{0}".FormatWith(value);
            }
            else if (valueFromViewData != null && valueFromViewData.GetType().IsPredefinedType())
            {
                formattedValue = "{0}".FormatWith(valueFromViewData);
            }

            return formattedValue;
        }

        public static string GetValueFromViewDataByName(this IViewComponent instance)
        {
            string result = instance.ViewContext.Controller.ValueOf<string>(instance.Name);
            if (result.HasValue())
            {
                return result;
            }

            object value = instance.ViewContext.ViewData.Eval(instance.Name);
            return value != null && value.GetType().IsPredefinedType() ? Convert.ToString(value) : string.Empty;
        }

        public static bool IsValid(this IViewComponent instance)
        {
            if (instance.ViewContext != null)
            {
                return instance.ViewContext.ViewData.ModelState.IsValidField(instance.Name ?? string.Empty);
            }
            return true;
        }

        public static IDictionary<string, object> GetUnobtrusiveValidationAttributes(this IViewComponent instance)
        {

            var viewContext = instance.ViewContext;

            if (viewContext.UnobtrusiveJavaScriptEnabled)
            {
                var name = instance.Name;
                var viewData = viewContext.ViewData;
                var htmlPrefix = viewData.TemplateInfo.HtmlFieldPrefix;

                if (name.HasValue() && htmlPrefix.HasValue() && name != htmlPrefix && name.StartsWith(htmlPrefix, StringComparison.Ordinal))
                {
                    name = name.Substring(htmlPrefix.Length + 1);
                }

                var metadata = ModelMetadata.FromStringExpression(name, viewData);
                var htmlHelper = new HtmlHelper(viewContext, new ViewComponentViewDataContainer { ViewData = viewData });

                if (metadata.ContainerType == null)
                {
                    metadata = viewContext.ViewData.ModelMetadata;
                }

                return htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata);
            }

            return null;
        }
    }

    internal class ViewComponentViewDataContainer : IViewDataContainer
    {
        public ViewDataDictionary ViewData
        {
            get;
            set;
        }
    }
}
