#pragma checksum "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eb00cc0a23b5a9298eacc85c117f7e5cbe8ea6e"
// <auto-generated/>
#pragma warning disable 1591
namespace FileOnTheCloud.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Blazored.SessionStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Instrument;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.CustomComponents.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.CustomComponents.Button;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page-wrapper");
            __builder.AddAttribute(2, "b-mzpaw2kksa");
            __builder.OpenComponent<FileOnTheCloud.Client.Shared.Header>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\n    ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "wrapper");
            __builder.AddAttribute(7, "b-mzpaw2kksa");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "container fluid");
            __builder.AddAttribute(10, "id", "main");
            __builder.AddAttribute(11, "b-mzpaw2kksa");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "row");
            __builder.AddAttribute(14, "b-mzpaw2kksa");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "col-4 col-12-narrower");
            __builder.AddAttribute(17, "id", "sidebar");
            __builder.AddAttribute(18, "b-mzpaw2kksa");
            __builder.OpenComponent<FileOnTheCloud.Client.Shared.Sidebar>(19);
            __builder.CloseComponent();
            __builder.AddMarkupContent(20, "\n                    ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "col-8 col-12-narrower");
            __builder.AddAttribute(23, "id", "rightMain");
            __builder.AddAttribute(24, "b-mzpaw2kksa");
#nullable restore
#line 10 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\Shared\MainLayout.razor"
__builder.AddContent(25, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "C:\Users\talha\source\repos\fileonthecloud\FileOnTheCloud\FileOnTheCloud\Client\Shared\MainLayout.razor"
                [CascadingParameter]
    public Task<AuthenticationState> AuthState { get; set; }

    private string email;

    private string roleName = String.Empty;

    protected override async Task OnInitializedAsync()
    {
        var authstate = await AuthState;

        if (authstate.User.Identity.IsAuthenticated)
        {
            email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            roleName = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Role).Value;
        }

    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalManager modalManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISessionStorageService _sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpclient { get; set; }
    }
}
#pragma warning restore 1591
