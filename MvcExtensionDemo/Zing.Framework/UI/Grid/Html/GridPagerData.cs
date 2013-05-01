﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridPagerData
    {
        //public GridPagerStyles Style
        //{
        //    get;
        //    set;
        //}

        public int CurrentPage
        {
            get;
            set;
        }

        public int PageCount
        {
            get;
            set;
        }

        public string PageText
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        //public IGridUrlBuilder UrlBuilder
        //{
        //    get;
        //    set;
        //}

        public string PageOfText
        {
            get;
            set;
        }

        public int Colspan
        {
            get;
            set;
        }

        public string DisplayingItemsText
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public string RefreshText
        {
            get;
            set;
        }
    }
}
