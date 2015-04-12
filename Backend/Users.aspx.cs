using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Users : Page
{
    //repository access - talk to database.
    UserModel.Repository Repo = new UserModel.Repository();

    public int Take = 0;
    public int Skip = 10;

    private const string ReturnUrl = "Users.aspx?SortOrder=Id&Skip=0&Take=10";

    protected void Page_Load(object sender, EventArgs e)
    {
        OverView();
        //sort table in the overview.
    }
    //add new user with hashed password and userlevel. //MAX LEVEL
    protected void btnSubmitUser_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
            litWarning.Text = Bootstrap.Alert("Fill in Username..",4);
        else if (txtPassword.Text == "")
            litWarning.Text = Bootstrap.Alert("Fill in Password..",4);
        else
        {
            UserModel.User user = new UserModel.User();
            user.UserName = txtUserName.Text;
            user.HashedPassword = UserModel.Encryption(txtPassword.Text);
            user.UserLevel = Convert.ToInt32(ddlUserLevel.SelectedItem.Value);
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.StreetAdress = txtStreetAdress.Text;
            user.StreetAdress = txtStreetnumber.Text;
            Repo.InsertUser(user);
            Response.Redirect(ReturnUrl);
        }
    }
    //post edited data back to database.
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["Id"]);

        if (txtUserName.Text == "")
            litWarning.Text = "User need to have a username..";

        UserModel.User userToEdit = Repo.ShowUsers().FirstOrDefault(u => u.Id == Id);
        if (userToEdit != null && Session["Level"] != null)
        {
            userToEdit.UserName = txtUserName.Text;
            userToEdit.FirstName = txtFirstName.Text;
            userToEdit.LastName = txtLastName.Text;
            userToEdit.StreetAdress = txtStreetAdress.Text;
            userToEdit.StreetNumber = Convert.ToInt32(txtStreetnumber.Text);
            userToEdit.UserLevel = Convert.ToInt32(ddlUserLevel.SelectedValue);
            Repo.UpdateUser(userToEdit);
        }
        Response.Redirect(ReturnUrl);

    }
    //Add overview with sorting and edit delete functions.
    public void OverView()
    {
        //get querystrings
        int id = Convert.ToInt32(Request.QueryString["Id"]);
        bool deleteUser = Convert.ToBoolean(Request.QueryString["Delete"]);
        bool editUser = Convert.ToBoolean(Request.QueryString["Edit"]);
        string sortOrder = Request.QueryString["sortOrder"];
        Skip = Convert.ToInt32(Request.QueryString["Skip"]);
        Take = Convert.ToInt32(Request.QueryString["Take"]);

        //delete a user
        if (deleteUser)
        {
            UserModel.User deleteuser = Repo.ShowUsers().FirstOrDefault(u => u.Id == id);
            if (deleteuser == null || deleteuser.Id != Convert.ToInt32(Session["Id"]))
            {
                if (Session["Level"] != null && Convert.ToInt32(Session["Level"]) == 1)
                {
                    Repo.DeleteUser(deleteuser);
                    Response.Redirect(ReturnUrl);
                }
                else
                    Response.Redirect("../Login.aspx");
            }
            else
                litWarning.Text = Bootstrap.Alert("Now you would'nt delete yourself now would you?", 4);
        }
        //call in data to edit a user
        if (editUser)
        {
            if (!IsPostBack)
            {

                UserModel.User userToEdit = Repo.ShowUsers().FirstOrDefault(u => u.Id == id);

                pnlPassword.Visible = false;
                if (userToEdit != null)
                {
                    txtUserName.Text = userToEdit.UserName;
                    txtFirstName.Text = userToEdit.FirstName;
                    txtLastName.Text = userToEdit.LastName;
                    txtStreetAdress.Text = userToEdit.StreetAdress;
                    txtStreetnumber.Text = userToEdit.StreetNumber.ToString();
                    ddlUserLevel.SelectedValue = userToEdit.UserLevel.ToString();
                }
                btnSubmitUser.Visible = false;
                btnEditUser.Visible = true;
                btnBack.Visible = true;
            }
        }


        if (sortOrder == "UserName")
        {
            rpt.DataSource = Repo.ShowUsers().OrderBy(s => s.UserName).Take(Take).Skip(Skip);
            rpt.DataBind();
        }
        else if (sortOrder == "Id")
        {
            rpt.DataSource = Repo.ShowUsers().OrderBy(s => s.Id).Take(Take).Skip(Skip);
            rpt.DataBind();
        }
        else if (sortOrder == "First")
        {
            rpt.DataSource = Repo.ShowUsers().OrderBy(s => s.FirstName).Take(Take).Skip(Skip);
            rpt.DataBind();
        }
        else if (sortOrder == "Last")
        {
            rpt.DataSource = Repo.ShowUsers().OrderBy(s => s.LastName).Take(Take).Skip(Skip);
            rpt.DataBind();
        }
        else if (sortOrder == "Address")
        {
            rpt.DataSource = Repo.ShowUsers().OrderBy(s => s.LastName).Take(Take).Skip(Skip);
            rpt.DataBind();
        }
        else
        {

            rpt.DataSource = Repo.ShowUsers().OrderBy(u => u.Id).Take(Take).Skip(Skip);
            rpt.DataBind();

        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        int skip = Convert.ToInt32(Request.QueryString["Skip"]);
        int take = Convert.ToInt32(Request.QueryString["Take"]);

        if (skip >= (Repo.ShowUsers().Count() - 10)) { }
        else
        {

            skip += 10;
            take += 10;

            rpt.DataSource = Repo.ShowUsers().OrderBy(u => u.Id).Take(take).Skip(skip);
            rpt.DataBind();
            Response.Redirect("Users.aspx?Skip=" + skip + "&Take=" + take);
        }
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        int skip = Convert.ToInt32(Request.QueryString["Skip"]);
        int take = Convert.ToInt32(Request.QueryString["Take"]);
        if (skip <= 0) { }
        else
        {

            skip -= 10;
            take -= 10;

            rpt.DataSource = Repo.ShowUsers().OrderBy(u => u.Id).Take(take).Skip(skip);
            rpt.DataBind();
            Response.Redirect("Users.aspx?Skip=" + skip + "&Take=" + take);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ReturnUrl);
    }
}