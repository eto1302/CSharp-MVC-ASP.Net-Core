#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b875c3a99842f5572333b015b56a3cd841574058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_All), @"mvc.1.0.view", @"/Views/Events/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/All.cshtml", typeof(AspNetCore.Views_Events_All))]
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
#line 1 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
using Eventures.Web.Models;

#line default
#line hidden
#line 2 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
using X.PagedList;

#line default
#line hidden
#line 3 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b875c3a99842f5572333b015b56a3cd841574058", @"/Views/Events/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a955b74d506cfc9fe1d131dcd867512aad58ad1", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<EventListingViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(129, 412, true);
            WriteLiteral(@"<h1 class=""text-center"">All Events</h1>
<hr class=""eventures-bg-color hr-2 w-75"" />
<table class=""table w-75 mx-auto table-hover border-top-0"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Start</th>
            <th scope=""col"">End</th>
            <th scope=""col"">Action</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 22 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
         for (int i = 0; i < @Model.Count; i++)
        {

#line default
#line hidden
            BeginContext(601, 50, true);
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
            EndContext();
            BeginContext(653, 5, false);
#line 25 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
                            Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(659, 27, true);
            WriteLiteral("</th>\r\n                <td>");
            EndContext();
            BeginContext(687, 13, false);
#line 26 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
               Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(700, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(728, 49, false);
#line 27 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
               Write(Model[i].StartDate.ToString("dd-MMM-yy hh-mm-ss"));

#line default
#line hidden
            EndContext();
            BeginContext(777, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(805, 47, false);
#line 28 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
               Write(Model[i].EndDate.ToString("dd-MMM-yy hh-mm-ss"));

#line default
#line hidden
            EndContext();
            BeginContext(852, 51, true);
            WriteLiteral("</td>\r\n                <td>\r\n\r\n                    ");
            EndContext();
            BeginContext(904, 170, false);
#line 31 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
               Write(await Html.PartialAsync("_OrderEventPartial", new OrderCreateBindingModel()
                    {
                        EventId = @Model[i].Id
                    }));

#line default
#line hidden
            EndContext();
            BeginContext(1074, 46, true);
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 38 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
        }

#line default
#line hidden
            BeginContext(1131, 78, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<ul class=\"pagination justify-content-center\">\r\n    ");
            EndContext();
            BeginContext(1210, 79, false);
#line 43 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\CSharp-MVC-ASP.Net-Core\Eventures\Eventures\Views\Events\All.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("All", new { page })));

#line default
#line hidden
            EndContext();
            BeginContext(1289, 58, true);
            WriteLiteral("\r\n</ul>\r\n<hr class=\"eventures-bg-color hr-2 w-75\" />\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<EventListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
