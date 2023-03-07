using FoodDeliveryShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Azure;
using System.Formats.Asn1;

namespace FoodDeliveryShop.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PageLinkTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		public	PageLinkTagHelper(IUrlHelperFactory helperFactory)
		{
			urlHelperFactory = helperFactory;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public PagingInfo PageModel { get; set; }
		public string PageAction { get; set; }

		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

		public bool PageClassesEnabled { get; set; }
		public string PageClass { get; set; }
		public string PageClassNormal { get; set; }
		public string PageClassSelected { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
			TagBuilder result = new("div");
			// Previous page
			TagBuilder aTag = new("a");
			aTag.Attributes["href"] = urlHelper.Action(PageAction, new { page = PageModel.PreviousPage });
			aTag.InnerHtml.Append("<");
			aTag.AddCssClass(PageClass);
			result.InnerHtml.AppendHtml(aTag);
			// Pages enumeration
			for (int i = 1; i <= PageModel.TotalPages; i++)
			{
				aTag = new("a");
				PageUrlValues["Page"] = i;
				PageUrlValues["category"] = PageModel.CurrentCategory;
				aTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
				//aTag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });

				if (PageClassesEnabled)
				{
					aTag.AddCssClass(PageClass);
					aTag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
				}


				aTag.InnerHtml.Append(i.ToString());
				result.InnerHtml.AppendHtml(aTag);
			}
			// Next page
			aTag = new("a");
			aTag.Attributes["href"] = urlHelper.Action(PageAction, new { page = PageModel.NextPage });
			aTag.InnerHtml.Append(">");
			aTag.AddCssClass(PageClass);
			result.InnerHtml.AppendHtml(aTag);
			// Building div
			output.Content.AppendHtml(result.InnerHtml);
		}
	}
}