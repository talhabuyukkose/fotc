#pragma checksum "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4253b281ab97dfb5ab8bac9317c7a92f346aa10"
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
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(32);
                __builder2.AddAttribute(33, "Roles", "admin");
                __builder2.AddAttribute(34, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudTh>(35);
                    __builder3.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(37, "#");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(38, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(39);
                __builder2.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __Blazor.FileOnTheCloud.Client.Pages.Note.Notes.TypeInference.CreateMudTableSortLabel_2(__builder3, 41, 42, 
#nullable restore
#line 22 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                          new Func<FileOnTheCloud.Shared.DbModel.SavedFile, object>(x=>savedFiles.IndexOf(x))

#line default
#line hidden
#nullable disable
                    , 43, (__builder4) => {
                        __builder4.AddContent(44, "SIRA");
                    }
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(45, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(46);
                __builder2.AddAttribute(47, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(48, "BÖLÜM");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(49, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(50);
                __builder2.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(52, "SINIF");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(54);
                __builder2.AddAttribute(55, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(56, "DÖNEM");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(57, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(58);
                __builder2.AddAttribute(59, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(60, "KATEGORİ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(61, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(62);
                __builder2.AddAttribute(63, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(64, "DOSYA İSMİ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(65, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(66);
                __builder2.AddAttribute(67, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(68, "BOYUT");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(69, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTh>(70);
                __builder2.AddAttribute(71, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(72, "YÜKLENME TARİHİ");
                }
                ));
                __builder2.CloseComponent();
            }
            , 73, (note) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(74);
                __builder2.AddAttribute(75, "Roles", "admin");
                __builder2.AddAttribute(76, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudTd>(77);
                    __builder3.AddAttribute(78, "DataLabel", "#");
                    __builder3.AddAttribute(79, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(80, "button");
                        __builder4.AddAttribute(81, "class", "userlistbutton");
                        __builder4.AddAttribute(82, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
                                                             ()=>DeleteNote(note)

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddMarkupContent(83, "SİL");
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(84, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(85);
                __builder2.AddAttribute(86, "DataLabel", "SIRA");
                __builder2.AddAttribute(87, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 41 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(88, Convert.ToInt32(savedFiles.IndexOf(note) + 1));

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(89, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(90);
                __builder2.AddAttribute(91, "DataLabel", "BÖLÜM");
                __builder2.AddAttribute(92, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 42 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(93, note.department);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(94, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(95);
                __builder2.AddAttribute(96, "DataLabel", "SINIF");
                __builder2.AddAttribute(97, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 43 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(98, note.grade);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(99, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(100);
                __builder2.AddAttribute(101, "DataLabel", "DÖNEM");
                __builder2.AddAttribute(102, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 44 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(103, note.semester);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(104, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(105);
                __builder2.AddAttribute(106, "DataLabel", "KATEGORİ");
                __builder2.AddAttribute(107, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 45 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(108, note.midtermandfinal);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(109, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(110);
                __builder2.AddAttribute(111, "DataLabel", "DOSYA İSMİ");
                __builder2.AddAttribute(112, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 46 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(113, note.filename);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(114, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(115);
                __builder2.AddAttribute(116, "DataLabel", "BOYUT");
                __builder2.AddAttribute(117, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 47 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(118, note.filesize);

#line default
#line hidden
#nullable disable
                    __builder3.AddContent(119, " MB");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(120, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudTd>(121);
                __builder2.AddAttribute(122, "DataLabel", "YÜKLENME TARİHİ");
                __builder2.AddAttribute(123, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 48 "C:\Users\talha\source\repos\FTC\FileOnTheCloud\Client\Pages\Note\Notes.razor"
__builder3.AddContent(124, note.createdate);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            , 125, (__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudTablePager>(126);
                __builder2.AddAttribute(127, "RowsPerPageString", "Gösterilen Kayıt");
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
