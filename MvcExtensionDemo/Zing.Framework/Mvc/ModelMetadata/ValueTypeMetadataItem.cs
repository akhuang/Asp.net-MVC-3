namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Defines a class that is used to store <seealso cref="ValueType"/> metadata.
    /// </summary>
    public class ValueTypeMetadataItem : ModelMetadataItemBase, IModelMetadataFormattableItem
    {
        /// <summary>
        /// Gets or sets the display format.
        /// </summary>
        /// <value>The display format.</value>
        public string DisplayFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the edit format.
        /// </summary>
        /// <value>The edit format.</value>
        public string EditFormat
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
        public bool ApplyFormatInEditMode
        {
            get;
            set;
        }
    }
}