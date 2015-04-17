using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserModel.Repository userRepository = new UserModel.Repository();
        UploadModel.Repository uploadRepository = new UploadModel.Repository();
        PageModel.Repository pageRepository = new PageModel.Repository();
        ProductsModel.Repository productRepository = new ProductsModel.Repository();

        litUserCount.Text = userRepository.ShowUsers().Count().ToString();
        litImageCount.Text = uploadRepository.ReadImages().Count().ToString();
        litPageCount.Text = pageRepository.ReadPages().Count().ToString();


        foreach (var user in userRepository.ShowUsers().Take(5))
        {
            litUserTop10.Text += "<a href='Users.aspx?Id=" + user.Id + "&Edit=true&Skip=0&Take=10' class='list-group-item'>" + user.UserName +  "</a>";
            
        }

        bool firstitem = true;
        foreach (var image in uploadRepository.ReadImages().Take(5))
        {
            string active = "";
            if (firstitem)
            {
                firstitem = false;
                active = "active";
            }
         
            litImagesLatest.Text += "<div class='item " + active + "'> " + Bootstrap.Image(image.Filename, 200, 400, "crop", true) + "</div>";
            
        }

        foreach (var pages in pageRepository.ReadPages().Take(5))
        {
            litPageLatest.Text += "<a href='#' class='list-group-item'>" + pages.Title + " - " + Bootstrap.ShortenContent(pages.Content,150) + "...</a>";
        }

        foreach (var product in productRepository.Read().Take(5))
        {
            var productImage = uploadRepository.ReadImages().FirstOrDefault(i => i.Id == product.Images);
            litProductsOverview.Text += "<li class='media well'><div class='media-left'><a href='#'>" + Bootstrap.MediaObject(productImage.Filename, 100, 100, "crop", true) + "</div></a><div class='media-body'><h4 class='media-heading'>" + product.Title + "</h4><p>" + product.Comment + "</p><p>" + product.Price +"</p></div>" + "</li>";
        }
    }
}