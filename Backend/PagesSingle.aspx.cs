using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_PagesSingle : System.Web.UI.Page
{
    PageModel.Repository pageRepository = new PageModel.Repository();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            var id = Convert.ToInt32(Request.QueryString["Id"]);
            var edit = Convert.ToBoolean(Request.QueryString["Edit"]);
            foreach (var item in pageRepository.ReadPageCategory())
            {
                ddlCategory.Items.Add(new ListItem(item.Name, item.Id.ToString()));

            }
            if (edit)
            {

                btnCreatePage.Visible = false;
                btnEditPage.Visible = true;
                var pagetoedit = pageRepository.ReadPages().FirstOrDefault(p => p.Id == id);
                txtTitle.Text = pagetoedit.Title;
                ddlCategory.SelectedValue = pagetoedit.PageCategories.Id.ToString();
                Editor1.Content = pagetoedit.Content;
                litPageTitleEditorNew.Text = "Edit " + pagetoedit.Title;

            }
            else
            {
                litPageTitleEditorNew.Text = "Create new page";
            }
        }
    }


    protected void btnCreatePage_OnClick(object sender, EventArgs e)
    {
        PageModel.PageTemplate pageTemplate = new PageModel.PageTemplate();

        if (Editor1.Content != "" || txtTitle.Text != "")
        {
            pageTemplate.Content = Editor1.Content;
            pageTemplate.Created = DateTime.Now;
            pageTemplate.Edited = DateTime.Now;
            pageTemplate.Creator = "Administrator";
            var pageCategory = pageRepository.ReadPageCategory().FirstOrDefault(pc => pc.Id == Convert.ToInt32(ddlCategory.SelectedValue));
            pageTemplate.PageCategories = pageCategory;
            pageTemplate.Title = txtTitle.Text;
            pageRepository.CreatePages(pageTemplate);
            Response.Redirect("Pages.aspx");
        }
        else if (Editor1.Content == "")
        {

            litWarning.Text = Bootstrap.Alert("Please insert some content to your page.", 4);

        }
        else if (txtTitle.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("Please insert a title to the page.", 4);
        }

    }

    protected void btnEditPage_OnClick(object sender, EventArgs e)
    {

        var id = Convert.ToInt32(Request.QueryString["Id"]);
        var pageTemplate = pageRepository.ReadPages().FirstOrDefault(p => p.Id == id);
        pageTemplate.Content = Editor1.Content;
        if (Editor1.Content != "" || txtTitle.Text != "")
        {
            pageTemplate.Edited = DateTime.Now;
            pageTemplate.Creator = "Administrator";
            var pageCategory =
                pageRepository.ReadPageCategory()
                    .FirstOrDefault(pc => pc.Id == Convert.ToInt32(ddlCategory.SelectedValue));
            pageTemplate.PageCategories = pageCategory;
            pageTemplate.Title = txtTitle.Text;
            pageRepository.UpdatePage(pageTemplate);
            litWarning.Text = Bootstrap.Alert("Page Edited", 1);
        }
        else if (Editor1.Content == "")
        {

            litWarning.Text = Bootstrap.Alert("Please insert some content to your page.", 4);

        }
        else if (txtTitle.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("Please insert a title to the page.", 4);
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