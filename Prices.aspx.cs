using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PriceModel.Repository priceRepository = new PriceModel.Repository();
        var allPrices = priceRepository.ReadPrices();
        foreach (var price in allPrices)
        {
            litTablePrice.Text += "<tr><td>" + price.Product + "</td><td>" + price.Amount + " ,-</td></tr>";
        }
    }
} 