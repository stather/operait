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

namespace operait.Modals
{
    public partial class AddRotation
    {
        private Modal? addRotationRef;

        private Rotation newRotation = new Rotation
        {
            RotationType = RotationType.Daily
        };

        [Inject] DatabaseService DatabaseService { get; set; }

        [Parameter] public Team Team { get; set; }
        [Parameter] public Schedule Schedule { get; set; }

        private Task CloseAddRotation()
        {
            return addRotationRef?.Hide();
        }

        private async Task AddRotationCommand()
        {
            Schedule.Rotations.Add(newRotation);
            await DatabaseService.UpdateTeamAsync(Team);
            await (addRotationRef?.Hide());
        }

        public Task Show()
        {
            return addRotationRef.Show();
        }
    }
}