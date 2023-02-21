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
using operait.Documents;
using operait.Services;
using Alert = operait.Documents.Alert;

namespace operait.Pages.Alerts
{
    public partial class List
    {
        private Modal? createAlertRef;
        private List<Responder> responders = new List<Responder>();
        private List<Responder> selectedResponders = new List<Responder>();
        private List<string> selectedRespondersNames = new List<string>();
        private List<Tag> tags;
        private List<Integration> apis;
        private List<string> selectedTagIds = new List<string>();
        private List<string> selectedTagNames = new List<string>();
        private string selectedIntegration;
        private AlertPriority selectedPriority = AlertPriority.P3_Moderate;

        private string alertMessage;
        private string alias;

        private List<Alert> alerts;

        private Modal? addResponder;

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var users = await DatabaseService.GetAllUsersAsync();
            var teams = await DatabaseService.GetAllTeamsAsync();
            responders.AddRange(users.Select(u => new Responder {Id=u.Id,Name=u.Name,Type=ResponderType.Person }));
            responders.AddRange(teams.Select(t => new Responder { Id=t.Id, Name=t.Name, Type=ResponderType.Team}));
            tags = await DatabaseService.GetAllTagsAsync();
            apis = await DatabaseService.GetApiIntegrations();
            alerts = await DatabaseService.GetAllAlertsAsync();
        }

        private void AlertDetail(Alert alert)
        {
            NavigationManager.NavigateTo($"/alert/list/{alert.Id}");
        }
        private Task ToggleClicked()
        {
            return Task.CompletedTask;
        }

        private Task ShowAddResponder(Alert alert)
        {
            return addResponder.Show();
        }

        private Task ShowCreateAlert()
        {
            return createAlertRef.Show();
        }

        private Task HideCreateAlert()
        {
            return createAlertRef.Hide();
        }

        private async Task CreateAlert()
        {
            var alert = new Documents.Alert
            {
                AlertMessage = alertMessage,
                LastUpdated = DateTime.UtcNow,
                Status = AlertStatus.Open,
                Alias = string.IsNullOrEmpty(alias)?Guid.NewGuid().ToString():alias,
                ApiIntegrationId = selectedIntegration,
                Priority = selectedPriority,
                DeduplicationCounter = 1,
                CreatedAt= DateTime.UtcNow,
            };
            alert.Tags.AddRange(selectedTagNames);
            alert.Responders.AddRange(selectedResponders);
            alert.Activities.Add(new Activity { CreatedAt= DateTime.UtcNow, Description="Alert created via web" });
            await DatabaseService.AddAlertAsync(alert);
            await createAlertRef.Hide();
        }
    }
}