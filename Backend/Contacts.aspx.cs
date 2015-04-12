using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Contacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        var repo = new ContactModel.Repository();


        bool read = Convert.ToBoolean(Request.QueryString["Read"]);
        var id = Convert.ToInt32(Request.QueryString["Id"]);
        bool delete = Convert.ToBoolean(Request.QueryString["Delete"]);


        if (read)
        {
            pnlReader.Visible = true;
            var findMail = repo.ReadMail().FirstOrDefault(m => m.Id == id);
            if (findMail != null)
            {
                litMailContent.Text = findMail.Content;
                litMailSender.Text = findMail.Sender;
                litMailTitle.Text = findMail.Title;
            }

            repo.SetMailRead(findMail);
        }
        if (delete)
        {
            var removeMail = repo.ReadMail().FirstOrDefault(m => m.Id == id);
            repo.DeleteMail(removeMail);
            
        }

        rptMail.DataSource = repo.ReadMail().OrderBy(m => m.Watched).ThenByDescending(m => m.Created);
        rptMail.DataBind();

    }
}