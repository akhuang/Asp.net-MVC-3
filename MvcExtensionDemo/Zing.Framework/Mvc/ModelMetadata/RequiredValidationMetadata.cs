using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents a class to store required validation metadata.
    /// </summary>
    public class RequiredValidationMetadata : ModelValidationMetadataBase
    {
        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            return new ExtendedRequiredValidator(modelMetadata, context, this);
        }
    }
}