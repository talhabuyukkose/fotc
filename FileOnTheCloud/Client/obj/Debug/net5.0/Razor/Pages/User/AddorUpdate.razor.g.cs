#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b4f06ba678bfbb7eccb0fc81591d3da048e3b75"
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
#line 1 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
           [Authorize(Roles = "admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/user/adduser")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/user/edituser/{userid:int}")]
    public partial class AddorUpdate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "newUser");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "newUserTitle");
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
__builder.AddContent(4, pagetitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(6);
            __builder.AddAttribute(7, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 12 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                     _usermodel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                AddorUpdateUser

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(9, "action", "");
            __builder.AddAttribute(10, "method", "post");
            __builder.AddAttribute(11, "class", "col-12");
            __builder.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(13);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\r\n        ");
                __builder2.OpenElement(15, "input");
                __builder2.AddAttribute(16, "type", "text");
                __builder2.AddAttribute(17, "placeholder", "İsim");
                __builder2.AddAttribute(18, "class", "col-4");
                __builder2.AddAttribute(19, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                          _usermodel.name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.name = __value, _usermodel.name));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_0(__builder2, 22, 23, 
#nullable restore
#line 15 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(24, "\r\n\r\n        ");
                __builder2.OpenElement(25, "input");
                __builder2.AddAttribute(26, "type", "text");
                __builder2.AddAttribute(27, "placeholder", "Soyisim");
                __builder2.AddAttribute(28, "class", "col-4");
                __builder2.AddAttribute(29, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                             _usermodel.surname

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.surname = __value, _usermodel.surname));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_1(__builder2, 32, 33, 
#nullable restore
#line 18 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.surname

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(34, "\r\n\r\n        ");
                __builder2.OpenElement(35, "input");
                __builder2.AddAttribute(36, "type", "email");
                __builder2.AddAttribute(37, "placeholder", "E-Posta");
                __builder2.AddAttribute(38, "class", "col-4");
                __builder2.AddAttribute(39, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 20 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                              _usermodel.emailaddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.emailaddress = __value, _usermodel.emailaddress));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_2(__builder2, 42, 43, 
#nullable restore
#line 21 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.emailaddress

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(44, "\r\n\r\n        ");
                __builder2.OpenElement(45, "input");
                __builder2.AddAttribute(46, "type", "password");
                __builder2.AddAttribute(47, "name", "password");
                __builder2.AddAttribute(48, "placeholder", "Şifre");
                __builder2.AddAttribute(49, "class", "col-4");
                __builder2.AddAttribute(50, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 23 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                                               _usermodel.password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.password = __value, _usermodel.password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_3(__builder2, 53, 54, 
#nullable restore
#line 24 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(55, "\r\n\r\n        ");
                __builder2.OpenElement(56, "input");
                __builder2.AddAttribute(57, "type", "text");
                __builder2.AddAttribute(58, "placeholder", "Bölüm");
                __builder2.AddAttribute(59, "class", "col-4");
                __builder2.AddAttribute(60, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 26 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                           _usermodel.department

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.department = __value, _usermodel.department));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(62, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_4(__builder2, 63, 64, 
#nullable restore
#line 27 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.department

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(65, "\r\n\r\n        ");
                __builder2.OpenElement(66, "input");
                __builder2.AddAttribute(67, "type", "text");
                __builder2.AddAttribute(68, "placeholder", "Ünvan");
                __builder2.AddAttribute(69, "class", "col-4");
                __builder2.AddAttribute(70, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 29 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                                                           _usermodel.title

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(71, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _usermodel.title = __value, _usermodel.title));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate.TypeInference.CreateValidationMessage_5(__builder2, 73, 74, 
#nullable restore
#line 30 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                  ()=> _usermodel.title

#line default
#line hidden
#nullable disable
                );
#nullable restore
#line 31 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
         if (userid != 0)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(75, "button");
                __builder2.AddAttribute(76, "type", "reset");
                __builder2.AddAttribute(77, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
                                           GotoUserPage

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(78, "Vazgeç");
                __builder2.CloseElement();
#nullable restore
#line 34 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\User\AddorUpdate.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(79, "<button type=\"submit\">Oluştur</button>");
            }
            ));
            __builder.CloseComponent();
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
namespace __Blazor.FileOnTheCloud.Client.Pages.User.AddorUpdate
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
