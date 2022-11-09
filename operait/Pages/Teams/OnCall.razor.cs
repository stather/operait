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
        private Modal? addRoutingRuleRef;
        private string routingRuleName;
        private operait.Documents.RoutingMatch RoutingMatchSelected;
        private List<RoutingCondition> AddedConditions = new List<RoutingCondition> { new RoutingCondition{ Item = RoutingItem.Actions,  Key = "",  NotCondition = false, Operator = ConditionOperator.Regex, Value = "" } };
        private RoutingItem RoutingItemSelected;

        [Parameter]
        public string teamId { get; set; }
        private Team? team;

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            team = await DatabaseService.GetTeamAsync(teamId);
        }

        void SaveView()
        {

        }

        Task ShowAddRoutingRule()
        {
            return addRoutingRuleRef.Show();
        }

        Task CloseAddRouting()
        {
            return addRoutingRuleRef.Hide();
        }

        void AddEscalation()
        {

        }

        void AddSchedule()
        {

        }

        void AddCondition()
        {
            AddedConditions.Add(new RoutingCondition { Item = RoutingItem.Actions, Key = "", NotCondition = false, Operator = ConditionOperator.Regex, Value = "" });
        }
    }
}