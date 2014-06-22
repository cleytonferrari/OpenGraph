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
            var meta = new StringBuilder();
            meta.Append("<!-- Open Graph TISelvagem.com.br : SEO Tags -->\n\t");

            meta.Append(String.Format("<meta name=\"description\" content=\"{0}\">\n\t", description));
            meta.Append(String.Format("<link rel=\"canonical\" href=\"{0}\">\n\t", canonical));

            meta.Append("<!-- /Open Graph TISelvagem.com.br : SEO Tags -->\n\t");
            return new MvcHtmlString(meta.ToString());
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
        public static MvcHtmlString OpenGraph_Twitter(this HtmlHelper helper, string twitterSite = "", string twitterCreator = "", string title = "", string description = "", string imgSrc = "", string domain = "", string url = "", string card = "summary_large_image")
        {
            var meta = new StringBuilder();
            meta.Append("<!-- Open Graph TISelvagem.com.br : Twitter Tags -->\n\t");

            meta.Append(String.Format("<meta name=\"twitter:card\" content=\"{0}\">\n\t", card));
            meta.Append(String.Format("<meta name=\"twitter:site\" content=\"@{0}\">\n\t", twitterSite));
            meta.Append(String.Format("<meta name=\"twitter:creator\" content=\"@{0}\">\n\t", twitterCreator));
            meta.Append(String.Format("<meta name=\"twitter:title\" content=\"{0}\">\n\t", title));
            meta.Append(String.Format("<meta name=\"twitter:description\" content=\"{0}\">\n\t", description));
            meta.Append(String.Format("<meta name=\"twitter:image:src\" content=\"{0}\">\n\t", imgSrc));
            meta.Append(String.Format("<meta name=\"twitter:domain\" content=\"{0}\">\n\t", domain));
            meta.Append(String.Format("<meta name=\"twitter:url\" content=\"{0}\">\n\t", url));
            //todo: adicionar as outras tags dos apps
            meta.Append("<!-- /Open Graph TISelvagem.com.br : Twitter Tags -->\n\t");
            return new MvcHtmlString(meta.ToString());
        }
    }
}