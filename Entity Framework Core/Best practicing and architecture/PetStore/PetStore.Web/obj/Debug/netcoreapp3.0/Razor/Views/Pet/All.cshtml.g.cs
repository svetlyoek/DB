#pragma checksum "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cbd4e338bca2c5480589fa5d688a09013df76a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pet_All), @"mvc.1.0.view", @"/Views/Pet/All.cshtml")]
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
#line 1 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Services.Models.Pet;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cbd4e338bca2c5480589fa5d688a09013df76a1", @"/Views/Pet/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cc2a2f665438786e1fb7c07e65d79af43c6b029", @"/Views/_ViewImports.cshtml")]
    public class Views_Pet_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PetListingModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>All pets</h1>\r\n\r\n<table class=\"table table-bordered table-striped\">\r\n    <tr>\r\n        <th>\r\n            Id\r\n        </th>\r\n        <th>\r\n            Name\r\n        </th>\r\n        <th>\r\n            Price\r\n        </th>\r\n    </tr>\r\n");
#nullable restore
#line 18 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml"
     foreach (var pet in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 22 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml"
           Write(pet.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 25 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml"
           Write(pet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml"
           Write(pet.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 31 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\All.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PetListingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
