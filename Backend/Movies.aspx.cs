using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Movies : Page
{
    public List<int> selectList;
    UploadModel.Repository uploadRepository = new UploadModel.Repository();
    MoviesModel.Actor actor = new MoviesModel.Actor();
    MoviesModel.Repository movieRepo = new MoviesModel.Repository();
    MoviesModel.Repository actorRepo = new MoviesModel.Repository();

    MoviesModel.Movie movie = new MoviesModel.Movie();
    protected void Page_Load(object sender, EventArgs e)
    {



        selectList = new List<int>();
        if (!IsPostBack)
        {


            foreach (var item in uploadRepository.ReadImages())
            {
                ddlImage.Items.Add(new ListItem(item.Filename, item.Id.ToString()));

            }
        }
    }

    protected void btnSubmitActor_OnClick(object sender, EventArgs e)
    {
        
        actor.Name = txtActorName.Text;
        movieRepo.CreateActor(actor);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnSubmitMovie_OnClick(object sender, EventArgs e)
    {

       
        List<MoviesModel.MovieActorLink> moviesActorLinks = new List<MoviesModel.MovieActorLink>();


        foreach (ListItem item in ListActors.Items)
        {


            MoviesModel.MovieActorLink movieToActor = new MoviesModel.MovieActorLink();
            var actor = movieRepo.ReadActors().FirstOrDefault(a => a.Id == Convert.ToInt32(item.Value));

            movieToActor.Actor = actor;
            movieToActor.Movie = movie;


            moviesActorLinks.Add(movieToActor);





        }
        var findImage = uploadRepository.ReadImages().FirstOrDefault(i => i.Id == Convert.ToInt32(ddlImage.SelectedValue));
        movie.Image = findImage;

        movie.Title = txtMovieName.Text;
        movie.Actors = moviesActorLinks;
        movie.Year = Convert.ToDateTime(calMovieYear.Text);
        movieRepo.CreateMovie(movie);

        Response.Redirect(Request.RawUrl);

    }


    protected void btnSubmitSearch_OnClick(object sender, EventArgs e)
    {



        var searcQuery = movieRepo.ReadActors().Where(a => a.Name.ToLower().StartsWith(txtSearcActor.Text.ToLower()));
        if (txtSearcActor.Text == "")
        {
            litWarning.Text = Bootstrap.Alert("We dont give away free server power here, search on something!", 4);
        }
        else if (searcQuery.Count() <= 0)
        {
            litWarning.Text = Bootstrap.Alert("No Results try the starting letter of the actor.", 4);
        }
        else
        {

            litWarning.Text = "";
            rptActorList.DataSource = searcQuery;

            rptActorList.DataBind();
        }
    }


    protected void rptActorList_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "addtocart")
        {
            MoviesModel.Actor currentActor = actorRepo.ReadActors().FirstOrDefault(a => a.Id == Convert.ToInt32(e.CommandArgument));

            selectList.Add(currentActor.Id);
            int lastClickedButton = currentActor.Id;


            foreach (var item in selectList)
            {
                MoviesModel.Actor actorToList = actorRepo.ReadActors().FirstOrDefault(a => a.Id == item);
                ListActors.Items.Add(new ListItem(actorToList.Name, actorToList.Id.ToString()));
                litWarning.Text += item;
            }
            ListActors.Items.Remove(lastClickedButton.ToString());
            litWarning.Text = lastClickedButton.ToString();

        }
    }



    protected void txtSearcActor_OnTextChanged(object sender, EventArgs e)
    {
      



        var searcQuery = movieRepo.ReadActors().Where(a => a.Name.ToLower().StartsWith(txtSearcActor.Text.ToLower()));


        litWarning.Text = "";
        rptActorList.DataSource = searcQuery;

        rptActorList.DataBind();

    }
}