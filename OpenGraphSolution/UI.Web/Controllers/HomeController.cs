using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UI.Web.Helpers;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private OpenGraph openGraph;
        public HomeController()
        {
            //Seta os valores padrões
            openGraph = new OpenGraph()
            {
                SiteName = "TI Selvagem",
                Locale = "pt-BR",
                Domain = "tiselvagem.com.br",
                FacebookAdmins = "cleytonferrari",
                FacebookPublisher = "https://www.facebook.com/tiselvagem",
                FacebookAuthor = "https://www.facebook.com/cleytonferrari",
                GooglePlusAuthor = "https://plus.google.com/+cleytonferrari",
                TwitterCard = "summary_large_image",
                TwitterSite = "@TISelvagem",
                TwitterCreator = "@CleytonFerrari",
                FacebookSection = "Tecnologia",
                Tags = "MVC",
                Description = "Comunidade ASP.Net MVC",
                Url = "http://www.tiselvagem.com.br",
                Tipo = "article",
                Title = "TI Selvagem - ASP .Net MVC",
                ImageSrc = "http://opengraph.apphb.com/Content/TISelvagemPost.png"
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            openGraph.Title = "Open Graph - Página Inicial";
            openGraph.Url = Request.Url.ToString();
            openGraph.Description = "Página inicial do projeto Open Graph em ASP .Net MVC";
            openGraph.Tags = "ASP .Net, MVC, C#, POO";
            ViewBag.OpenGraph = new MetaOpenGraph(openGraph).Todos();

            return View();
        }

        public ActionResult Sobre()
        {
            openGraph.Title = "Open Graph - Sobre";
            openGraph.Url = Request.Url.ToString();
            openGraph.Description = "Saiba mais sobre o Open Graph";
            ViewBag.OpenGraph = new MetaOpenGraph(openGraph).Todos();
            return View();
        }
    }
}