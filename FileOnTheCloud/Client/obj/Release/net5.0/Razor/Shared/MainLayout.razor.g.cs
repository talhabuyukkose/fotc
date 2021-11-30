#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dba2e3b5e9c1d5417f01744aff6d44bcf5630593"
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
#line 1 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Blazored.SessionStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.Instrument;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.CustomComponents.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using FileOnTheCloud.Client.CustomComponents.Button;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
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
            __builder.OpenComponent<FileOnTheCloud.Client.Shared.Header>(2);
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "wrapper line-top");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "container fluid");
            __builder.AddAttribute(8, "id", "main");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "row");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-4 col-12-mobile");
            __builder.AddAttribute(13, "id", "sidebar");
            __builder.OpenComponent<FileOnTheCloud.Client.Shared.Sidebar>(14);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\n                ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "col-8 col-12-mobile");
            __builder.AddAttribute(18, "id", "rightMain");
#nullable restore
#line 11 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\MainLayout.razor"
__builder.AddContent(19, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n    ");
            __builder.OpenComponent<FileOnTheCloud.Client.Shared.Footer>(21);
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\MainLayout.razor"
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHelper helper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalManager modalManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISessionStorageService _sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpclient { get; set; }
    }
}
#pragma warning restore 1591
