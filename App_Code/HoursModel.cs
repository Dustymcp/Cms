using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoursModel
/// </summary>
public class HoursModel
{
    public class Repository
    {
        DatabaseModel databaseContext = new DatabaseModel();

        public List<OpeningHours> Read()
        {
            return databaseContext.OpeningHours.ToList();
        }

        public void Create(OpeningHours openingHours)
        {
            databaseContext.OpeningHours.Add(openingHours);
            databaseContext.SaveChanges();
        }

        public void Update(OpeningHours openingHours)
        {
            var hourToUpdate = databaseContext.OpeningHours.FirstOrDefault(oh => oh.Id == openingHours.Id);
            hourToUpdate.Comment = openingHours.Comment;
            hourToUpdate.Friday = openingHours.Friday;
            hourToUpdate.Monday = openingHours.Monday;
            hourToUpdate.Saturday = openingHours.Saturday;
            hourToUpdate.Sunday = openingHours.Sunday;
            hourToUpdate.Thursday = openingHours.Thursday;
            hourToUpdate.Tuesday = openingHours.Tuesday;
            hourToUpdate.Wednesday = openingHours.Wednesday;
            databaseContext.SaveChanges();
        }

        public void Delete(OpeningHours openingHours)
        {
            var hourToDelete = databaseContext.OpeningHours.FirstOrDefault(oh => oh.Id == openingHours.Id);
            databaseContext.OpeningHours.Remove(hourToDelete);
        }
    }

    public class OpeningHours
    {
        public int Id { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Comment { get; set; }

    }
}