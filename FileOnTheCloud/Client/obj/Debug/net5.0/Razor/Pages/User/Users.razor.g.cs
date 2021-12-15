#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8aaef705eaa60a0768ed810b3c725e728cfe8e2"
// <auto-generated/>
#pragma warning disable 1591
namespace FileOnTheCloud.Client.Pages.User
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
#line 21 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
           [Authorize(Roles = "admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/user/users")]
    public partial class Users : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenComponent<FileOnTheCloud.Client.Shared.LoginRouting>(2);
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n\r\n\r\n");
            __builder.AddMarkupContent(4, "<a href=\"/user/adduser\" class=\"button col-3 col-6-mobile\">Kullanıcı Ekle</a>\r\n<br>\r\n<br>\r\n");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "dataTableWrapper");
            __builder.OpenElement(7, "table");
            __builder.AddAttribute(8, "id", "example");
            __builder.AddAttribute(9, "class", "display default first-data-table");
            __builder.AddAttribute(10, "style", "width:100%");
            __builder.AddMarkupContent(11, @"<thead><tr><th></th>
                <th>KULLANICI İSMİ</th>
                <th>KULLANICI SOYADI</th>
                <th>ÜNVAN</th>
                <th>BÖLÜM</th>
                <th>E-POSTA</th>
                <th>YETKİ</th>
                <th></th></tr></thead>
        ");
            __builder.OpenElement(12, "tbody");
#nullable restore
#line 31 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
             foreach (var item in userlist)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "tr");
            __builder.OpenElement(14, "th");
            __builder.AddAttribute(15, "scope", "row");
#nullable restore
#line 34 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(16, userlist.IndexOf(item));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                    ");
            __builder.OpenElement(18, "td");
#nullable restore
#line 35 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(19, item.name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                    ");
            __builder.OpenElement(21, "td");
#nullable restore
#line 36 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(22, item.surname);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.OpenElement(24, "td");
#nullable restore
#line 37 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(25, item.title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                    ");
            __builder.OpenElement(27, "td");
#nullable restore
#line 38 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(28, item.department);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                    ");
            __builder.OpenElement(30, "td");
#nullable restore
#line 39 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(31, item.emailaddress);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n                    ");
            __builder.OpenElement(33, "td");
#nullable restore
#line 40 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
__builder.AddContent(34, item.role);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                    ");
            __builder.OpenElement(36, "td");
            __builder.OpenElement(37, "button");
            __builder.AddAttribute(38, "title", "Kullanıcıyı silmek için tıklayınız...");
            __builder.AddAttribute(39, "class", "userlistbutton");
            __builder.AddAttribute(40, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 42 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
                                                                                                              ()=>DeleteUser(item.id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(41, "SİL");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\r\n                        ");
            __builder.OpenElement(43, "button");
            __builder.AddAttribute(44, "title", "Kullanıcıyı düzenlemek için tıklayınız...");
            __builder.AddAttribute(45, "class", "userlistbutton");
            __builder.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
                                                                                                                   ()=>GotoEditUser(item.id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(47, "DÜZENLE");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n\r\n                        ");
            __builder.OpenElement(49, "button");
            __builder.AddAttribute(50, "title", "Kullanıcıya bildirim göndermek için tıklayınız...");
            __builder.AddAttribute(51, "class", "userlistbutton");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
                                                                                                                           ()=>SendNotification(item.emailaddress)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(53, "BİLDİRİM GÖNDER");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 49 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\Users.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
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
