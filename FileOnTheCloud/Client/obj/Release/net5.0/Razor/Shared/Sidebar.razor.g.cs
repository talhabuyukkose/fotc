#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76f92bda3006aab368c5326ccbfa3372f9f194b4"
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
    public partial class Sidebar : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Roles", "admin");
            __builder.AddAttribute(2, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(3, "section");
                __builder2.AddAttribute(4, "id", "adminPanel");
                __builder2.AddMarkupContent(5, "<div class=\"adminTitle\">\r\n                KONTROL PANELİ <i>admin</i></div>\r\n            ");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "adminName");
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
__builder2.AddContent(8, user.name);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(9, " ");
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
__builder2.AddContent(10, user.surname);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(11, "\r\n            ");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "adminButtons");
                __builder2.AddAttribute(14, "id", "nav");
                __builder2.AddMarkupContent(15, "<a href=\"/note/notes\" class=\"button\">NOTLAR</a>\r\n                ");
                __builder2.AddMarkupContent(16, "<a href=\"/user/users\" class=\"button\">KULLANICILAR <i>(ekle / düzenle)</i></a>\r\n                ");
                __builder2.AddMarkupContent(17, "<a href=\"/note/addnote\" class=\"button\">YENİ NOT EKLE</a>\r\n                ");
                __builder2.AddMarkupContent(18, "<a href class=\"button\">KATEGORİLER <i>(ekle / düzenle)</i></a>\r\n                 ");
                __builder2.OpenComponent<MudBlazor.MudBadge>(19);
                __builder2.AddAttribute(20, "Content", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                     notifications.Count

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                                                 Color.Secondary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "Overlap", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                                                                           true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(24, "<a href=\"/notifications\" class=\"button\">BİLDİRİMLER</a>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(25, "\r\n                ");
                __builder2.AddMarkupContent(26, "<a href=\"/auth/logout\" class=\"button\">ÇIKIŞ</a>");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(27, "\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(28);
            __builder.AddAttribute(29, "Roles", "kullanıcı");
            __builder.AddAttribute(30, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(31, "section");
                __builder2.AddAttribute(32, "id", "adminPanel");
                __builder2.AddMarkupContent(33, "<div class=\"adminTitle\">\r\n                KONTROL PANELİ\r\n            </div>\r\n            ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "adminName");
                __builder2.AddMarkupContent(36, "\r\n                Sn. ");
#nullable restore
#line 32 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
__builder2.AddContent(37, user.title);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(38, " ");
#nullable restore
#line 32 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
__builder2.AddContent(39, user.name);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(40, " ");
#nullable restore
#line 32 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
__builder2.AddContent(41, user.surname);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n            ");
                __builder2.OpenElement(43, "div");
                __builder2.AddAttribute(44, "class", "adminButtons");
                __builder2.AddMarkupContent(45, "<a href=\"/note/addnote\" class=\"button\">Not Ekle</a>\r\n                ");
                __builder2.OpenElement(46, "button");
                __builder2.AddAttribute(47, "id", "messageSend");
                __builder2.AddAttribute(48, "class", "button");
                __builder2.AddAttribute(49, "style", "margin-bottom: 20px;font-size:16px;");
                __builder2.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 36 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                                                                                              SendMail

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(51, "Yönetici ile İletişime Geç");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n                ");
                __builder2.OpenComponent<MudBlazor.MudBadge>(53);
                __builder2.AddAttribute(54, "Content", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 37 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                    notifications.Count

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(55, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 37 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                                                Color.Secondary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(56, "Overlap", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 37 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Shared\Sidebar.razor"
                                                                                          true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(57, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(58, "<a href=\"/notifications\" class=\"button\">BİLDİRİMLER</a>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(59, "\r\n                ");
                __builder2.AddMarkupContent(60, "<a href=\"/auth/logout\" class=\"button\">ÇIKIŞ</a>");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
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