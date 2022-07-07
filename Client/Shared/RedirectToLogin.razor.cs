using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Shared
{
    public partial class RedirectToLogin
    {
      [Inject]  public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Navigation.NavigateTo($"/login?redirectUri={Uri.EscapeDataString(Navigation.Uri)}",true);
        }
    }
}
