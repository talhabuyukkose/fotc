#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7986dfe4ebe812e264bbfe0c36013fc06fb85df7"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/note/notes")]
    public partial class Notes : Microsoft.AspNetCore.Components.ComponentBase
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
            __Blazor.FileOnTheCloud.Client.Pages.Note.Notes.TypeInference.CreateMudTable_0(__builder, 4, 5, "dataTableWrapper", 6, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                         Color.Secondary

#line default
#line hidden
#nullable disable
            , 7, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                  savedFiles

#line default
#line hidden
#nullable disable
            , 8, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                     false

#line default
#line hidden
#nullable disable
            , 9, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                   true

#line default
#line hidden
#nullable disable
            , 10, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                                   false

#line default
#line hidden
#nullable disable
            , 11, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                                                   false

#line default
#line hidden
#nullable disable
            , 12, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                                                                  new Func<FileOnTheCloud.Shared.DbModel.SavedFile,bool>(FilterFuncSavedFile)

#line default
#line hidden
#nullable disable
            , 13, 
#nullable restore
#line 10 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                                                                                                                                                                   selectedItemSavedFile

#line default
#line hidden
#nullable disable
            , 14, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => selectedItemSavedFile = __value, selectedItemSavedFile)), 15, (__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudText>(16);
                __builder2.AddAttribute(17, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 12 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                       Typo.h6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(19, "DOSYA YÜKLEME GEÇMİŞİ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudSpacer>(21);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n        ");
                __Blazor.FileOnTheCloud.Client.Pages.Note.Notes.TypeInference.CreateMudTextField_1(__builder2, 23, 24, "Ara", 25, 
#nullable restore
#line 14 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                       Adornment.Start

#line default
#line hidden
#nullable disable
                , 26, 
#nullable restore
#line 14 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                        Icons.Material.Filled.Search

#line default
#line hidden
#nullable disable
                , 27, 
#nullable restore
#line 14 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                                                                                                                                Size.Medium

#line default
#line hidden
#nullable disable
                , 28, "mt-0", 29, 
#nullable restore
#line 14 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                   searchStringSavedFile

#line default
#line hidden
#nullable disable
                , 30, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => searchStringSavedFile = __value, searchStringSavedFile)));
            }
            , 31, (__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudTh>(32);
                __builder2.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __Blazor.FileOnTheCloud.Client.Pages.Note.Notes.TypeInference.CreateMudTableSortLabel_2(__builder3, 34, 35, 
#nullable restore
#line 17 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                          new Func<FileOnTheCloud.Shared.DbModel.SavedFile, object>(x=>savedFiles.IndexOf(x))

#line default
#line hidden
#nullable disable
                    , 36, (__builder4) => {
                        __builder4.AddContent(37, "SIRA");
                    }
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(38, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(39);
                __builder2.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(41, "BÖLÜM");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(43);
                __builder2.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(45, "SINIF");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(47);
                __builder2.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(49, "DÖNEM");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(50, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(51);
                __builder2.AddAttribute(52, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(53, "KATEGORİ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(54, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(55);
                __builder2.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(57, "DOSYA İSMİ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(58, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(59);
                __builder2.AddAttribute(60, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(61, "BOYUT");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(62, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(63);
                __builder2.AddAttribute(64, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(65, "YÜKLENME TARİHİ");
                }
                ));
                __builder2.CloseComponent();
            }
            , 66, (context) => (__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudTd>(67);
                __builder2.AddAttribute(68, "DataLabel", "SIRA");
                __builder2.AddAttribute(69, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 31 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(70, Convert.ToInt32(savedFiles.IndexOf(context) + 1));

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(71, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(72);
                __builder2.AddAttribute(73, "DataLabel", "BÖLÜM");
                __builder2.AddAttribute(74, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 32 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(75, context.department);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(76, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(77);
                __builder2.AddAttribute(78, "DataLabel", "SINIF");
                __builder2.AddAttribute(79, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 33 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(80, context.grade);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(81, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(82);
                __builder2.AddAttribute(83, "DataLabel", "DÖNEM");
                __builder2.AddAttribute(84, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 34 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(85, context.semester);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(86, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(87);
                __builder2.AddAttribute(88, "DataLabel", "KATEGORİ");
                __builder2.AddAttribute(89, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 35 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(90, context.midtermandfinal);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(91, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(92);
                __builder2.AddAttribute(93, "DataLabel", "DOSYA İSMİ");
                __builder2.AddAttribute(94, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 36 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(95, string.Concat(context.filename+"."+context.fileextension));

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(96, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(97);
                __builder2.AddAttribute(98, "DataLabel", "BOYUT");
                __builder2.AddAttribute(99, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 37 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(100, context.filesize);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(101, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(102);
                __builder2.AddAttribute(103, "DataLabel", "YÜKLENME TARİHİ");
                __builder2.AddAttribute(104, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 38 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(105, context.createdate);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            , 106, (__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudTablePager>(107);
                __builder2.AddAttribute(108, "RowsPerPageString", "Gösterilen Kayıt");
                __builder2.CloseComponent();
            }
            );
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
namespace __Blazor.FileOnTheCloud.Client.Pages.Note.Notes
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMudTable_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::MudBlazor.Color __arg1, int __seq2, global::System.Collections.Generic.IEnumerable<T> __arg2, int __seq3, global::System.Boolean __arg3, int __seq4, global::System.Boolean __arg4, int __seq5, global::System.Boolean __arg5, int __seq6, global::System.Boolean __arg6, int __seq7, global::System.Func<T, global::System.Boolean> __arg7, int __seq8, T __arg8, int __seq9, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg9, int __seq10, global::Microsoft.AspNetCore.Components.RenderFragment __arg10, int __seq11, global::Microsoft.AspNetCore.Components.RenderFragment __arg11, int __seq12, global::Microsoft.AspNetCore.Components.RenderFragment<T> __arg12, int __seq13, global::Microsoft.AspNetCore.Components.RenderFragment __arg13)
        {
        __builder.OpenComponent<global::MudBlazor.MudTable<T>>(seq);
        __builder.AddAttribute(__seq0, "Class", __arg0);
        __builder.AddAttribute(__seq1, "LoadingProgressColor", __arg1);
        __builder.AddAttribute(__seq2, "Items", __arg2);
        __builder.AddAttribute(__seq3, "Dense", __arg3);
        __builder.AddAttribute(__seq4, "Hover", __arg4);
        __builder.AddAttribute(__seq5, "Bordered", __arg5);
        __builder.AddAttribute(__seq6, "Striped", __arg6);
        __builder.AddAttribute(__seq7, "Filter", __arg7);
        __builder.AddAttribute(__seq8, "SelectedItem", __arg8);
        __builder.AddAttribute(__seq9, "SelectedItemChanged", __arg9);
        __builder.AddAttribute(__seq10, "ToolBarContent", __arg10);
        __builder.AddAttribute(__seq11, "HeaderContent", __arg11);
        __builder.AddAttribute(__seq12, "RowTemplate", __arg12);
        __builder.AddAttribute(__seq13, "PagerContent", __arg13);
        __builder.CloseComponent();
        }
        public static void CreateMudTextField_1<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::MudBlazor.Adornment __arg1, int __seq2, global::System.String __arg2, int __seq3, global::MudBlazor.Size __arg3, int __seq4, global::System.String __arg4, int __seq5, T __arg5, int __seq6, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg6)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Placeholder", __arg0);
        __builder.AddAttribute(__seq1, "Adornment", __arg1);
        __builder.AddAttribute(__seq2, "AdornmentIcon", __arg2);
        __builder.AddAttribute(__seq3, "IconSize", __arg3);
        __builder.AddAttribute(__seq4, "Class", __arg4);
        __builder.AddAttribute(__seq5, "Value", __arg5);
        __builder.AddAttribute(__seq6, "ValueChanged", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateMudTableSortLabel_2<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Func<T, global::System.Object> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::MudBlazor.MudTableSortLabel<T>>(seq);
        __builder.AddAttribute(__seq0, "SortBy", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
