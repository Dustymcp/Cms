using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Pages : System.Web.UI.Page
{
    PageModel.Repository pageRepository = new PageModel.Repository();

    protected void Page_Load(object sender, EventArgs e)
    {


        foreach (var page in pageRepository.ReadPages())
        {


            litPageOverview.Text += @"<tr><td><a href='Pages.aspx?Id=" + page.Id + "&Delete=true'>Delete</a></td><td> " +
                                    "<a href='PagesSingle.aspx?Id=" + page.Id + "&Edit=true' >Edit</a></td><td>" + page.Title + "</td><td>" + page.PageCategories.Name + "</td><td>" + page.Created.ToLongDateString() + " @ " + page.Created.ToLongTimeString() + "</td><td>" + Bootstrap.ShortenContent(Server.HtmlEncode(page.Content), 50) + "</td></tr>";
        }
        foreach (var category in pageRepository.ReadPageCategory())
        {
            litpagecategoryoverview.Text += "<tr><td><a href='pages.aspx?DeleteCat=True&Id=" + category.Id + "'>Delete</a></td><td>" + category.Name + "</td><td>" + pageRepository.ReadPages().Count(p=>p.PageCategories.Id == category.Id) + "</td></tr>";
        }
        if (!IsPostBack)
        {

            var id = Convert.ToInt32(Request.QueryString["Id"]);
            var delete = Convert.ToBoolean(Request.QueryString["Delete"]);
            var deleteCat = Convert.ToBoolean(Request.QueryString["DeleteCat"]);
            if (delete)
            {
                var pagetoodel = pageRepository.ReadPages().FirstOrDefault(p => p.Id == id);
                pageRepository.DeletePage(pagetoodel);
                Response.Redirect("Pages.aspx");
            }
            if (deleteCat)
            {
                
                var pagecattoodel = pageRepository.ReadPageCategory().FirstOrDefault(pc => pc.Id == id);
                var pageCountInCategory = pageRepository.ReadPages().Count(p => pagecattoodel != null && p.PageCategories.Id == pagecattoodel.Id);
                if (pageCountInCategory == 0)
                {
                    pageRepository.DeletePageCategory(pagecattoodel);
                    Response.Redirect("Pages.aspx");
                }
                else
                {
                    litWarning.Text = Bootstrap.Alert("You need to delete the pages associated with the category first!", 4);
                }
            }

        }
    }


    protected void btnCreateCategory_OnClick(object sender, EventArgs e)
    {
        PageModel.PageCategory pageCategory = new PageModel.PageCategory();
        pageCategory.Name = txtCategoryName.Text;
        pageRepository.CreatePageCategory(pageCategory);
        Response.Redirect(Request.RawUrl);
    }
}