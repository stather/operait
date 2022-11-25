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
using operait.CustomControls;
using operait.Modals;

namespace operait.Pages.Teams
{
    public enum ViewPeriod
    {
        day,
        week,
        twoweek,
        month
    }

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
        private List<ShiftInterval> intervals = new List<ShiftInterval> { new ShiftInterval {FromDay = DayOfWeek.Monday, FromTime = TimeSpan.Zero, ToDay = DayOfWeek.Monday, ToTime = TimeSpan.Zero } };
        [Parameter]
        public string teamId { get; set; }
        private Team? team;

        #region schedule variables
        private Modal? addScheduleRef;
        private string scheduleName;
        private string scheduleDescription;
        private AddRotation? addRotationRef;
        private RotationType selectedRotationType;
        private bool endsOn = false;
        private bool restricted = false;
        private TimeIntervalRestrictionType TimeRestriction = TimeIntervalRestrictionType.TimeOfDay;
        private List<ShiftInterval> AddedIntervals = new List<ShiftInterval> { new ShiftInterval { FromDay=DayOfWeek.Monday, FromTime = TimeSpan.Zero, ToDay = DayOfWeek.Tuesday, ToTime = TimeSpan.FromHours(6)} };
        private Schedule selectedSchedule;
        private Rotation newRotation = new Rotation();
        private List<string> TimelineColumns = new List<string>();
        #endregion

        [Inject]
        protected DatabaseService DatabaseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            team = await DatabaseService.GetTeamAsync(teamId);
            var today = DateTime.Today;
            while (today.DayOfWeek != DayOfWeek.Monday)
            {
                today = today.AddDays(-1);
            }
            for (int i = 0; i < 7; i++)
            {
                var s = today.ToString("dd/MM ddd");
                TimelineColumns.Add(s);
                today = today.AddDays(1);
            }
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

        #region schedule methods
        Task ShowAddSchedule()
        {
            return addScheduleRef.Show();
        }

        Task CloseAddSchedule()
        {
            return addScheduleRef.Hide();
        }

        async Task AddSchedule()
        {
            var s = new Schedule
            {
                Name = scheduleName,
                Description = scheduleDescription,
                Enabled = true
            };
            team.Schedules.Add(s);
            await DatabaseService.UpdateTeamAsync(team);
        }

        Task ShowAddRotation(Schedule schedule)
        {
            selectedSchedule = schedule;
            newRotation = new Rotation();
            addRotationRef.Schedule = schedule;
            return addRotationRef.Show();
        }

        #endregion

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

    }
}