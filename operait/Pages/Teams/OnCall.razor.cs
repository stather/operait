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
        private bool restrictIntervals;
        private TimeIntervalRestriction RestrictionType;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private List<ShiftInterval> intervals = new List<ShiftInterval> { new ShiftInterval {FromDay = DayOfWeek.Monday, FromTime = DateTime.Parse("00:00"), ToDay = DayOfWeek.Monday, ToTime = DateTime.Parse("00:00") } };
        [Parameter]
        public string teamId { get; set; }
        private Team? team;

        private Modal? addScheduleRef;
        private string scheduleName;

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

        void ShowAddSchedule()
        {

        }

        void AddCondition()
        {
            AddedConditions.Add(new RoutingCondition { Item = RoutingItem.Actions, Key = "", NotCondition = false, Operator = ConditionOperator.Regex, Value = "" });
        }

        Task StartTimeChanged(TimeSpan t)
        {
            startTime = t;
            return Task.CompletedTask;
        }
        Task EndTimeChanged(TimeSpan t)
        {
            endTime = t;
            return Task.CompletedTask;
        }

        void AddNewInterval()
        {
            intervals.Add(new ShiftInterval { FromDay = DayOfWeek.Monday, FromTime = DateTime.Parse("00:00"), ToDay = DayOfWeek.Monday, ToTime = DateTime.Parse("00:00") });
        }
    }
}