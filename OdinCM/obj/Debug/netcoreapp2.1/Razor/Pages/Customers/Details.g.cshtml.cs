#pragma checksum "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "128611e08b9efa370f366c046f57d92d9075ff70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(OdinCM.Pages.Customers.Pages_Customers_Details), @"mvc.1.0.razor-page", @"/Pages/Customers/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Customers/Details.cshtml", typeof(OdinCM.Pages.Customers.Pages_Customers_Details), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"128611e08b9efa370f366c046f57d92d9075ff70", @"/Pages/Customers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd880fa0487eb7006a1cdf74f02713ec932903c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Customers_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(96, 122, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Customer</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(219, 57, false);
#line 15 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(276, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(320, 53, false);
#line 18 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
       Write(Html.DisplayFor(model => model.Customer.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(373, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(417, 54, false);
#line 21 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(471, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <span data-value=\"");
            EndContext();
            BeginContext(533, 50, false);
#line 24 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
                         Write(Html.DisplayFor(model => model.Customer.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(583, 26, true);
            WriteLiteral("\" class=\"timeStampValue\"> ");
            EndContext();
            BeginContext(610, 50, false);
#line 24 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
                                                                                                      Write(Html.DisplayFor(model => model.Customer.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(660, 50, true);
            WriteLiteral("</span>\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(711, 54, false);
#line 27 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.UpdatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(765, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <span data-value=\"");
            EndContext();
            BeginContext(827, 50, false);
#line 30 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
                         Write(Html.DisplayFor(model => model.Customer.UpdatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(877, 26, true);
            WriteLiteral("\" class=\"timeStampValue\"> ");
            EndContext();
            BeginContext(904, 50, false);
#line 30 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
                                                                                                      Write(Html.DisplayFor(model => model.Customer.UpdatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(954, 54, true);
            WriteLiteral("</span>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1008, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d497542f3fd24b58a752bfcafe8aa7f3", async() => {
                BeginContext(1071, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 35 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Customers\Details.cshtml"
                           WriteLiteral(Model.Customer.CustomerID);

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
            BeginContext(1079, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1087, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "501306d83e5b4852982ed454178514d5", async() => {
                BeginContext(1109, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1125, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OdinCM.Pages.Customers.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OdinCM.Pages.Customers.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OdinCM.Pages.Customers.DetailsModel>)PageContext?.ViewData;
        public OdinCM.Pages.Customers.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
