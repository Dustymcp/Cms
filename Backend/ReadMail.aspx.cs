using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_ReadMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Convert.ToInt32(Request.QueryString["Id"]);
        var repo =new ContactModel.Repository();
        var findMail = repo.ReadMail().FirstOrDefault(m => m.Id == id);
        if (findMail != null) litMailContent.Text = findMail.Content;
        repo.SetMailRead(findMail);
    }
}