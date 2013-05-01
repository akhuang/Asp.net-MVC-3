using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents a class to store string length validation metadata.
    /// </summary>
    public class StringLengthValidationMetadata : ModelValidationMetadataBase
    {
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
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
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            return new ExtendedStringLengthValidator(modelMetadata, context, this);
        }
    }
}