namespace Zing.Framework.Mvc
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Zing.Framework.Utility;
    using System;

    /// <summary>
    /// Defines a class to store all the metadata of the models.
    /// </summary>
    public class ModelMetadataRegistry : IModelMetadataRegistry
    {
        private readonly IDictionary<Type, IDictionary<string, ModelMetadataItemBase>> configurations = new Dictionary<Type, IDictionary<string, ModelMetadataItemBase>>();

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        /// <value>The configurations.</value>
        protected virtual IDictionary<Type, IDictionary<string, ModelMetadataItemBase>> Configurations
        {
            [DebuggerStepThrough]
            get
            {
                return configurations;
            }
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="metadataDictionary">The metadata dictionary.</param>
        public virtual void Register(Type modelType, IDictionary<string, ModelMetadataItemBase> metadataDictionary)
        {
            Guard.IsNotNull(modelType, "modelType");
            Guard.IsNotNull(metadataDictionary, "metadataDictionary");

            Configurations.Add(modelType, metadataDictionary);
        }

        /// <summary>
        /// Determines whether the specified model type is registered.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns>
        /// <c>true</c> if the specified model type is registered; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsRegistered(Type modelType)
        {
            Guard.IsNotNull(modelType, "modelType");

            return configurations.ContainsKey(modelType);
        }

        /// <summary>
        /// Determines whether the specified model type with the property name is registered.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// <c>true</c> if the specified model type with property name is registered; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsRegistered(Type modelType, string propertyName)
        {
            Guard.IsNotNull(modelType, "modelType");

            IDictionary<string, ModelMetadataItemBase> properties;

            return configurations.TryGetValue(modelType, out properties) && properties.ContainsKey(propertyName);
        }

        /// <summary>
        /// Gets the Matchings metadata of the given model.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns></returns>
        public virtual IDictionary<string, ModelMetadataItemBase> Matching(Type modelType)
        {
            Guard.IsNotNull(modelType, "modelType");

            IDictionary<string, ModelMetadataItemBase> properties;

            return configurations.TryGetValue(modelType, out properties) ? properties : null;
        }

        /// <summary>
        /// Gets the Matchings metadata of the given model property.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public virtual ModelMetadataItemBase Matching(Type modelType, string propertyName)
        {
            Guard.IsNotNull(modelType, "modelType");
            Guard.IsNotNull(propertyName, "propertyName");

            IDictionary<string, ModelMetadataItemBase> properties;

            if (!configurations.TryGetValue(modelType, out properties))
            {
                return null;
            }

            ModelMetadataItemBase propertyMetadata;

            return properties.TryGetValue(propertyName, out propertyMetadata) ? propertyMetadata : null;
        }
    }
}