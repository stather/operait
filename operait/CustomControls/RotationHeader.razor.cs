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
    public partial class RotationHeader
    {
        [Parameter] public ViewPeriod ViewPeriod { get; set; }
        [Parameter] public DateTime StartDate { get; set; }
        [Parameter] public Schedule Schedule { get; set; }

        private List<string> TimelineColumns = new List<string>();

        protected override Task OnInitializedAsync()
        {
            var today = StartDate;
            for (int i = 0; i < 7; i++)
            {
                var s = today.ToString("dd/MM ddd");
                TimelineColumns.Add(s);
                today = today.AddDays(1);
            }
            return base.OnInitializedAsync();
        }

    }
}