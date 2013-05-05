﻿// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Collections.Generic;
    using Zing.Framework.Mvc;
    using Zing.Framework.Utility.Extensions;
    using Zing.Framework.UI.Html;

    public class GridEditActionCommand : GridActionCommandBase
    {
        public string UpdateText { get; set; }

        public string CancelText { get; set; }

        public string InsertText { get; set; }

        public override string Name
        {
            get { return "edit"; }
        }

        public override IEnumerable<IGridButtonBuilder> CreateDisplayButtons(IGridLocalization localization, IGridUrlBuilder urlBuilder, IGridHtmlHelper htmlHelper)
        {
            var editButton = CreateButton<GridLinkButtonBuilder>(Text ?? localization.Edit, UIPrimitives.Grid.Edit);

            editButton.Url = urlBuilder.EditUrl;

            editButton.SpriteCssClass = "t-edit";

            return new[]
            {
                editButton
            };
        }

        public override IDictionary<string, object> Serialize(IGridUrlBuilder urlBuilder)
        {
            var result = base.Serialize(urlBuilder);

            FluentDictionary.For(result)
                .Add("cancelText", CancelText, CancelText.HasValue)
                .Add("updateText", UpdateText, UpdateText.HasValue)
                .Add("insertText", InsertText, InsertText.HasValue);

            return result;
        }

        public override IEnumerable<IGridButtonBuilder> CreateEditButtons(IGridLocalization localization, IGridUrlBuilder urlBuilder, IGridHtmlHelper htmlHelper)
        {
            var cancelButton = CreateButton<GridLinkButtonBuilder>(CancelText ?? localization.Cancel, UIPrimitives.Grid.Cancel);

            cancelButton.Url = urlBuilder.CancelUrl;
            
            cancelButton.SpriteCssClass = "t-cancel";

            var updateButton = CreateButton<GridButtonBuilder>(UpdateText ?? localization.Update, UIPrimitives.Grid.Update);
            updateButton.ShouldAppendDataKeys = true;
            updateButton.SpriteCssClass = "t-update";
            updateButton.HtmlHelper = htmlHelper;

            return new IGridButtonBuilder[]
            {
                updateButton,
                cancelButton
            };
        }

        public override IEnumerable<IGridButtonBuilder> CreateInsertButtons(IGridLocalization localization, IGridUrlBuilder urlBuilder, IGridHtmlHelper htmlHelper)
        {
            var cancelButton = CreateButton<GridLinkButtonBuilder>(CancelText ?? localization.Cancel, UIPrimitives.Grid.Cancel);

            cancelButton.Url = urlBuilder.CancelUrl;

            cancelButton.SpriteCssClass = "t-cancel";

            var insertButton = CreateButton<GridButtonBuilder>(InsertText ?? localization.Insert, UIPrimitives.Grid.Insert);
            insertButton.SpriteCssClass = "t-insert";
            insertButton.HtmlHelper = htmlHelper;

            return new IGridButtonBuilder[]
            {
                insertButton,
                cancelButton
            };
        }
    }
}
