using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageModel
/// </summary>
public class PageModel
{
    public class PageTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public PageCategory PageCategories { get; set; }

    }

    public class PageCategory
    {
         [Key]
         public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Repository
    {
        DatabaseModel _databaseContext = new DatabaseModel();

        public List<PageTemplate> ReadPages()
        {
            return _databaseContext.PageTemplates.Include("PageCategories").ToList();
        }

        public void CreatePages(PageTemplate page)
        {
            _databaseContext.PageTemplates.Add(page);
            _databaseContext.SaveChanges();
        }

        public void DeletePage(PageTemplate page)
        {
            var PageToDelete = ReadPages().FirstOrDefault(p => p.Id == page.Id);
            _databaseContext.PageTemplates.Remove(PageToDelete);
            _databaseContext.SaveChanges();
        }

        public void UpdatePage(PageTemplate page)
        {
            var pageToEdit = ReadPages().FirstOrDefault(p => p.Id == page.Id);
            pageToEdit.Content = page.Content;
            pageToEdit.Created = page.Created;
            pageToEdit.Edited = page.Edited;
            pageToEdit.Title = page.Title;
            _databaseContext.SaveChanges();
        }


        public List<PageCategory> ReadPageCategory()
        {
            return _databaseContext.PageCategories.ToList();
        }

        public void CreatePageCategory(PageCategory category)
        {
            _databaseContext.PageCategories.Add(category);
            _databaseContext.SaveChanges();
        }

        public void DeletePageCategory(PageCategory category)
        {
            var categoryToDelete = ReadPageCategory().FirstOrDefault(p => p.Id == category.Id);
            _databaseContext.PageCategories.Remove(categoryToDelete);
            _databaseContext.SaveChanges();
        }

        public void UpdatePageCategory(PageCategory category)
        {
            var categoryToEdit = ReadPageCategory().FirstOrDefault(p => p.Id == category.Id);
            if (categoryToEdit != null) categoryToEdit.Name = category.Name;
            _databaseContext.SaveChanges();
        }


      
    }

}