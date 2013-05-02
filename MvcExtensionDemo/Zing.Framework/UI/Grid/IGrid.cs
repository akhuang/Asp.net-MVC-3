using System.Collections.Generic;
using System.Web.Mvc;

namespace Zing.Framework.UI
{
    public interface IGrid : IGridBindingContext
    {
        bool HasDetailView
        {
            get;
        }

        //GridPagingSettings Paging
        //{
        //    get;
        //}

        bool IsSelfInitialized
        {
            get;
        }

        string EditorHtml
        {
            get;
        }


        GridDataProcessor DataProcessor
        {
            get;
        }


    }
}
