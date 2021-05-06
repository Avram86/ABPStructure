using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Structure.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.Blazor.Pages.Components
{
    public partial class DataGridEntityActionsColumn<TItem> : DataGridColumn<TItem>
    {
        [Inject]
        public IStringLocalizer<StructureResource> UiLocalizer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            Caption = UiLocalizer["Actions"];
            Width = "150px";
            Sortable = false;
            Field = typeof(TItem).GetProperties().First().Name;
            return ValueTask.CompletedTask;
        }
    }
}