using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_OpeningHours : System.Web.UI.Page
{
    HoursModel.Repository openingHoursRepository = new HoursModel.Repository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            var openhours = openingHoursRepository.Read().First();
            txtMonday.Text = openhours.Monday;
            txtTuesday.Text = openhours.Tuesday;
            txtWednesday.Text = openhours.Wednesday;
            txtThursday.Text = openhours.Thursday;
            txtFriday.Text = openhours.Friday;
            txtSaturday.Text = openhours.Saturday;
            txtSunday.Text = openhours.Sunday;
            txtComment.Text = openhours.Comment;
        }
    }

    protected void btnEditOpeningHours_OnClick(object sender, EventArgs e)
    {
        var openhours = openingHoursRepository.Read().First();
        openhours.Monday = txtMonday.Text;
        openhours.Tuesday = txtTuesday.Text;
        openhours.Wednesday = txtWednesday.Text;
        openhours.Thursday = txtThursday.Text;
        openhours.Friday = txtFriday.Text;
        openhours.Saturday = txtSaturday.Text;
        openhours.Sunday = txtSunday.Text;
        openhours.Comment = txtComment.Text;
        openingHoursRepository.Update(openhours);
    }
}