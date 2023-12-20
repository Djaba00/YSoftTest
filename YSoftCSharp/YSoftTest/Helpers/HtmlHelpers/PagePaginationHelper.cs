using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using YSoftTest.ViewModels;

namespace YSoftTest.Helpers.HtmlHelpers
{
    public static class PagePaginationHelper
    {
        public static MvcHtmlString RenderProductPagePagination(this HtmlHelper html, ProductPageViewModel page)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            ul.InnerHtml += RenderFirstPageButton(html, page);

            ul.InnerHtml += RenderCurrentPagesButtons(html, page);

            ul.InnerHtml += RenderLastPageButton(html, page);

            ul.InnerHtml += RenderListSizeDropDown(html, page);

            return new MvcHtmlString(ul.ToString());
        }

        private static string RenderFirstPageButton(HtmlHelper html, ProductPageViewModel page)
        {
            if (page.Page.HasPreviousPage)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                li.InnerHtml = html.ActionLink("Первая страница", "Index", "Home", new { pageNumber = 1, pageSize = page.Page.PageSize }, new { @class = "page-link" }).ToString();
                return li.ToString();
            }
            else
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item disabled");
                li.InnerHtml = "<a class = \"page-link\">Назад</a>";
                return li.ToString();
            }
        }

        private static string RenderLastPageButton(HtmlHelper html, ProductPageViewModel page)
        {
            if (page.Page.HasNextPage)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                li.InnerHtml = html.ActionLink("Последняя страница", "Index", "Home", new { pageNumber = page.Page.TotalPages, pageSize = page.Page.PageSize }, new { @class = "page-link" }).ToString();
                return li.ToString();
            }
            else
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item disabled");
                li.InnerHtml = "<a class=\"page-link\"s>Вперед</a>";
                return li.ToString();
            }
        }

        private static string RenderCurrentPagesButtons(HtmlHelper html, ProductPageViewModel page)
        {
            string list = "";
            
            for (int i = 0; i < 3; i++)
            {
                TagBuilder li = new TagBuilder("li");

                var tempPage = page.Page.PageNumber - 1 + i;

                if (tempPage == page.Page.PageNumber)
                    li.AddCssClass("page-item active");
                else if (tempPage == 0 || tempPage == page.Page.TotalPages + 1)
                    li.AddCssClass("page-item disabled");
                else
                    li.AddCssClass("page-item");

               
                li.InnerHtml = html.ActionLink(tempPage.ToString(), "Index", "Home", new { pageNumber = tempPage, pageSize = page.Page.PageSize }, new { @class = "page-link" }).ToString();

                list += li.ToString();
            }

            return list;
        }

        private static string RenderListSizeDropDown(HtmlHelper html, ProductPageViewModel page)
        {
            string list = "";

            for (int i = 1; i <= 3; i++)
            {
                TagBuilder li = new TagBuilder("li");

                var size = i * 10;

                if (size == page.Page.PageSize)
                    li.AddCssClass("page-item active");
                else
                    li.AddCssClass("page-item");

                li.InnerHtml = html.ActionLink(size.ToString(), "Index", "Home", new { pageNumber = page.Page, pageSize = size }, new { @class = "page-link" }).ToString();

                list += li.ToString();
            }

            return list;
        }
    }
}