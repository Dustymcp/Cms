using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    readonly PageModel.Repository pageRepository = new PageModel.Repository();
    readonly SettingsModel.Repository settingRepo = new SettingsModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (var category in pageRepository.ReadPageCategory())
        {
            var pageCategory = pageRepository.ReadPageCategory().FirstOrDefault(pc => pc.Id == category.Id);
            var pageResult = pageRepository.ReadPages().Where(p => p.PageCategories == pageCategory);
            var firstOrDefault = pageRepository.ReadPages().FirstOrDefault(p => p.PageCategories.Id == category.Id);
            var settings = settingRepo.Read().First();
            litSiteName.Text = settings.SiteName;
            if (firstOrDefault != null)
            {
                var pageId = firstOrDefault.Id;
                var pageTemplates = pageResult as PageModel.PageTemplate[] ?? pageResult.ToArray();
                var pageCount = pageTemplates.Count();

                if (pageCount <= 1)
                {
                    litNavbarDropdown.Text += "<li><a href='Pages.aspx?Id=" + pageId + "'>" + category.Name + "</a></li>";
                }
                else
                {

                    litNavbarDropdown.Text += "<li class='dropdown'><a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'>" + category.Name + "<span class='caret'></span></a><ul class='dropdown-menu' role='menu'>";
                    foreach (var pagetemplate in pageTemplates)
                    {
                        litNavbarDropdown.Text += "<li><a href='Pages.aspx?Id=" + pagetemplate.Id + "'>" + pagetemplate.Title + "</a></li>";
                    }
                    litNavbarDropdown.Text += "</ul></li>";


                }


                if (settings.OpeningModel)
                {
                    litNavbarDropdown.Text += "<li><a href='OpeningHours.aspx'>Opening Hours</a></li>";
                }
                if (settings.PriceModel)
                {
                    litNavbarDropdown.Text += "<li><a href='Prices.aspx'>Prices</a></li>";
                }
                if (settings.ProductModel)
                {
                    litNavbarDropdown.Text += "<li><a href='Products.aspx'>Products</a></li>";
                }
                if (settings.ContactModel)
                {
                    litNavbarDropdown.Text += "<li><a href='Contact.aspx'>Contact</a></li>";
                }
            }

        }


    }
}


