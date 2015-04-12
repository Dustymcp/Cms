using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UploadModel
/// </summary>
public class UploadModel
{
    public static void Upload(FileUpload fileUpload)
    {
        Repository repo = new Repository();

        const string uploadPath = "upload";
        if (fileUpload == null) return;
        foreach (HttpPostedFile postedFile in fileUpload.PostedFiles)
        {
            string fileName = postedFile.FileName;
            ImageResizer.ImageJob originalImage = new ImageResizer.ImageJob(postedFile, "~/" + uploadPath + "/" + fileName,
                new ImageResizer.Instructions("quality=72; mode=max"));
            originalImage.CreateParentDirectory = true;
            originalImage.Build();
            Image dbImage = new Image();
            dbImage.Filename = fileName;
            repo.CreateImage(dbImage);
        }
    }

    public class Repository
    {
        DatabaseModel DbContext = new DatabaseModel();

        public List<Image> ReadImages()
        {
            return DbContext.Images.ToList();
        }

        public void CreateImage(Image image)
        {
            DbContext.Images.Add(image);
            DbContext.SaveChanges();
        }

        public void DeleteImage(Image image)
        {
            var imageToDelete = DbContext.Images.FirstOrDefault(i => i.Id == image.Id);
            DbContext.Images.Remove(imageToDelete);
            DbContext.SaveChanges();
            
        }


    }

    public class Image
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Filename { get; set; }
    }
}