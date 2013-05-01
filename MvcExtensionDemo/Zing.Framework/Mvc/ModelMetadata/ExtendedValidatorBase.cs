 
namespace Zing.Framework.Mvc
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Web.Mvc;
 
    /// <summary>
    /// Defines a base class that is used to validate model value.
    /// </summary>
    /// <typeparam name="TValidationAttribute">The type of the validation attribute.</typeparam>
    public abstract class ExtendedValidatorBase<TValidationAttribute> : ModelValidator where TValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedValidatorBase&lt;TValidationAttribute&gt;"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="controllerContext">The controller context.</param>
        protected ExtendedValidatorBase(ModelMetadata metadata, ControllerContext controllerContext) : base(metadata, controllerContext)
        {
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <value>The attribute.</value>
        protected TValidationAttribute Attribute
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The error message.</value>
        protected string ErrorMessage
        {
            [DebuggerStepThrough]
            get
            {
                return Attribute.FormatErrorMessage(Metadata.GetDisplayName());
            }
        }

        /// <summary>
        /// When implemented in a derived class, validates the object.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>A list of validation results.</returns>
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (!Attribute.IsValid(Metadata.Model))
            {
                yield return new ModelValidationResult
                                 {
                                     Message = ErrorMessage
                                 };
            }
        }
    }
}