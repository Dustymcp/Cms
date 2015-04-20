using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OpeningHours : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var openhoursRepo = new HoursModel.Repository();
        var openhours = openhoursRepo.Read().First();
        litOpeningHoursMonday.Text = openhours.Monday;
        litOpeningHoursTuesday.Text = openhours.Tuesday;
        litOpeningHoursWednesday.Text = openhours.Wednesday;
        litOpeningHoursThursday.Text = openhours.Thursday;
        litOpeningHoursFriday.Text = openhours.Friday;
        litOpeningHoursSaturday.Text = openhours.Saturday;
        litOpeningHoursSunday.Text = openhours.Sunday;
        litComment.Text = openhours.Comment;
    }

 
}