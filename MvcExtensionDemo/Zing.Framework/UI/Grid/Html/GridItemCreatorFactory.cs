using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridItemCreatorFactory : IGridItemCreatorFactory
    {
        public IGridItemCreator Create(IGridDataKeyStore dataKeyData, IGridItemCreatorData creatorData)
        {
            var comparer = new GridDataKeyComparer(dataKeyData.DataKeyGetters, dataKeyData.CurrentDataKeyValues);

            return new GridItemCreator(comparer, creatorData);
        }
    }
}
