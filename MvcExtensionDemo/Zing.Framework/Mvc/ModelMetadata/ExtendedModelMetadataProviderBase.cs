using System;
using System.Web.Mvc;
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Defines a base class which supports checking of model type registration.
    /// </summary>
    public abstract class ExtendedModelMetadataProviderBase : ModelMetadataProvider
    {
        /// <summary>
        /// Determines whether the specified model type is registered.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns>
        /// <c>true</c> if the specified model type is registered; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsRegistered(Type modelType);

        /// <summary>
        /// Determines whether the specified model type with the property name is registered.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// <c>true</c> if the specified model type with property name is registered; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsRegistered(Type modelType, string propertyName);
    }
}