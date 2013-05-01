using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents a class to store range validation metadata.
    /// </summary>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    public class RangeValidationMetadata<TValueType> : ModelValidationMetadataBase
    {
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public TValueType Minimum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public TValueType Maximum
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
            return new ExtendedRangeValidator<TValueType>(modelMetadata, context, this);
        }
    }
}