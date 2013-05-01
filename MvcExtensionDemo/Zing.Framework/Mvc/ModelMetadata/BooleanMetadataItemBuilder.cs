
namespace Zing.Framework.Mvc
{
    /// <summary>
    /// Defines a class to fluently configure metadata of a <seealso cref="bool"/> type.
    /// </summary>
    public class BooleanMetadataItemBuilder : ModelMetadataItemBuilderBase<BooleanMetadataItem, BooleanMetadataItemBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanMetadataItemBuilder"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public BooleanMetadataItemBuilder(BooleanMetadataItem item) : base(item)
        {
        }
    }
}