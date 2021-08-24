using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using SitecorePrj.CommonCode;
using SitecorePrj.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecorePrj.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchKey(FormCollection form)
        {
            string query = form["searchInput"];
            List<ArticlesModel> AM = new List<ArticlesModel>();
            HomePage homePage = new HomePage();
            AM = homePage.FUNC();
            List<ArticlesModel> results = null;

            results = AM.FindAll(Findtitle);

            bool Findtitle(ArticlesModel AMp)
            {
                if (AMp.Title.Contains(query) || AMp.Category.Contains(query) || AMp.SmallDescription.Contains(query))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return View("~/Views/SitecorePrj/ArticlesList.cshtml", results);
        }
    }
}