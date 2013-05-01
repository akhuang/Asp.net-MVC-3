using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Zing.Framework.UI
{
    public interface IViewComponent
    {
        string Id { get; }

        string Name { get; }

        ViewContext ViewContext { get; }
    }
}
