using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    ContactModel.Repository repo = new ContactModel.Repository();
    SettingsModel.Repository settingsRepo = new SettingsModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {
        var settings = settingsRepo.Read().First();
        litGoogleMapEmbed.Text = " <iframe src='" + settings.Mapembedlink + "' width='" + settings.Width + "' height='" + settings.Height + "' frameborder='0' style='border: 0'></iframe>";

    }

    protected void btnSubmitMail_OnClick(object sender, EventArgs e)
    {
        var mail = new ContactModel.Mail
        {
            Sender = txtSender.Text,
            Title = txtTitel.Text,
            Watched = false,
            Content = txtContent.Text,
            Created = DateTime.Now
        };

        repo.CreateMail(mail);
        litWarning.Text = Bootstrap.Alert("Thanks for your mail we will get back to you shortly.", 1);
    }
}