using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

public partial class Pages : System.Web.UI.Page
{
    PageModel.Repository pageRepository = new PageModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {

        var queryId = Convert.ToInt32(Request.QueryString["Id"]);

        var getPage = pageRepository.ReadPages().FirstOrDefault(p => p.Id == queryId);
        var getCat = pageRepository.ReadPageCategory().FirstOrDefault(p => getPage != null && p.Id == getPage.PageCategories.Id);

        if (getPage != null)
        {
            litTitle.Text = getPage.Title;
            litCategory.Text = getCat.Name;
            litCreator.Text = getPage.Creator;
            litContent.Text = getPage.Content;
            litCreated.Text = getPage.Created.ToLongDateString() + " : " + getPage.Created.ToLongTimeString();
        }
        else
        {
            litContent.Text = Bootstrap.Alert("Cant find a page.",4);
        }
    }
}