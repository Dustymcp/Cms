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
        foreach (var images in imageRepository.ReadImages())
        {
            ddlImages.Items.Add(new ListItem(images.Filename,images.Id.ToString()));
        }

        foreach (var product in productsRepository.Read())
        {
            litProductTable.Text += "<tr><td><a href='products.aspx?Delete=true&Id=" + product.Id +"'>Remove</a></td><td><a href='products.aspx?Edit=true&Id='>Edit</a></td><td>" + product.Title + "</td><td>" + product.Image + "</td><td>" + product.Price + "</td><tr>";
        }
    }

    protected void btnSubmitProduct_OnClick(object sender, EventArgs e)
    {
        ProductsModel.Product product = new ProductsModel.Product();
        var productImage = imageRepository.ReadImages().FirstOrDefault(i => i.Id == Convert.ToInt32(ddlImages.SelectedValue));
        product.Comment = txtComment.Text;
        product.Price = Convert.ToInt32(txtPrice.Text);
        product.Title = txtTitle.Text;
        product.Image = productImage.Id;
        productsRepository.Create(product);
    }
}