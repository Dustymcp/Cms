using System;
using System.Linq;
using System.Web.UI;

public partial class backend_Backend : MasterPage
{
    UserModel.Repository userRepository = new UserModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {
        SettingsModel.Repository settings = new SettingsModel.Repository();
        string siteName = settings.Read().First().SiteName;

        if (siteName != null)
            litBrandText.Text = siteName + " Administration";
        else
            litBrandText.Text = "Admin Panel";

        var contactRepo = new ContactModel.Repository();
        var contactUnreadMail = contactRepo.ReadMail().Count(m => m.Watched == false);
        litNrofUnreadmail.Text = contactUnreadMail.ToString();
        litBrandText.Text += Session["Level"];
        int sessionId = Convert.ToInt32(Session["UserId"]);
        UserModel.User validatedUser = userRepository.ShowUsers().FirstOrDefault(u => u.Id == sessionId);
        if (validatedUser == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (validatedUser.UserLevel != 1)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            LitNavbarUsername.Text = validatedUser.FirstName;
        }



    }
}
