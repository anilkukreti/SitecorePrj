using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecorePrj.Models
{
    public class ArticlesModel
    {
        public string key { get; set; }
        public string ID { get; set; }
        public  string Category { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public string SmallDescription { get; set; }
        public string imageSrc { get; set; }
        public string imageAlt { get; set; }
        public string ButtonText { get; set; }
        public ArticlesModel(string ID, string Category, string Title, string CreatedDate, string SmallDescription, string imageSrc, string imageAlt, string ButtonText)
        {
            this.ID = ID;
            this.Category = Category;
            this.Title = Title;
            this.CreatedDate = CreatedDate;
            this.SmallDescription = SmallDescription;
            this.imageSrc = imageSrc;
            this.imageAlt = imageAlt;
            this.ButtonText = ButtonText;
        }
    }
}