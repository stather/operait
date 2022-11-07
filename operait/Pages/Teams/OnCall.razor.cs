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
using Blazorise;
using Blazorise.DataGrid;
using Blazorise.Components;
using operait.Services;
using operait.Documents;

namespace operait.Pages.Teams
{
    public partial class OnCall
    {
        [Parameter]
        public string teamId { get; set; }
        private Team? team;

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            team = await DatabaseService.GetTeamAsync(teamId);
        }
    }
}