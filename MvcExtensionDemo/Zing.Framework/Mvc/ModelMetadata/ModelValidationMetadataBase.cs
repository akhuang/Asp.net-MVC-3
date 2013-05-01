using System;
using System.Web.Mvc;
using Zing.Framework.Utility;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents a base class to store validation metadata.
    /// </summary>
    public abstract class ModelValidationMetadataBase : IModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the error message resource.
        /// </summary>
        /// <value>The type of the error message resource.</value>
        public Type ErrorMessageResourceType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the error message resource.
        /// </summary>
        /// <value>The name of the error message resource.</value>
        public string ErrorMessageResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public ModelValidator CreateValidator(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            Guard.IsNotNull(modelMetadata, "modelMetadata");
            Guard.IsNotNull(context, "context");

            return CreateValidatorCore(modelMetadata, context);
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected abstract ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context);
    }
}