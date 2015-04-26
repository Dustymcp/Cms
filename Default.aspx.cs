using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var settingRepo = new SettingsModel.Repository();
        var uploadRepo = new UploadModel.Repository();
        var productRepo = new ProductsModel.Repository();
        var openhoursRepo = new HoursModel.Repository();
        var openhours = openhoursRepo.Read().First();

        var settings = settingRepo.Read().First();
        var firstOrDefault = uploadRepo.ReadImages().FirstOrDefault(i => i.Id == settings.Image);

        var settingImage = firstOrDefault.Filename;

        litFrontpageImage.Text = Bootstrap.Image(settingImage, 400, 600, "stretch", false);
        litPageInfo.Text = settings.PageInfo;





        bool firstitem = true;

        foreach (var product in productRepo.Read().Take(10))
        {
            var orDefault = uploadRepo.ReadImages().FirstOrDefault(i => i.Id == product.Images);
            if (orDefault != null)
            {
                var productImage = orDefault.Filename;
                string active = "";
                if (firstitem)
                {
                    firstitem = false;
                    active = "active";
                }

                litProducts.Text += "<div class='item " + active + "'> " + "<div class='carousel-caption'><h3 class='text-center'>" + product.Title + "</h3>" + "<p class='text-center'>" + product.Price + ",-</p></div>" + Bootstrap.Image(productImage, 400, 600, "crop", true) + "</div>";
            }
        }

        litOpeningHoursMonday.Text = openhours.Monday;
        litOpeningHoursTuesday.Text = openhours.Tuesday;
        litOpeningHoursWednesday.Text = openhours.Wednesday;
        litOpeningHoursThursday.Text = openhours.Thursday;
        litOpeningHoursFriday.Text = openhours.Friday;
        litOpeningHoursSaturday.Text = openhours.Saturday;
        litOpeningHoursSunday.Text = openhours.Sunday;
        litComment.Text = openhours.Comment;

        var prices = new PriceModel.Repository();

        foreach (var price in prices.ReadPrices().Take(8))
        {
            litPriceList10.Text += "<li class='list-group-item'>" + price.Product + "<span class='badge'>" + price.Amount + ",- DKK</span></li>";
        }
    }
}