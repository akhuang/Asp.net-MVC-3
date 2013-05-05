﻿namespace Zing.Framework.Localize
{
    using System.Globalization;
    using System.Resources;
    using System;

    internal class EmbeddedResource : ResourceBase
    {
        private readonly string resourceName;
        private readonly CultureInfo culture;

        public EmbeddedResource(string resourceName, CultureInfo culture)
        {
            this.resourceName = resourceName;
            this.culture = culture;
        }

        protected override void Load()
        {
            ResourceManager rm;
            Type compiledResource = Type.GetType("Resources." + resourceName + ", App_GlobalResources");
            if (compiledResource != null)
            {
                rm = new ResourceManager(compiledResource);
            }
            else
            {
                rm = new ResourceManager("Zing.Framework.Resources." + resourceName, GetType().Assembly);
                IsDefault = true;
            }

            using (ResourceSet set = rm.GetResourceSet(culture ?? CultureInfo.CurrentCulture, true, true))
            {
                var iterator = set.GetEnumerator();

                while (iterator.MoveNext())
                {
                    CurrentResources.Add(iterator.Key.ToString(), iterator.Value.ToString());
                }
            }
        }
    }

}
