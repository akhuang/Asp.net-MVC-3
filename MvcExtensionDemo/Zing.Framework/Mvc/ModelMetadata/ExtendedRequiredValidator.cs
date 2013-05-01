 
namespace Zing.Framework.Mvc
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Defines a class that is used to validate whether a value is specified.
    /// </summary>
    public class ExtendedRequiredValidator : ExtendedValidatorBase<RequiredAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedRequiredValidator"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="validationMetadata">The validation metadata.</param>
        public ExtendedRequiredValidator(ModelMetadata metadata, ControllerContext controllerContext, IModelValidationMetadata validationMetadata) : base(metadata, controllerContext)
        {
            if (!string.IsNullOrEmpty(validationMetadata.ErrorMessage))
            {
                Attribute = new RequiredAttribute { ErrorMessage = validationMetadata.ErrorMessage };
            }
            else if ((validationMetadata.ErrorMessageResourceType != null) && (!string.IsNullOrEmpty(validationMetadata.ErrorMessageResourceName)))
            {
                Attribute = new RequiredAttribute { ErrorMessageResourceType = validationMetadata.ErrorMessageResourceType, ErrorMessageResourceName = validationMetadata.ErrorMessageResourceName };
            }
            else
            {
                Attribute = new RequiredAttribute();
            }
        }

        /// <summary>
        /// Gets metadata for client validation.
        /// </summary>
        /// <returns>The metadata for client validation.</returns>
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRequiredRule(ErrorMessage) };
        }
    }
}