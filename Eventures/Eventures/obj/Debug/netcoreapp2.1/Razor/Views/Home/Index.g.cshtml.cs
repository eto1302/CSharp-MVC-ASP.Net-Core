#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceee9f8a43524d9be8765285c6d238042b5d116a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\_ViewImports.cshtml"
using Eventures;

#line default
#line hidden
#line 2 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\_ViewImports.cshtml"
using Eventures.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceee9f8a43524d9be8765285c6d238042b5d116a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a955b74d506cfc9fe1d131dcd867512aad58ad1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link-white text-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
 if (!User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(43, 169, true);
            WriteLiteral("    <div class=\"jumbotron mt-3 eventures-bg-color\">\r\n        <h1>Eventures - The best ticket service in the world</h1>\r\n        <hr class=\"bg-dark hr-2\" />\r\n        <h3>");
            EndContext();
            BeginContext(212, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94231aa795df43c59ce7147458e3a766", async() => {
                BeginContext(297, 5, true);
                WriteLiteral("Login");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(306, 40, true);
            WriteLiteral(" to start \"eventing\".</h3>\r\n        <h3>");
            EndContext();
            BeginContext(346, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639dcbe0c27448629f55471112b13b94", async() => {
                BeginContext(434, 8, true);
                WriteLiteral("Register");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(446, 49, true);
            WriteLiteral(" if you don\'t have an account.</h3>\r\n    </div>\r\n");
            EndContext();
#line 10 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(498, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{
    if (User.IsInRole("Admin"))
    {

#line default
#line hidden
            BeginContext(580, 231, true);
            WriteLiteral("        <div class=\"jumbotron mt-3 eventures-bg-color text-center\">\r\n            <h1>Welcome, Administrator - Admin!</h1>\r\n            <hr class=\"hr-2\" />\r\n            <h3 style=\"color: grey\">Enjoy your work.</h3>\r\n        </div>\r\n");
            EndContext();
#line 21 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
    }
    else if (User.IsInRole("User"))
    {

#line default
#line hidden
            BeginContext(862, 94, true);
            WriteLiteral("        <div class=\"jumbotron mt-3 eventures-bg-color text-center\">\r\n            <h1>Welcome, ");
            EndContext();
            BeginContext(957, 18, false);
#line 25 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
                    Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(975, 143, true);
            WriteLiteral("!</h1>\r\n            <hr class=\"hr-2\" />\r\n            <h3 style=\"color: grey\">Eventures wishes you an exciting experience</h3>\r\n        </div>\r\n");
            EndContext();
#line 29 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Home\Index.cshtml"
    }
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
