﻿// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI.Html
{
    public interface IGridDataSectionBuilder
    {
        IHtmlNode CreateBody(GridRenderingData data);

        IHtmlNode CreateHeader(GridRenderingData data);

        IHtmlNode CreateFooter(GridRenderingData data);
    }
}
