
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zing.Framework.Utility;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Defines a model validator provider which support fluent registration.
    /// </summary>
    public class ExtendedModelValidatorProvider : ModelValidatorProvider
    {
        /// <summary>
        /// Gets a list of validators.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns>A list of validators.</returns>
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            Guard.IsNotNull(metadata, "metadata");
            Guard.IsNotNull(context, "context");

            ExtendedModelMetadata extendedModelMetadata = metadata as ExtendedModelMetadata;

            return (extendedModelMetadata != null) && (extendedModelMetadata.Metadata != null) ?
                   extendedModelMetadata.Metadata.Validations.Select(validationMeta => validationMeta.CreateValidator(extendedModelMetadata, context)) :
                   Enumerable.Empty<ModelValidator>();
        }
    }
}