#pragma checksum "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b2bd29b60d16c0ead21243e9271897529970604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\_ViewImports.cshtml"
using EmarketApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\_ViewImports.cshtml"
using EmarketApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
using EmarketApp.Core.Application.ViewModels.Anuncios;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b2bd29b60d16c0ead21243e9271897529970604", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ea73ee38758afa72f80d692ec3a5a45eae5997f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SaveAnuncioVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info btn-sm float-end mx-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid my-5 text-white"">
    <div class=""row"">

        <div class=""col-md-12 col-sm-6 mt-5"">
            <div class=""card bg-transparent text-white text-center"">
                <div class=""card-title"">
                    <h3 class=""card-text fw-bold "">Detalles del anuncio</h3>
                </div>
            </div>
        </div>

");
            WriteLiteral(@"        <div class=""row"">
                        
            <div class=""col-md-6 mt-3"">

                <div id=""DetailsCarousel"" class=""carousel slide w-100"" data-ride=""carousel"">
                    <div class=""carousel-inner animate__animated animate__fadeIn"">

                        <div class=""carousel-item active"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 894, "\"", 915, 1);
#nullable restore
#line 30 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 900, Model.ImgFile1, 900, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""rounded mx-auto d-block text-white"" alt=""no hay imagen disponible""
                                 height=""500""
                                 width=""600"">
                        </div>

                        <div class=""carousel-item"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 1205, "\"", 1226, 1);
#nullable restore
#line 36 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1211, Model.ImgFile2, 1211, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""rounded mx-auto d-block text-white"" alt=""no hay imagen disponible""
                                 height=""500""
                                 width=""600"">
                        </div>

                        <div class=""carousel-item"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 1516, "\"", 1537, 1);
#nullable restore
#line 42 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1522, Model.ImgFile3, 1522, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""rounded mx-auto d-block text-white"" alt=""no hay imagen disponible""
                                 height=""500""
                                 width=""600"">
                        </div>

                        <div class=""carousel-item"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 1827, "\"", 1848, 1);
#nullable restore
#line 48 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1833, Model.ImgFile4, 1833, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""rounded mx-auto d-block text-white"" alt=""no hay imagen disponible""
                                 height=""500""
                                 width=""600"">
                        </div>

                    </div>

                    <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#DetailsCarousel"" data-bs-slide=""prev"">
                        <span class=""carousel-control-prev-icon""></span>
                        <span class=""visually-hidden"">Previous</span>
                    </button>

                    <button class=""carousel-control-next"" type=""button"" data-bs-target=""#DetailsCarousel"" data-bs-slide=""next"">
                        <span class=""carousel-control-next-icon""></span>
                        <span class=""visually-hidden"">Next</span>
                    </button>
                </div>

            </div>

");
            WriteLiteral("\r\n            <div class=\"col-md-6 mt-3\">\r\n\r\n                <div class=\"card bg-transparent\">\r\n\r\n                    <div class=\"card-body\">\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Nombre:</strong> ");
#nullable restore
#line 76 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Precio:</strong> RD$ ");
#nullable restore
#line 78 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Categoria:</strong> ");
#nullable restore
#line 80 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                          Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\">\r\n                            <strong>Descripcion:</strong> ");
#nullable restore
#line 83 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                     Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Fecha de publicacion:</strong> ");
#nullable restore
#line 86 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                                     Write(Model.Created.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Autor: </strong>  ");
#nullable restore
#line 88 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                        Write(Model.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Correo: </strong>  ");
#nullable restore
#line 90 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                         Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                        <p class=\"card-text fs-4\"> <strong>Telefono:   </strong> ");
#nullable restore
#line 92 "C:\Users\Randy\Desktop\Chan\Programacion 3\EmarketApp\EmarketApp\Views\Home\Details.cshtml"
                                                                            Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n                    </div>\r\n\r\n\r\n                    <div class=\"mb-2\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b2bd29b60d16c0ead21243e927189752997060412253", async() => {
                WriteLiteral(" volver atras ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n            \r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SaveAnuncioVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
