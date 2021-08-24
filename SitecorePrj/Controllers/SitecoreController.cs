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
    public class SitecoreController : Controller
    {
        // GET: Sitecore
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [AllowAnonymous] 
        public ActionResult ArticleListComponent(FormCollection form)
        {
            string query = form["searchInput"];
            List<ArticlesModel> AM = new List<ArticlesModel>();
            HomePage homePage = new HomePage();
            AM = homePage.FUNC();

            if (query != null) 
            {
                List<ArticlesModel> results = null;

                results = AM.FindAll(Findtitle);

                bool Findtitle(ArticlesModel AMp)
                {
                    if (AMp.Title.ToLower().Contains(query.ToLower()) || AMp.Category.ToLower().Contains(query.ToLower()) || AMp.SmallDescription.ToLower().Contains(query.ToLower()))
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
            return View("~/Views/SitecorePrj/ArticlesList.cshtml", AM);
        }

    }
}