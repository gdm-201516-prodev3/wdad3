using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Web.Helpers
{
    [TargetElement("ajaxpager", Attributes = "current-page, total-pages, search-form-target, update-link, update-target")]
    public class AjaxPagerTagHelper : TagHelper
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchFormTarget { get; set; }
        public string UpdateLink { get; set; }
        public string UpdateTarget { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var pre = string.Format(
                "<ul class=\"pagination\" search-form-target=\"{0}\" update-link=\"{1}\" update-target=\"{2}\">", 
                SearchFormTarget,
                UpdateLink, 
                UpdateTarget);
            output.PreContent.SetContent(pre);

            var items = new StringBuilder();
            for (var i = 1; i <= TotalPages; i++)
            {
                var li = string.Format(
                @"<li" + ((i == CurrentPage)?" class=\"active\"":"") + @"> 
                <a href='{0}' title='{1}'>{2}</a>
                </li>", i, "Click to go to page {i}", i);

                items.AppendLine(li);
            }
            output.Content.SetContent(items.ToString());
            output.PostContent.SetContent("</ul>");
            output.Attributes.Clear();
            output.Attributes.Add("class", "paged-list");
        }
    }
}