#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bea5bf6b70ff4a4fd60f4f360be085680036c37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_MyEvents), @"mvc.1.0.view", @"/Views/Events/MyEvents.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/MyEvents.cshtml", typeof(AspNetCore.Views_Events_MyEvents))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bea5bf6b70ff4a4fd60f4f360be085680036c37", @"/Views/Events/MyEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a955b74d506cfc9fe1d131dcd867512aad58ad1", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_MyEvents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eventures.Web.Models.OrderListingViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
  
    int i = 0;

#line default
#line hidden
            BeginContext(87, 414, true);
            WriteLiteral(@"
<h1 class=""text-center"">My Events</h1>
<hr class=""eventures-bg-color hr-2 w-75"" />
<table class=""table w-75 mx-auto table-hover border-top-0"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Start</th>
            <th scope=""col"">End</th>
            <th scope=""col"">Tickets</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 20 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
         foreach(var m in @Model)
        {

#line default
#line hidden
            BeginContext(547, 50, true);
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
            EndContext();
            BeginContext(599, 3, false);
#line 23 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
                            Write(i++);

#line default
#line hidden
            EndContext();
            BeginContext(603, 27, true);
            WriteLiteral("</th>\r\n                <td>");
            EndContext();
            BeginContext(631, 12, false);
#line 24 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
               Write(m.Event.Name);

#line default
#line hidden
            EndContext();
            BeginContext(643, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(671, 47, false);
#line 25 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
               Write(m.Event.StartDate.ToString("dd-MM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(718, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(746, 45, false);
#line 26 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
               Write(m.Event.EndDate.ToString("dd-MM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(791, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(819, 14, false);
#line 27 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
               Write(m.TicketsCount);

#line default
#line hidden
            EndContext();
            BeginContext(833, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\MyEvents.cshtml"
        }

#line default
#line hidden
            BeginContext(870, 71, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<hr class=\"eventures-bg-color hr-2 w-75\" />\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eventures.Web.Models.OrderListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
