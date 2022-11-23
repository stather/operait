using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using operait;
using operait.Shared;
using operait.CustomControls;
using Blazorise;
using Blazorise.DataGrid;
using Blazorise.Components;
using operait.Services;

namespace operait.Pages.Alerts
{
    public partial class Detail
    {
        [Parameter]
        public string AlertId { get; set; }

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        private operait.Documents.Alert? alert;

        protected override async Task OnInitializedAsync()
        {
            alert = await DatabaseService.GetAlertAsync(AlertId);
        }

        private Task ShowAddResponder()
        {
            return Task.CompletedTask;
        }
    }
}