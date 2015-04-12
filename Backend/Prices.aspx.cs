using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

public partial class Backend_Prices : System.Web.UI.Page
{
    PriceModel.Repository priceRepository = new PriceModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

     
    
    }
}