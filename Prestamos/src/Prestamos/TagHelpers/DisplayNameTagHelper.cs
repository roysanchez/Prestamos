using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Prestamos.TagHelpers
{
    [TargetElement("th", Attributes = DisplayNameAttributeName)]
    public class DisplayNameTagHelper : TagHelper
    {
        private const string DisplayNameAttributeName = "pr-display-name-for";

        [HtmlAttributeName(DisplayNameAttributeName)]
        public string DisplayName { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);

        }
    }
}
