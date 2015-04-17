using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SettingsModel
/// </summary>
public class SettingsModel
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        public int Image { get; set; }
        public string SiteName { get; set; }
        public string PageInfo { get; set; }
        public string FooterInfo { get; set; }
        public bool ContactModel { get; set; }
        public bool PriceModel { get; set; }
        public bool OpeningModel { get; set; }
        public bool ProductModel { get; set; }
        public string Mapembedlink { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Repository
    {
        DatabaseModel _databaseContext = new DatabaseModel();

        public List<Setting> Read()
        {
            return _databaseContext.Setting.ToList();
        }

        public void Create(Setting setting)
        {
            _databaseContext.Setting.Add(setting);
            _databaseContext.SaveChanges();
        }

        public void Update(Setting setting)
        {
            var SettingToUpdate = Read().FirstOrDefault(s => s.Id == setting.Id);
            SettingToUpdate.FooterInfo = setting.FooterInfo;
            SettingToUpdate.Image = setting.Image;
            SettingToUpdate.PageInfo = setting.PageInfo;
            SettingToUpdate.SiteName = setting.SiteName;
            _databaseContext.SaveChanges();
        }


    }
}