using AutoMapper;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Structure.Blazor.Extensions;
using Structure.Blazor.Services.LabelObject;
using Structure.Domain.LabelObjects;
using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Structure.Localization;

namespace Structure.Blazor.Pages
{
    public partial class LabelObjects
    {

        public List<LabelObjectDto> LabelList { get; set; }
        [Inject]
        public ILabelObjectServices LabelObjectServices { get; set; }
        [Inject]
        public IStringLocalizer<StructureResource> L { get; set; }
        [Inject]
        public IMapper objectMapper { get; set; }
        private string CuloareText { get; set; }
        private string CuloareBackground { get; set; }
        private int PageSize { get; } = 10;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private bool CanCreateLabelObject { get; set; } = true;
        private LabelObjectCreateDto NewLabelObject { get; set; }
        private Validations NewLabelObjectValidations { get; set; }
        private LabelObjectUpdateDto EditingLabelObject { get; set; }
        private Validations EditingLabelObjectValidations { get; set; }
        private Guid EditingLabelObjectId { get; set; }
        private Modal CreateLabelObjectModal { get; set; }
        private Modal EditLabelObjectModal { get; set; }
        private GetLabelObjectsInput Filter { get; set; }

        public LabelObjects()
        {
            NewLabelObject = new LabelObjectCreateDto();
            EditingLabelObject = new LabelObjectUpdateDto();
            Filter = new GetLabelObjectsInput
            {
                MaxResultCount=PageSize,
                SkipCount=(CurrentPage-1)*PageSize,
                Sorting=CurrentSorting
            };

        }
        protected override async Task OnInitializedAsync()
        {
            LabelList = await LabelObjectServices.GetList();

        }

        private async Task GetLabelObjectsAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            LabelList = await LabelObjectServices.GetList();
            foreach(var item in LabelList)
            {
                if(item.TextCssClass== TextCssClass.label_text1)
                {
                    CuloareText = "Text negru";
                }
                else
                {
                    CuloareText = "Text rosu inchis";
                }
            }
            foreach (var item in LabelList)
            {
                switch (item.BackgroundCssClass)
                {
                    case BackgroundCssClass.label1_background:
                        CuloareBackground = "Albastru deschis";
                        break;
                    case BackgroundCssClass.label2_background:
                        CuloareBackground = "Roz deschis";
                        break;
                    case BackgroundCssClass.label3_background:
                        CuloareBackground = "Rosu";
                        break;
                    case BackgroundCssClass.label4_background:
                        CuloareBackground = "Verde galbui";
                        break;
                    case BackgroundCssClass.label5_background:
                        CuloareBackground = "Maro";
                        break;
                    case BackgroundCssClass.label6_background:
                        CuloareBackground = "Visiniu";
                        break;
                    case BackgroundCssClass.label7_background:
                        CuloareBackground = "Gri deschis";
                        break;
                    case BackgroundCssClass.label8_background:
                        CuloareBackground = "Auriu";
                        break;
                    case BackgroundCssClass.label9_background:
                        CuloareBackground = "Violet deschis";
                        break;
                    case BackgroundCssClass.label10_background:
                        CuloareBackground = "Caramiziu";
                        break;
                }
            }
                TotalCount = LabelList.Count;

        }
        private async Task OnDatagridReadAsync(DataGridReadDataEventArgs<LabelObjectDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.Direction != SortDirection.None)
                .Select(c => c.Field + (c.Direction == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetLabelObjectsAsync();
            StateHasChanged();
        }
        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetLabelObjectsAsync();
            StateHasChanged();
        }
        private void OpenCreateLabelObjectModal()
        {
            NewLabelObject = new LabelObjectCreateDto();
            NewLabelObjectValidations.ClearAll();
            CreateLabelObjectModal.Show();
        }

        private void CloseCreateLabelObjectModal()
        {
            CreateLabelObjectModal.Hide();
        }

        private void OpenEditLabelObjectModal(LabelObjectDto input)
        {
            var id = (objectMapper.Map<LabelObject>(input)).Id;
            EditingLabelObjectId = id;
            EditingLabelObject = objectMapper.Map<LabelObjectDto, LabelObjectUpdateDto>(input);
            EditingLabelObjectValidations.ClearAll();
            EditLabelObjectModal.Show();
        }

        private async Task DeleteLabelObjectAsync(LabelObjectDto input)
        {
            var id = (objectMapper.Map<LabelObject>(input)).Id;
            await LabelObjectServices.DeleteLabelObject(id);
            await GetLabelObjectsAsync();
        }

        private async Task CreateLabelObjectAsync()
        {
            await LabelObjectServices.CreateLabel(NewLabelObject);
            await GetLabelObjectsAsync();
            CreateLabelObjectModal.Hide();
        }

        private void CloseEditLabelObjectModal()
        {
            EditLabelObjectModal.Hide();
        }

        private async Task UpdateLabelObjectAsync()
        {
            await LabelObjectServices.UpdateLabel(EditingLabelObjectId, EditingLabelObject);
            await GetLabelObjectsAsync();
            EditLabelObjectModal.Hide();
        }

    }
}