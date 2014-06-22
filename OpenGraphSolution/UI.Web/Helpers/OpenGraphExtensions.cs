using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Helpers
{
    public static class OpenGraphExtensions
    {
        /// <summary>
        /// Gera as metas tags necessárias para os mecanismos de buscas
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="description">Breve descrição do conteudo da página</param>
        /// <param name="canonical">Url para página. Ex.: http://www.tiselvagem.com.br</param>
        /// <returns>String com as metas tags</returns>
        public static MvcHtmlString OpenGraph_Seo(this HtmlHelper helper, string description = "", string canonical = "")
        {
            var metas = "";
            metas += "\n\t<!-- Open Graph TISelvagem.com.br : SEO -->";
            
            metas += MontaMeta("description", description);
            metas += MontaMeta("canonical", canonical);

            metas += "\n\t<!-- /Open Graph TISelvagem.com.br : SEO -->";
            return new MvcHtmlString(metas);
        }

        /// <summary>
        /// Gera as metas tags necessárias para os cards do Twitter
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="card">Tipo de card do Twitter. Opções ["summary_large_image","summary","product","photo","player","app"]</param>
        /// <param name="twitterSite">Twitter do Site. Ex.: TISelvagem</param>
        /// <param name="twitterCreator">Twitter do Autor. Ex.: CleytonFerrari</param>
        /// <param name="title">Titulo da postagem no Twitter</param>
        /// <param name="description">Breve descrição do conteúdo da página</param>
        /// <param name="imgSrc">Caminho da imagem. Ex.: http://www.tiselvagem.com.br/logo.png </param>
        /// <param name="domain">Dominio da conta no Twitter: tiselvagem.com</param>
        /// <param name="url">URL da página. Ex.: http://www.tiselvagem.com.br</param>
        /// <returns>String com as metas tags</returns>
        public static MvcHtmlString OpenGraph_Twitter(this HtmlHelper helper, string twitterSite = "", string twitterCreator = "", string title = "",
            string description = "", string imgSrc = "", string domain = "", string url = "", string card = "summary_large_image")
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Twitter -->";

            meta += MontaMeta("twitter:card", card);
            meta += MontaMeta("twitter:site", twitterSite);
            meta += MontaMeta("twitter:creator", twitterCreator);
            meta += MontaMeta("twitter:title", title);
            meta += MontaMeta("twitter:description", description);
            meta += MontaMeta("twitter:image:src", imgSrc);
            meta += MontaMeta("twitter:domain", domain);
            meta += MontaMeta("twitter:url", url);
            //todo: adicionar as outras tags dos apps

            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Twitter -->";
            return new MvcHtmlString(meta);
        }

        /// <summary>
        /// Gera as metas tags necessárias para as publicações no Facebook
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="admins">Id do administrador da página no facebook, que pode ser o ID numerico ou nome do usuario. Ex.: cleytonferrari</param>
        /// <param name="url">URL da página. Ex.: http://www.tiselvagem.com.br</param>
        /// <param name="tipo">Tipo de publicação.</param>
        /// <param name="title">Titulo da postagem</param>
        /// <param name="imgSrc">Caminho da imagem. Ex.: http://www.tiselvagem.com.br/logo.png </param>
        /// <param name="description">Breve descrição do conteúdo da página</param>
        /// <param name="siteName">Nome do Site. Ex.: TI Selvagem</param>
        /// <param name="locale">Localização do site. Ex.: pt_BR</param>
        /// <param name="author">Url do perfil do Facebook do autor. Ex.: https://www.facebook.com/cleytonferrari </param>
        /// <param name="publisher">Url da Página no Facebook. Ex.: https://www.facebook.com/tiselvagem </param>
        /// <param name="section">Seção de publicação do site. Ex.: Tecnologia</param>
        /// <param name="tags">Lista de tags separadas por virgula. Ex.: MVC,ASP .Net,C# </param>
        /// <returns>String com as metas tags</returns>
        public static MvcHtmlString OpenGraph_Facebook(this HtmlHelper helper, string admins = "", string url = "", string tipo = "", string title = "",
            string imgSrc = "", string description = "", string siteName = "", string locale = "", string author = "", string publisher = "",
            string section = "", string tags = "")
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Facebook -->";

            meta += MontaMeta("fb:admins", admins);
            meta += MontaMeta("og:url", url);
            meta += MontaMeta("og:type", tipo);
            meta += MontaMeta("og:title", title);
            meta += MontaMeta("og:image", imgSrc);
            meta += MontaMeta("og:description", description);
            meta += MontaMeta("og:site_name", siteName);
            meta += MontaMeta("og:locale", locale);
            meta += MontaMeta("article:author", author);
            meta += MontaMeta("article:publisher", publisher);
            meta += MontaMeta("article:section", section);

            meta = tags.Split(',').Aggregate(meta, (current, tag) => current + MontaMeta("article:tag", tag));


            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Facebook -->";
            return new MvcHtmlString(meta);
        }


        /// <summary>
        /// Gera as metas tags necessárias para as publicações no Google Plus
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="author">Url do perfil do google plus do author. Ex.: https://plus.google.com/+cleytonferrari </param>
        /// <param name="title">Titulo da postagem</param>
        /// <param name="description">Breve descrição do conteúdo da página</param>
        /// <param name="imgSrc">Caminho da imagem. Ex.: http://www.tiselvagem.com.br/logo.png </param>
        /// <returns>String com as metas tags</returns>
        public static MvcHtmlString OpenGraph_GooglePlus(this HtmlHelper helper, string author = "", string title = "", string description = "", string imgSrc = "")
        {
            var meta = "";
            meta += "\n\t<!-- Open Graph TISelvagem.com.br : Google Plus -->";

            meta += String.Format("\n\t<link rel=\"author\" href=\"{0}\" />", author);
            meta += String.Format("\n\t<meta itemprop=\"name\" content=\"{0}\">", title);
            meta += String.Format("\n\t<meta itemprop=\"description\" content=\"{0}\">", description);
            meta += String.Format("\n\t<meta itemprop=\"image\" content=\"{0}\">", imgSrc);

            meta += "\n\t<!-- /Open Graph TISelvagem.com.br : Google Plus -->";
            return new MvcHtmlString(meta);
        }

        /// <summary>
        /// Monta html da Meta Tag
        /// </summary>
        /// <param name="name">Tipo da Meta Tag</param>
        /// <param name="content">Conteúdo da Meta Tag</param>
        /// <returns>String representando a meta tag</returns>
        private static string MontaMeta(string name, string content)
        {
            return String.Format("\n\t<meta name=\"{0}\" content=\"{1}\">", name, content);
        }
    }
}