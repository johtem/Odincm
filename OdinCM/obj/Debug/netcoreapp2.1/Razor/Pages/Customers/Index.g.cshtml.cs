#pragma checksum "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2693d6927099a6038f0c1c85e632b5edf321b4dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(OdinCM.Pages.Customers.Pages_Customers_Index), @"mvc.1.0.razor-page", @"/Pages/Customers/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Customers/Index.cshtml", typeof(OdinCM.Pages.Customers.Pages_Customers_Index), null)]
namespace OdinCM.Pages.Customers
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\_ViewImports.cshtml"
using OdinCM;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2693d6927099a6038f0c1c85e632b5edf321b4dc", @"/Pages/Customers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd880fa0487eb7006a1cdf74f02713ec932903c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Customers_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page", new global::Microsoft.AspNetCore.Html.HtmlString("index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::OdinCM.TagHelpers.PagerTagHelper __OdinCM_TagHelpers_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
  
    ViewData["Title"] = "Customers";

#line default
#line hidden
            BeginContext(96, 33, true);
            WriteLiteral("\r\n<h2>Customers</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(129, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0cc2aed75a546d5a25852c335ac9a6b", async() => {
                BeginContext(150, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(164, 10, true);
            WriteLiteral("\r\n</p>\r\n\r\n");
            EndContext();
            BeginContext(174, 177, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e5c5d3dd65d4a17b17356a8cc7281eb", async() => {
                BeginContext(180, 67, true);
                WriteLiteral("\r\n    <p>\r\n        Customer: <input type=\"text\" name=\"SearchString\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 247, "\"", 280, 1);
#line 16 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
WriteAttributeValue("", 255, ViewData["SearchString"], 255, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(281, 63, true);
                WriteLiteral(" />\r\n        <input type=\"submit\" value=\"Filter\" />\r\n    </p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(351, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(357, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66a2a0cbbb824c4f9fd8b26199ab445b", async() => {
            }
            );
            __OdinCM_TagHelpers_PagerTagHelper = CreateTagHelper<global::OdinCM.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__OdinCM_TagHelpers_PagerTagHelper);
#line 22 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
__OdinCM_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __OdinCM_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 22 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
__OdinCM_TagHelpers_PagerTagHelper.CurrentPage = Model.PageNumber;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __OdinCM_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(448, 109, true);
            WriteLiteral("\r\n\r\n<table class=\"table table-sm table-hover\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(558, 61, false);
#line 28 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Customers[0].CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(619, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(675, 58, false);
#line 31 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Customers[0].CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(733, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(789, 58, false);
#line 34 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Customers[0].UpdatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(847, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
         foreach (var item in Model.Customers)
        {

#line default
#line hidden
            BeginContext(992, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1053, 47, false);
#line 44 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(1100, 85, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <span data-value=\"");
            EndContext();
            BeginContext(1186, 14, false);
#line 47 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                 Write(item.CreatedAt);

#line default
#line hidden
            EndContext();
            BeginContext(1200, 26, true);
            WriteLiteral("\" class=\"timeStampValue\"> ");
            EndContext();
            BeginContext(1227, 14, false);
#line 47 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                                                          Write(item.CreatedAt);

#line default
#line hidden
            EndContext();
            BeginContext(1241, 94, true);
            WriteLiteral("</span>\r\n\r\n                </td>\r\n                <td>\r\n                    <span data-value=\"");
            EndContext();
            BeginContext(1336, 14, false);
#line 51 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                 Write(item.UpdatedAt);

#line default
#line hidden
            EndContext();
            BeginContext(1350, 26, true);
            WriteLiteral("\" class=\"timeStampValue\"> ");
            EndContext();
            BeginContext(1377, 14, false);
#line 51 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                                                          Write(item.UpdatedAt);

#line default
#line hidden
            EndContext();
            BeginContext(1391, 74, true);
            WriteLiteral("</span>\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1465, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94ccf6d7f25e42c8bcea22c8ced2ced0", async() => {
                BeginContext(1518, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                           WriteLiteral(item.CustomerID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1526, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1550, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d281b93ab314801b493d7ce8d29d68e", async() => {
                BeginContext(1606, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                              WriteLiteral(item.CustomerID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1617, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1641, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c145f0bc1f54c5f91cc6af146beafe8", async() => {
                BeginContext(1696, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
                                             WriteLiteral(item.CustomerID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1706, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 59 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1761, 29, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<!-- ");
            EndContext();
            BeginContext(1791, 21, false);
#line 62 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Index.cshtml"
Write(TimeZoneInfo.Local.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1812, 59, true);
            WriteLiteral("\r\n// Intl.DateTimeFormat().resolvedOptions().timeZone -->\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OdinCM.Pages.Customers.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OdinCM.Pages.Customers.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OdinCM.Pages.Customers.IndexModel>)PageContext?.ViewData;
        public OdinCM.Pages.Customers.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
