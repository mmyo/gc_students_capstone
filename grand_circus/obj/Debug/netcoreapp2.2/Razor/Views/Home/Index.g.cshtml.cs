#pragma checksum "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04a26e479c4bea4430e930d482f977b83b4ef8bb"
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
#line 1 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\_ViewImports.cshtml"
using grand_circus;

#line default
#line hidden
#line 2 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\_ViewImports.cshtml"
using grand_circus.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04a26e479c4bea4430e930d482f977b83b4ef8bb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"489536f0b5cd8eee5d25a5687c25654e538380ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(74, 225, true);
            WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Welcome</h1>\r\n        <h4>Select User</h4>\r\n    </div>\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(300, 40, false);
#line 16 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(340, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(408, 45, false);
#line 19 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(453, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(521, 44, false);
#line 22 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(565, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 28 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(728, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(801, 39, false);
#line 32 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(840, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(920, 44, false);
#line 35 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(964, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1044, 43, false);
#line 38 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 81, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        ");
            EndContext();
            BeginContext(1169, 74, false);
#line 42 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
                   Write(Html.ActionLink("Select User", "SetUserSession", new { id = item.UserId }));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 45 "C:\Users\Shusui\source\repos\gc_students_capstone\grand_circus\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1310, 30, true);
            WriteLiteral("        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
