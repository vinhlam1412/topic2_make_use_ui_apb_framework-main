using Blazorise;
using Blazorise.DataGrid;
using Demo.UI.Orders;
using Demo.UI.Products;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;


namespace Demo.UI.Blazor.Pages.Orders
{
    public partial class SaleOrder
    {
        private OrderDto orders;
        string columnClass = "12";
        bool FilterVisible = false;
        DatePicker<DateTime?> datePicker;
        void ToggleFilter()
        {
            FilterVisible = !FilterVisible;
            columnClass = FilterVisible ? "10" : "12";
        }
        private void GoToEditPage(OrderDto order)
        {
            NavigationManager.NavigateTo($"/saleorder/edit/{order.Id}");
        }
        int selectedListValue { get; set; } = 3;

        private string SelectedOption1 { get; set; }
        private string SelectedOption2 { get; set; }
        private string SelectedOption3 { get; set; }
        private string SelectedOption4 { get; set; }

        private string Option1 { get; set; }
        private string Option2 { get; set; }
        private string Option3 { get; set; }
        private string Option4 { get; set; }

        protected override async Task OnInitializedAsync()
        {  
        await base.OnInitializedAsync();
        }

    
      

    }
}
