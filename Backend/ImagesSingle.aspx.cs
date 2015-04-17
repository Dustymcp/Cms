using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_ImagesSingle : System.Web.UI.Page
{
    UploadModel.Repository uploadRepository = new UploadModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {
        var id =Convert.ToInt32(Request.QueryString["Id"]);
       var image = uploadRepository.ReadImages().FirstOrDefault(i => i.Id == id);
        if (image != null)
        {
            litImageName.Text = image.Filename;
            litFullImage.Text = Bootstrap.Image(image.Filename, 1500, 1500, "max", true);

        }
        else
        {
            litImageName.Text = Bootstrap.Alert("No image found.", 4);
        }
    }
}