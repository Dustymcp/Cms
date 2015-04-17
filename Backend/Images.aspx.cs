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
        var repo = new UploadModel.Repository();
        var productRepo = new ProductsModel.Repository();
        var id = Convert.ToInt32(Request.QueryString["Id"]);
        var delete = Convert.ToBoolean(Request.QueryString["Delete"]);
        if (delete)
        {
            var imageToDelete = repo.ReadImages().FirstOrDefault(i => i.Id == id);
            var productImageCount = productRepo.Read().Count(pi => imageToDelete != null && pi.Images == imageToDelete.Id);
            if (imageToDelete != null)
            {
                if (productImageCount == 0)
                {
                    var fileOnServer = new FileInfo(Server.MapPath(@"~/upload/" + imageToDelete.Filename));
                    repo.DeleteImage(imageToDelete);
                    fileOnServer.Delete();
                    Response.Redirect(redirectUrl);

                }
                else
                {
                    litWarning.Text = Bootstrap.Alert("Please delete products associated with the image.", 4);
                }

            }
            else
            {
                litWarning.Text = Bootstrap.Alert("Error occured, the image does not exist. try refreshing the page.", 4);
            }

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