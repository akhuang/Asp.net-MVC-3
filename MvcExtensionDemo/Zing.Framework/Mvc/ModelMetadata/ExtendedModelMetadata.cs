
using System;
using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Defines a metadata class which supports fluent metadata registration.
    /// </summary>
    public class ExtendedModelMetadata : ModelMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedModelMetadata"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="containerType">Type of the container.</param>
        /// <param name="modelAccessor">The model accessor.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="metadata">The metadata.</param>
        public ExtendedModelMetadata(ModelMetadataProvider provider, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName, ModelMetadataItemBase metadata) : base(provider, containerType, modelAccessor, modelType, propertyName)
        {
            Metadata = metadata;
        }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        public ModelMetadataItemBase Metadata
        {
            get;
            private set;
        }
    }
}