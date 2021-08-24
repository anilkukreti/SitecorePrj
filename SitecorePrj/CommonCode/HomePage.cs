using SitecorePrj.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SitecorePrj.CommonCode
{
    public class HomePage
    {
        public List<ArticlesModel> FUNC()
        {

            List<ArticlesModel> AM = new List<ArticlesModel>();
            var item = Sitecore.Context.Database.GetItem("{0E20BDE8-935C-41A9-B3CC-42A33B6C76FE}");
            Sitecore.Data.Fields.MultilistField ArticleList = item.Fields["ArticleList"];
            if (ArticleList != null)
            {
                foreach (Sitecore.Data.Items.Item I in ArticleList.GetItems())
                {
                    var ID = I.ID.ToString();
                    var CreatedDate = DateTime.ParseExact(I.Fields["createddate"].Value, "yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    var Title = I.Fields["title"].Value;
                    var SmallDescription = I.Fields["smalldescription"].Value;
                    var Image = I.Fields["smallimages"].Value;

                    Sitecore.Data.Fields.ImageField imageField = I.Fields["smallimages"];
                    Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                    string imageSrc = Sitecore.StringUtil.EnsurePrefix('/',
                    Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                    var Buttontext = item.Fields["CardButtonText"].Value;

                    //string imgTag = String.Format(@"<img src=""{0}"" alt=""{1}"" />", src, image.Alt);

                    AM.Add(new ArticlesModel(ID, "", Title, CreatedDate, SmallDescription, imageSrc, image.Alt, Buttontext));
                }
            }

            return AM;

        }

    }
}