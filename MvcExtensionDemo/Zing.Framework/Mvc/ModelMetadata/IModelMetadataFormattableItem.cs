 
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Represents an interface of a metadata that supports formatting.
    /// </summary>
    public interface IModelMetadataFormattableItem
    {
        /// <summary>
        /// Gets or sets the display format.
        /// </summary>
        /// <value>The display format.</value>
        string DisplayFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the edit format.
        /// </summary>
        /// <value>The edit format.</value>
        string EditFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to apply format in edit mode.
        /// </summary>
        /// <value>
        /// <c>true</c> if [apply format in edit mode]; otherwise, <c>false</c>.
        /// </value>
        bool ApplyFormatInEditMode
        {
            get;
            set;
        }
    }
}