#pragma checksum "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7edbaebdcfa7264ee7fbf43b6dec883090f62d24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Complaint_Index), @"mvc.1.0.view", @"/Views/Complaint/Index.cshtml")]
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
#line 1 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\_ViewImports.cshtml"
using ManagerApartmentProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\_ViewImports.cshtml"
using ManagerApartmentProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7edbaebdcfa7264ee7fbf43b6dec883090f62d24", @"/Views/Complaint/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d06fe61c9553ad1f410f59e9cc185e8be83918", @"/Views/_ViewImports.cshtml")]
    public class Views_Complaint_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Complaint>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm btn-small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm btn-small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/fontawesome-5.15.3/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
 if (User.IsInRole("Employee")||User.IsInRole("Tenant")){

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7edbaebdcfa7264ee7fbf43b6dec883090f62d246377", async() => {
                WriteLiteral("Create");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-striped\">\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 8 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                 if(User.IsInRole("Admin")){                

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th> ");
#nullable restore
#line 9 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                    Write(Html.DisplayNameFor((model) => model.type));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n");
#nullable restore
#line 10 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th> ");
#nullable restore
#line 11 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayNameFor((model) => model.creator));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n                <th> ");
#nullable restore
#line 12 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayNameFor((model) => model.title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n                <th> ");
#nullable restore
#line 13 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayNameFor((model) => model.dateRelease));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n\r\n                <th> Action </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 19 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
              
            string[] tmp = {"Chờ phê duyệt", "Đang xử lý", "Hoàn thành"};
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
             foreach (var item in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
#nullable restore
#line 24 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                 if(User.IsInRole("Admin")){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td> ");
#nullable restore
#line 25 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                    Write(Html.DisplayFor(model => item.type));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n");
#nullable restore
#line 26 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td> ");
#nullable restore
#line 27 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayFor(model => item.creator));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 28 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayFor(model => item.title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n\r\n                <td> ");
#nullable restore
#line 31 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                Write(Html.DisplayFor(model => item.dateRelease));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7edbaebdcfa7264ee7fbf43b6dec883090f62d2412440", async() => {
                WriteLiteral("\r\n                        <i class=\"fas fa-eye\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                                             WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                     if (User.IsInRole("Employee")||User.IsInRole("Tenant")){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7edbaebdcfa7264ee7fbf43b6dec883090f62d2415126", async() => {
                WriteLiteral("\r\n                        <i class=\"fas fa-trash\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                                             WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 45 "C:\Users\badee\OneDrive\Máy tính\New folder (5)\cnpm_xaydungchungcu\ManagerApartmentProject\Views\Complaint\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n");
            WriteLiteral("\r\n");
            DefineSection("Css", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7edbaebdcfa7264ee7fbf43b6dec883090f62d2418201", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <style>
            .btn-small {
                padding: 0.3rem 0.3em 0.3em 0.5em;
            }

            tbody {
                max-height: 55vh;
                overflow: auto;
            }

                tbody ::-webkit-scrollbar {
                    width: 5px;
                }

                tbody::-webkit-scrollbar-track {
                    background: transparent !important;
                }

                tbody::-webkit-scrollbar-thumb:hover {
                    background-color: rgb(180, 179, 179);
                }
        </style>
    ");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Complaint>> Html { get; private set; }
    }
}
#pragma warning restore 1591
