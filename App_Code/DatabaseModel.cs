﻿
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.WindowsAzure.Storage.Table.Protocol;

/// <summary>
/// Summary description for DatabaseModel
/// </summary>
public class DatabaseModel : DbContext
{
    //get database model
    public DbSet<UserModel.User> Users { get; set; }
    public DbSet<UploadModel.Image> Images { get; set; }
    public DbSet<ContactModel.Mail> Mails { get; set; }
    public DbSet<MoviesModel.Actor> Actors { get; set; }
    public DbSet<MoviesModel.Director> Directors { get; set; }
    public DbSet<MoviesModel.Genre> Genres { get; set; }
    public DbSet<MoviesModel.Movie> Movies { get; set; }
    public DbSet<MoviesModel.MovieActorLink> MovieActorLinks { get; set; }
    public DbSet<PriceModel.Price> Prices { get; set; }
    public DbSet<PageModel.PageTemplate> PageTemplates { get; set; }
    public DbSet<PageModel.PageCategory> PageCategories { get; set; }
    public DbSet<SettingsModel.Setting> Setting { get; set; }
    public DbSet<ProductsModel.Product> Products { get; set; }
    public DbSet<HoursModel.OpeningHours> OpeningHours { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
   
        //pass databasemodel on to construct stored procedures in programmability/storedprocedures.
        modelBuilder.Entity<ContactModel.Mail>().MapToStoredProcedures();
        modelBuilder.Entity<UserModel.User>().MapToStoredProcedures();
        modelBuilder.Entity<UploadModel.Image>().MapToStoredProcedures();
        modelBuilder.Entity<MoviesModel.Actor>().MapToStoredProcedures();
        modelBuilder.Entity<MoviesModel.Director>().MapToStoredProcedures();
        modelBuilder.Entity<MoviesModel.Genre>().MapToStoredProcedures();
        modelBuilder.Entity<MoviesModel.Movie>().MapToStoredProcedures();
        modelBuilder.Entity<MoviesModel.MovieActorLink>().MapToStoredProcedures();
        modelBuilder.Entity<PriceModel.Price>().MapToStoredProcedures();
        modelBuilder.Entity<PageModel.PageTemplate>().MapToStoredProcedures();
        modelBuilder.Entity<PageModel.PageCategory>().MapToStoredProcedures();
        modelBuilder.Entity<SettingsModel.Setting>().MapToStoredProcedures();
        modelBuilder.Entity<ProductsModel.Product>().MapToStoredProcedures();
        modelBuilder.Entity<HoursModel.OpeningHours>().MapToStoredProcedures();

        base.OnModelCreating(modelBuilder);
       
    }
    
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseModel>
    {
        protected override void Seed(DatabaseModel context)
        {
            UserModel.User user = new UserModel.User();
            user.FirstName = "Admin";
            user.HashedPassword = UserModel.Encryption("admin");
            user.LastName = "Admin";
            user.StreetAdress = "Admin lane";
            user.StreetNumber = 22;
            user.UserLevel = 1;
            user.UserName = "Admin";
            context.Users.Add(user);

            PageModel.PageCategory pageCategory = new PageModel.PageCategory();
            pageCategory.Name = "Template Category";
            context.PageCategories.Add(pageCategory);

            PageModel.PageTemplate pageTemplate = new PageModel.PageTemplate();
            pageTemplate.Content = "This is your content";
            pageTemplate.PageCategories = pageCategory;
            pageTemplate.Created = DateTime.Now;
            pageTemplate.Edited = DateTime.Now;
            pageTemplate.Creator = "Admin";
            pageTemplate.Title = "Template Page";
            context.PageTemplates.Add(pageTemplate);


            ContactModel.Mail mail = new ContactModel.Mail();
            mail.Content = "This is a test mail to fill up the inventory abit";
            mail.Created = DateTime.Now;
            mail.Sender = "Dustcore@dontmail.me";
            mail.Title = "Welcome to your very own website!";
            mail.Watched = false;
            context.Mails.Add(mail);

            UploadModel.Image templateImage = new UploadModel.Image();
            templateImage.Filename = "1024placeholder.png";
            context.Images.Add(templateImage);


            SettingsModel.Setting setting = new SettingsModel.Setting();
            setting.FooterInfo = "Test Template";
            setting.PageInfo = "No data added yet.";
            
            setting.SiteName = "Template Site";
            setting.Image = 1;
            setting.OpeningModel = true;
            setting.PriceModel = true;
            setting.ContactModel = true;
            setting.ProductModel = true;
            setting.Mapembedlink ="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d35560.55761754828!2d10.214217099999999!3d56.14785654999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0000000000000000%3A0x1837916eb88c0de3!2sTivoli+Friheden!5e0!3m2!1sda!2sdk!4v1429060674382";
            setting.Width = 300;
            setting.Height = 450;
            context.Setting.Add(setting);

            HoursModel.OpeningHours openingHours = new HoursModel.OpeningHours();
            openingHours.Comment = "Comment";
            openingHours.Monday = "12.00 - 23.00";
            openingHours.Tuesday = "12.00 - 23.00";
            openingHours.Wednesday = "12.00 - 23.00";
            openingHours.Thursday = "12.00 - 23.00";
            openingHours.Friday = "12.00 - 02.00";
            openingHours.Saturday = "12.00 - 02.00";
            openingHours.Sunday = "12.00 - 20.00";
            context.OpeningHours.Add(openingHours);

            ProductsModel.Product product = new ProductsModel.Product();
            product.Images = 1;
            product.Comment = "This is a default product listing.";
            product.Price = 234;
            product.Title = "Title";
            
            context.Products.Add(product);


            PriceModel.Price price = new PriceModel.Price();
            price.Product = "Test product";
            price.Amount = 999;
            context.Prices.Add(price);

            context.SaveChanges();

            base.Seed(context);
        }
    }



}


