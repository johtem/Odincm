#pragma checksum "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99031bececd86f333a804b3754a20eeaff5eb4eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(OdinCM.Pages.Articles.Pages_Articles_Details), @"mvc.1.0.razor-page", @"/Pages/Articles/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Articles/Details.cshtml", typeof(OdinCM.Pages.Articles.Pages_Articles_Details), @"./Articles/{slug?}")]
namespace OdinCM.Pages.Articles
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "./Articles/{slug?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99031bececd86f333a804b3754a20eeaff5eb4eb", @"/Pages/Articles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd880fa0487eb7006a1cdf74f02713ec932903c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Articles_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Articles"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Westwind.AspNetCore.Markdown.MarkdownTagHelper __Westwind_AspNetCore_Markdown_MarkdownTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
  
    var title = "Details";
    if (!string.IsNullOrEmpty(Model.Article.Topic))
    {
        title = Model.Article.Topic;
    }
    ViewData["Title"] = title;

#line default
#line hidden
            BeginContext(223, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(487, 16, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<h2>");
            EndContext();
            BeginContext(504, 19, false);
#line 27 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
Write(Model.Article.Topic);

#line default
#line hidden
            EndContext();
            BeginContext(523, 45, true);
            WriteLiteral("</h2>\r\n<h5>Last Published: <span data-value=\"");
            EndContext();
            BeginContext(569, 23, false);
#line 28 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                                 Write(Model.Article.Published);

#line default
#line hidden
            EndContext();
            BeginContext(592, 27, true);
            WriteLiteral("\" class=\"timeStampValueL\"> ");
            EndContext();
            BeginContext(620, 23, false);
#line 28 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                                                                                    Write(Model.Article.Published);

#line default
#line hidden
            EndContext();
            BeginContext(643, 48, true);
            WriteLiteral("</span></h5>\r\n<h5>View Count: <span data-value=\"");
            EndContext();
            BeginContext(692, 23, false);
#line 29 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                             Write(Model.Article.ViewCount);

#line default
#line hidden
            EndContext();
            BeginContext(715, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(718, 23, false);
#line 29 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                                                       Write(Model.Article.ViewCount);

#line default
#line hidden
            EndContext();
            BeginContext(741, 59, true);
            WriteLiteral("</span></h5>\r\n<h6>Estimated Reading Time (minutes): <span> ");
            EndContext();
            BeginContext(801, 40, false);
#line 30 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                                        Write(CalculateReadTime(Model.Article.Content));

#line default
#line hidden
            EndContext();
            BeginContext(841, 24, true);
            WriteLiteral("</span></h6>\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(865, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("markdown", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ae93a25ee6c41c7b2f18d1bf67e0c5e", async() => {
                BeginContext(876, 21, false);
#line 33 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
     Write(Model.Article.Content);

#line default
#line hidden
                EndContext();
            }
            );
            __Westwind_AspNetCore_Markdown_MarkdownTagHelper = CreateTagHelper<global::Westwind.AspNetCore.Markdown.MarkdownTagHelper>();
            __tagHelperExecutionContext.Add(__Westwind_AspNetCore_Markdown_MarkdownTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(908, 15, true);
            WriteLiteral("\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(923, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5161c27fc324d63941a80fff87ca7be", async() => {
                BeginContext(977, 4, true);
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
#line 36 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
                           WriteLiteral(Model.Article.Id);

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
            BeginContext(985, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 37 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
     if (Model.Article.Slug != "home-page")
    {
        

#line default
#line hidden
            BeginContext(1053, 2, true);
            WriteLiteral(" |");
            EndContext();
            BeginContext(1062, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1063, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2cda024fc064210a2a8fb056db2e35e", async() => {
                BeginContext(1084, 12, true);
                WriteLiteral("Back to Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 40 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(1109, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(1122, 98, false);
#line 44 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
Write(await Component.InvokeAsync("CreateComments", new Models.Comment { IdArticle = Model.Article.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1220, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1223, 67, false);
#line 45 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
Write(await Component.InvokeAsync("ListComments", Model.Article.Comments));

#line default
#line hidden
            EndContext();
            BeginContext(1290, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1312, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1319, 40, false);
#line 48 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
Write(await Html.PartialAsync("_EditorScript"));

#line default
#line hidden
                EndContext();
                BeginContext(1359, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(1364, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(1383, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1390, 39, false);
#line 52 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
Write(await Html.PartialAsync("_EditorStyle"));

#line default
#line hidden
                EndContext();
                BeginContext(1429, 310, true);
                WriteLiteral(@"
    <style>
        .labelDisplayName {
            font-weight: bold;
            text-transform: capitalize;
            color: #007bb8 !important;
        }

        .labelCommentedOn {
            color: #A6A6A6;
            font-size: 10px;
            height: 10px;
        }
    </style>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
#line 13 "C:\Users\790021957\Documents\Visual Studio 2017\Projects\OdinCM\OdinCM\Pages\Articles\Details.cshtml"
           
    public int CalculateReadTime(string content)
    {
        const decimal wpm = 275.0m;  // Average speed is 275 word per minute
        var wordCount = content.Split(' ').Length;
        return (int)Math.Ceiling(wordCount / wpm);
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
