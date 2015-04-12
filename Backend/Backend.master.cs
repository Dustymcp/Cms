using System;
using System.Linq;
using System.Web.UI;

public partial class backend_Backend : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SettingsModel.Repository settings = new SettingsModel.Repository();
        string siteName = "";
        //settings.Read().First().SiteName;

        if (siteName != null)
            litBrandText.Text = siteName + " Administration";
        else
            litBrandText.Text = "Admin Panel";

        var contactRepo = new ContactModel.Repository();
        var contactUnreadMail = contactRepo.ReadMail().Count(m => m.Watched == false);
        litNrofUnreadmail.Text = contactUnreadMail.ToString();
        //int sessionId = Convert.ToInt32(Session["Id"]);
        //int sessionLevel = Convert.ToInt32(Session["Level"]);


        //if (Session["Username"] == null)
        //    Response.Redirect("../login.aspx");
        //else
        //{
        //    string sessionUsername = Session["Username"].ToString();
        //    LitNavbarUsername.Text = sessionUsername;
        //}

        //if (sessionLevel != 1)
        //    Response.Redirect("../login.aspx");
    }
}
