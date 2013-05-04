using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public interface IGridLocalization
    {
        string CancelChanges { get; }

        string SaveChanges { get; }

        string Select
        {
            get;
        }

        string GroupHint
        {
            get;
        }

        string AddNew
        {
            get;
        }

        string Insert
        {
            get;
        }

        string Update
        {
            get;
        }

        string Edit
        {
            get;
        }

        string Delete
        {
            get;
        }

        string Cancel
        {
            get;
        }
    }
}
