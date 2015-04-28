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
            UserModel.User validatedUser = repo.ShowUsers().FirstOrDefault(u => u.UserName == user.UserName);
        if (validatedUser != null && validatedUser.HashedPassword == UserModel.Encryption(txtUserpass.Text))
        {
            Session["UserId"] = validatedUser.Id;
            Response.Redirect("Backend");

        }
        else
        {
            litWarning.Text = Bootstrap.Alert("Something went wrong try again. remember usernames are case sensitive.",4);
        }
          
        }
    
}