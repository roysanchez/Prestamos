using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.TagHelpers
{
    [TargetElement("DatePicker", Attributes = ForAttributeName)]
    public class OfficeDateTimeTagHelper : TagHelper
    {
        private const string ForAttributeName = "pr-for";

        private readonly IFileProvider _wwwroot;
        private readonly string IdAttributeDotReplacement;

        public OfficeDateTimeTagHelper(IHostingEnvironment env, IOptions<MvcViewOptions> optionsAccessor)
        {
            _wwwroot = env.WebRootFileProvider;
            IdAttributeDotReplacement = optionsAccessor.Options.HtmlHelperOptions.IdAttributeDotReplacement;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var fullName = ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(For.Name);

            var tagBuilder = new TagBuilder("input");
            tagBuilder.AddCssClass("ms-TextField-field");
            tagBuilder.MergeAttribute("type", "text");
            tagBuilder.MergeAttribute("placeholder", "Select a date…");
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            tagBuilder.GenerateId(fullName, IdAttributeDotReplacement);

            var file = _wwwroot.GetFileInfo("templates/OfficeUIDatePicker.html");
            var stringBuilder = new StringBuilder();

            using (var readStream = file.CreateReadStream())
            using (var reader = new StreamReader(readStream, Encoding.UTF8))
            {
                //output.Content.Append(reader.ReadToEnd());
                stringBuilder.Append(reader.ReadToEnd());
            }
            var writer = new StringWriter();
            tagBuilder.WriteTo(writer, new HtmlEncoder());

            stringBuilder.Replace("{input}", writer.ToString());

            output.Content.Append(stringBuilder.ToString());
        }
    }
}
