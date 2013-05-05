﻿// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Zing.Framework.Utility.Extensions;

    internal class GridClientObjectSerializer<T>
        where T : class
    {
        private readonly Grid<T> grid;

        public GridClientObjectSerializer(Grid<T> grid)
        {
            this.grid = grid;
        }

        public void Serialize(IClientSideObjectWriter writer)
        {
            var columns = new List<IDictionary<string, object>>();

            grid.VisibleColumns.Each(column =>
            {
                columns.Add(column.CreateSerializer().Serialize());
            });

            if (columns.Any())
            {
                writer.AppendCollection("columns", columns);
            }

            new GridPluginSerializer(grid).SerializeTo(writer);

            new GridUrlFormatSerializer<T>(grid).SerializeTo(writer);

            grid.Editing.SerializeTo("editing", writer);
            var shouldSerializeDataSource = false;

            if (grid.OutputValidation)
            {
                writer.AppendObject("validationMetadata", grid.ValidationMetadata);
            }

            shouldSerializeDataSource = grid.Editing.Enabled && grid.IsClientBinding && !grid.IsEmpty;

            grid.Grouping.SerializeTo("grouping", writer);
            grid.Paging.SerializeTo("paging", writer);
            grid.Sorting.SerializeTo("sorting", writer);
            grid.Selection.SerializeTo("selection", writer);

            grid.Filtering.SerializeTo("filtering", writer);

            if (grid.DataBinding.IsClientOperationMode)
            {
                writer.Append("operationMode", "client");
                shouldSerializeDataSource = true;
            }

            grid.KeyboardNavigation.SerializeTo("keyboardNavigation", writer);
            grid.ColumnContextMenu.SerializeTo("columnContextMenu", writer);

            if (shouldSerializeDataSource)
            {
                grid.SerializeDataSource(writer);
            }

            grid.Ajax.SerializeTo("ajax", writer);
            grid.WebService.SerializeTo("ws", writer);
            grid.ClientEvents.SerializeTo("clientEvents", writer);
            grid.Localization.SerializeTo("localization", writer);
            if (grid.DetailView != null)
            {
                grid.DetailView.SerializeTo("detail", writer);
            }

            if (grid.ClientRowTemplate.HasValue())
            {
                writer.Append("rowTemplate", grid.IsSelfInitialized ? grid.ClientRowTemplate.Replace("<", "%3c").Replace(">", "%3e") : grid.ClientRowTemplate);
            }

            writer.Append("noRecordsTemplate", grid.NoRecordsTemplate);
        }
    }
}