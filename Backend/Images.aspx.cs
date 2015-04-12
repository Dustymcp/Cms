using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Images : System.Web.UI.Page
{
    private const string redirectUrl = "Images.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        UploadModel.Repository repo = new UploadModel.Repository();

        int idToDelete = Convert.ToInt32(Request.QueryString["Id"]);
        if (Convert.ToBoolean(Request.QueryString["Delete"]))
        {
            var imageToDelete = repo.ReadImages().FirstOrDefault(i => i.Id == idToDelete);
            repo.DeleteImage(imageToDelete);
            if (imageToDelete != null)
            {
                var fileOnServer = new FileInfo(Server.MapPath(@"~/upload/" + imageToDelete.Filename));
                fileOnServer.Delete();
            }

            Response.Redirect(redirectUrl);
        }
        rptFileOverview.DataSource = repo.ReadImages();
        rptFileOverview.DataBind();
    }

    protected void btnSubmitFiles_OnClick(object sender, EventArgs e)
    {
        if (fileUpload.HasFiles || fileUpload.HasFile)
        {
            UploadModel.Upload(fileUpload);
            Response.Redirect(redirectUrl);
        }
        else
        {
            litWarning.Text = Bootstrap.Alert("Please add a file!", 4);
        }
    
    }
}