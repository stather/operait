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

namespace operait.Pages.Alerts
{
    public partial class List
    {
        private Modal? createAlertRef;

        private Task ShowCreateAlert()
        {
            return createAlertRef.Show();
        }

        private Task HideCreateAlert()
        {
            return createAlertRef.Hide();
        }

        private Task CreateAlert()
        {
            return createAlertRef.Hide();
        }
    }
}