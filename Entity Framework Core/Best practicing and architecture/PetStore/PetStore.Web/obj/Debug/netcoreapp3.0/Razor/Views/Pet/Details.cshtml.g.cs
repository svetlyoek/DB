#pragma checksum "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ae26c28accbbe3c998d0835746e145258ce96e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pet_Details), @"mvc.1.0.view", @"/Views/Pet/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ae26c28accbbe3c998d0835746e145258ce96e2", @"/Views/Pet/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cc2a2f665438786e1fb7c07e65d79af43c6b029", @"/Views/_ViewImports.cshtml")]
    public class Views_Pet_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PetStore.Web.ViewModels.Pet.DetailsPetModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt type=\"date\" class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd type=\"date\" class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BreedId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.BreedId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Breed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Breed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 67 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 70 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 73 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OrderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 76 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.OrderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 79 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Order));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 82 "E:\Soft Uni\CODES\DB\Entity Framework Core\Best practicing and architecture\PetStore\PetStore.Web\Views\Pet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Order));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ae26c28accbbe3c998d0835746e145258ce96e213210", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PetStore.Web.ViewModels.Pet.DetailsPetModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
