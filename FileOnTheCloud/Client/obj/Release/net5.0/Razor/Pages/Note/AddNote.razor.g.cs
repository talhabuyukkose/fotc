#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\AddNote.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a9f5ebc01c44ac6d4082d17e68e88c8853b55c8"
// <auto-generated/>
#pragma warning disable 1591
namespace FileOnTheCloud.Client.Pages.Note
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/note/addnote")]
    public partial class AddNote : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""uploadWrapper""><div class=""row aln-middle""><div class=""uploads col-12""><div id=""drag-and-drop-zone"" class=""dm-uploader""><div class=""btn btn-primary new button btn-block mb-5""><span>Dosya Seç</span>
                    <input type=""file"" title='Dosya Seç'></div>
                <h3 class=""mb-5 mt-5 text-muted"">Dosya Yükle / Sürükle Bırak</h3></div>
            <div class=""col-12""><div class=""card""><div class=""card-header"">
                        Yükledikleriniz:
                    </div>

                    <ul class=""list-unstyled"" id=""files""><li class=""text-muted text-center empty"">Henü dosya eklemediniz.</li></ul></div></div></div></div></div>

");
            __builder.AddMarkupContent(1, "<div class=\"dataTableWrapper\"><table id=\"examplee\" class=\"display default second-data-table\" style=\"width:100%\"><thead><tr><th>DOSYA İSMİ</th>\r\n                <th>BOYUT</th>\r\n                <th>SINIF</th>\r\n                <th>DÖNEM</th>\r\n                <th>KATEGORİ</th>\r\n                <th>YÜKLENME TARİHİ</th></tr></thead>\r\n        <tbody><tr><td>Tiger Nixon</td>\r\n                <td>System Architect</td>\r\n                <td>Edinburgh</td>\r\n                <td>61</td>\r\n                <td>2011/04/25</td>\r\n                <td>$320,800</td></tr>\r\n            <tr><td>Garrett Winters</td>\r\n                <td>Accountant</td>\r\n                <td>Tokyo</td>\r\n                <td>63</td>\r\n                <td>2011/07/25</td>\r\n                <td>$170,750</td></tr>\r\n            <tr><td>Ashton Cox</td>\r\n                <td>Junior Technical Author</td>\r\n                <td>San Francisco</td>\r\n                <td>66</td>\r\n                <td>2009/01/12</td>\r\n                <td>$86,000</td></tr>\r\n            <tr><td>Cedric Kelly</td>\r\n                <td>Senior Javascript Developer</td>\r\n                <td>Edinburgh</td>\r\n                <td>22</td>\r\n                <td>2012/03/29</td>\r\n                <td>$433,060</td></tr>\r\n            <tr><td>Airi Satou</td>\r\n                <td>Accountant</td>\r\n                <td>Tokyo</td>\r\n                <td>33</td>\r\n                <td>2008/11/28</td>\r\n                <td>$162,700</td></tr>\r\n            <tr><td>Brielle Williamson</td>\r\n                <td>Integration Specialist</td>\r\n                <td>New York</td>\r\n                <td>61</td>\r\n                <td>2012/12/02</td>\r\n                <td>$372,000</td></tr></tbody></table></div>");
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