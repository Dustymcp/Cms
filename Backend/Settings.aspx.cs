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

        if (!IsPostBack)
        {


            var settingRepo = new SettingsModel.Repository();
            var settings = settingRepo.Read().FirstOrDefault();
            var imageRepo = new UploadModel.Repository();

            foreach (var image in imageRepo.ReadImages())
            {
                ListItem item = new ListItem(image.Filename, image.Id.ToString());
                ddlList.Items.Add(item);
            }

            litGoogleMapEmbed.Text = " <iframe src='" + settings.Mapembedlink + "' width='" + settings.Width + "' height='" + settings.Height + "' frameborder='0' style='border: 0'></iframe>";


        
                ddlList.SelectedValue = settings.Image.ToString();
                txtFooterInfo.Text = settings.FooterInfo;
                txtPageInfo.Content = settings.PageInfo;
                txtSiteName.Text = settings.SiteName;
                chkContacts.Checked = settings.ContactModel;
                chkOpeningHours.Checked = settings.OpeningModel;
                chkPriceModel.Checked = settings.PriceModel;
                chkProducts.Checked = settings.ProductModel;
                txtEmbedLink.Text = settings.Mapembedlink;
                txtHeight.Text = settings.Height.ToString();
                txtWidth.Text = settings.Width.ToString();

            }

    }


    protected void btnEdit_OnClick(object sender, EventArgs e)
    {
        var settingRepo = new SettingsModel.Repository();
        var setting = settingRepo.Read().First();
        setting.FooterInfo = txtFooterInfo.Text;
        setting.PageInfo = txtPageInfo.Content;
        setting.SiteName = txtSiteName.Text;
        setting.ContactModel = chkContacts.Checked;
        setting.OpeningModel = chkOpeningHours.Checked;
        setting.PriceModel = chkPriceModel.Checked;
        setting.ProductModel = chkProducts.Checked;
        setting.Image = Convert.ToInt32(ddlList.SelectedValue);
        setting.Mapembedlink = txtEmbedLink.Text;
        setting.Height = Convert.ToInt32(txtHeight.Text);
        setting.Width = Convert.ToInt32(txtWidth.Text);
        settingRepo.Update(setting);
        Response.Redirect(Request.RawUrl);

    }
}