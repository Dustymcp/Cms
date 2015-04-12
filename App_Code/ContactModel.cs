using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactModel
/// </summary>
public class ContactModel
{
    public class Repository
    {
        DatabaseModel DatabaseContext = new DatabaseModel();

        public List<Mail> ReadMail()
        {
            return DatabaseContext.Mails.ToList();
        }

        public void CreateMail(Mail mail)
        {
            DatabaseContext.Mails.Add(mail);
            DatabaseContext.SaveChanges();
        }

        public void DeleteMail(Mail mail)
        {
            DatabaseContext.Mails.Remove(mail);
            DatabaseContext.SaveChanges();
        }

        public void SetMailRead(Mail mail)
        {
            var mailToSetRead = ReadMail().FirstOrDefault(m => m.Id == mail.Id);
            if (mailToSetRead != null) mailToSetRead.Watched = true;
            DatabaseContext.SaveChanges();
        }
        
    }
    public class Mail
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public bool Watched { get; set; }
        public DateTime Created {get; set; }
    }
}