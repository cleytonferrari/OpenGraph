using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Helpers
{
    public class MetaOpenGraph
    {
        private OpenGraph openGraph { get; set; }
        public MetaOpenGraph(OpenGraph openGraph)
        {
            this.openGraph = openGraph;
        }

        public MvcHtmlString Seo()
        {
            var metas = "";
            metas += "\n\t<!-- Open Graph TISelvagem.com.br : SEO -->";

            metas += MontaMeta("description", openGraph.Description);
            metas += MontaMeta("canonical", openGraph.Url);

            metas += "\n\t<!-- /Open Graph TISelvagem.com.br : SEO -->";
            return new MvcHtmlString(metas);
        }

        public MvcHtmlString Twitter()
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Twitter -->";

            meta += MontaMeta("twitter:card", openGraph.TwitterCard);
            meta += MontaMeta("twitter:site", openGraph.TwitterSite);
            meta += MontaMeta("twitter:creator", openGraph.TwitterCreator);
            meta += MontaMeta("twitter:title", openGraph.Title);
            meta += MontaMeta("twitter:description", openGraph.Description);
            meta += MontaMeta("twitter:image:src", openGraph.ImageSrc);
            meta += MontaMeta("twitter:domain", openGraph.Domain);
            meta += MontaMeta("twitter:url", openGraph.Url);
            //todo: adicionar as outras tags dos apps

            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Twitter -->";
            return new MvcHtmlString(meta);
        }

        public MvcHtmlString Facebook()
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Facebook -->";

            meta += MontaMeta("fb:admins", openGraph.FacebookAdmins);
            meta += MontaMeta("og:url", openGraph.Url);
            meta += MontaMeta("og:type", openGraph.Tipo);
            meta += MontaMeta("og:title", openGraph.Title);
            meta += MontaMeta("og:image", openGraph.ImageSrc);
            meta += MontaMeta("og:description", openGraph.Description);
            meta += MontaMeta("og:site_name", openGraph.SiteName);
            meta += MontaMeta("og:locale", openGraph.Locale);
            meta += MontaMeta("article:author", openGraph.FacebookAuthor);
            meta += MontaMeta("article:publisher", openGraph.FacebookPublisher);
            meta += MontaMeta("article:section", openGraph.FacebookSection);

            meta = openGraph.Tags.Split(',').Aggregate(meta, (current, tag) => current + MontaMeta("article:tag", tag));


            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Facebook -->";
            return new MvcHtmlString(meta);
        }

        public MvcHtmlString GooglePlus()
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Google Plus -->";

            meta += String.Format("\n\t<link rel=\"author\" href=\"{0}\" />", openGraph.GooglePlusAuthor);
            meta += String.Format("\n\t<meta itemprop=\"name\" content=\"{0}\">", openGraph.Title);
            meta += String.Format("\n\t<meta itemprop=\"description\" content=\"{0}\">", openGraph.Description);
            meta += String.Format("\n\t<meta itemprop=\"image\" content=\"{0}\">", openGraph.ImageSrc);

            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Google Plus -->";
            return new MvcHtmlString(meta);
        }

        public MvcHtmlString Todos()
        {
            return new MvcHtmlString(Seo() + "\n" + Twitter() + "\n" + Facebook() + "\n" + GooglePlus());
        }

        private static string MontaMeta(string name, string content)
        {
            return String.Format("\n\t<meta name=\"{0}\" content=\"{1}\">", name, content);
        }
    }
}