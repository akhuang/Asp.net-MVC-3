
using System;
using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents an interface to store validation metadata.
    /// </summary>
    public interface IModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the error message resource.
        /// </summary>
        /// <value>The type of the error message resource.</value>
        Type ErrorMessageResourceType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the error message resource.
        /// </summary>
        /// <value>The name of the error message resource.</value>
        string ErrorMessageResourceName
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
        ModelValidator CreateValidator(ExtendedModelMetadata modelMetadata, ControllerContext context);
    }
}