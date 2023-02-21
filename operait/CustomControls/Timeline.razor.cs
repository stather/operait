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
using operait.Modals;
using Blazorise;
using Blazorise.DataGrid;
using Blazorise.Components;
using operait.Documents;

namespace operait.CustomControls
{
    public enum ViewPeriod
    {
        Day,
        Week,
        TwoWeek,
        Month
    }
public partial class Timeline
    {

        [Parameter] public Rotation Rotation { get; set; }

        [Parameter] public Team Team { get; set; }
        [Parameter] public ViewPeriod ViewPeriod { get; set; }
        [Parameter] public DateTime StartDate { get; set; }

        protected override Task OnInitializedAsync()
        {
           return base.OnInitializedAsync();
        }
    }
}
