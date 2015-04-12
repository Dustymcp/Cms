using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

            var settingRepo = new SettingsModel.Repository();
            var settings = settingRepo.Read().FirstOrDefault();
            var imageRepo = new UploadModel.Repository();

            foreach (var image in imageRepo.ReadImages())
            {
                ListItem item = new ListItem(image.Filename, image.Id.ToString());
                ddlList.Items.Add(item);
            }

            if (!IsPostBack)
            {

            if (settings == null)
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnSubmit.Visible = false;
                ddlList.SelectedValue = settings.Image.ToString();
                txtFooterInfo.Text = settings.FooterInfo;
                txtPageInfo.Content = settings.PageInfo;
                txtSiteName.Text = settings.SiteName;
            }
        }
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        var settingRepo = new SettingsModel.Repository();
        var setting = new SettingsModel.Setting();
        setting.FooterInfo = txtFooterInfo.Text;
        setting.PageInfo = txtPageInfo.Content;
        setting.SiteName = txtSiteName.Text;
        var id = Convert.ToInt32(ddlList.SelectedValue);
        var imageRepo = new UploadModel.Repository();
        var image = imageRepo.ReadImages().FirstOrDefault(i => i.Id == id);
        setting.Image = image.Id;
        settingRepo.Create(setting);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEdit_OnClick(object sender, EventArgs e)
    {
        var settingRepo = new SettingsModel.Repository();
        var setting = settingRepo.Read().First();
        setting.FooterInfo = txtFooterInfo.Text;
        setting.PageInfo = txtPageInfo.Content;
        setting.SiteName = txtSiteName.Text;
        
        setting.Image =Convert.ToInt32(ddlList.SelectedValue);
        settingRepo.Update(setting);
        Response.Redirect(Request.RawUrl);

    }
}