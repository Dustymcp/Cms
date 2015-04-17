using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_products : System.Web.UI.Page
{
    UploadModel.Repository imageRepository = new UploadModel.Repository();
    ProductsModel.Repository productsRepository = new ProductsModel.Repository();


    protected void Page_Load(object sender, EventArgs e)
    {

        var edit = Convert.ToBoolean(Request.QueryString["Edit"]);
        var id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {


            foreach (var images in imageRepository.ReadImages())
            {
                ddlImages.Items.Add(new ListItem(images.Filename, images.Id.ToString()));
            }

            foreach (var product in productsRepository.Read())
            {
                var image = imageRepository.ReadImages().FirstOrDefault(i => i.Id == product.Images);
                litProductTable.Text += "<tr><td><a href='products.aspx?Delete=true&Id=" + product.Id + "'>Remove</a></td><td><a href='products.aspx?Edit=true&Id=" + product.Id + "'>Edit</a></td><td>" + product.Title + "</td><td>" + product.Price + "</td><td>" + Bootstrap.Image(image.Filename, 200, 200, "crop", true) + "</td></tr>";
            }

            if (edit)
            {
                var productToEdit = productsRepository.Read().FirstOrDefault(p => p.Id == id);
                txtTitle.Text = productToEdit.Title;
                txtComment.Text = productToEdit.Comment;
                txtPrice.Text = productToEdit.Price.ToString();
                ddlImages.SelectedValue = productToEdit.Images.ToString();
                btnSubmitProduct.Visible = false;
                btnEditProduct.Visible = true;
            }
        }
    }

    protected void btnSubmitProduct_OnClick(object sender, EventArgs e)
    {
        ProductsModel.Product product = new ProductsModel.Product();
        var productImage = imageRepository.ReadImages().FirstOrDefault(i => i.Id == Convert.ToInt32(ddlImages.SelectedValue));
        if (txtTitle.Text != "" && txtPrice.Text != "" && txtComment.Text != "")
        {  
        product.Comment = txtComment.Text;
        product.Price = Convert.ToInt32(txtPrice.Text);
        product.Title = txtTitle.Text;
        product.Images = productImage.Id;
        productsRepository.Create(product);
        Response.Redirect("products.aspx");
        }
        else if(txtTitle.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("Please insert a title.", 4);
        }
        else if (txtComment.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("Please insert a description.", 4);
            
        }
        else if (txtPrice.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("Please choose a price.",4);
        }
        else
        {
            litWarning.Text = Bootstrap.Alert("Test", 4);
        }
    }

    protected void btnEditProduct_OnClick(object sender, EventArgs e)
    {
        var id = Convert.ToInt32(Request.QueryString["Id"]);
        var productToEdit = productsRepository.Read().FirstOrDefault(p => p.Id == id);
        var productImage = imageRepository.ReadImages().FirstOrDefault(i => i.Id == Convert.ToInt32(ddlImages.SelectedValue));
        productToEdit.Comment = txtComment.Text;
        productToEdit.Price = Convert.ToInt32(txtPrice.Text);
        productToEdit.Title = txtTitle.Text;
        productToEdit.Images = productImage.Id;
        productsRepository.Update(productToEdit);
        Response.Redirect("products.aspx");

    }
}