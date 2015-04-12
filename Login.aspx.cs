using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserModel.User user = new UserModel.User();
        UserModel.Repository repo = new UserModel.Repository();
        user.UserName = txtUsername.Text;
        user.HashedPassword = UserModel.Encryption(txtUserpass.Text);
        if (UserModel.ValidateUser(user))
        {
            UserModel.User validatedUser = repo.ShowUsers().FirstOrDefault(u => u.UserName == user.UserName);
            if (validatedUser != null)
            {
                Session["Id"] = validatedUser.Id;
                Session["Level"] = validatedUser.UserLevel;
                Session["Username"] = validatedUser.UserName;
                Response.Redirect("/Backend/Users.aspx?Skip=0&Take=10&SortOrder=Id");
            }
            else
                litWarning.Text = "Session could net be created, try again later.";
        }
        else
            litWarning.Text = "Wrong password or Username. Try Again.";
    }
}