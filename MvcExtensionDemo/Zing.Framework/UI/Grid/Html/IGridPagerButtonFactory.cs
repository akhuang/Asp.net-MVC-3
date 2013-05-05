﻿// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI.Html
{
    public interface IGridPagerButtonFactory
    {
        IHtmlNode CreateButton(GridPagerButtonType buttonType, string text, bool enabled, string url);
    }

    public enum GridPagerButtonType
    {
        Icon = 0,
        NumericLink
    }
}