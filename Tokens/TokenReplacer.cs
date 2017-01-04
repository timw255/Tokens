using SitefinityWebApp.Tokens.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Frontend.Mvc.Helpers;
using Telerik.Sitefinity.Web.Events;

namespace SitefinityWebApp.Tokens
{
    public class TokenReplacer
    {
        private static TokensConfig tokenConfig = Config.Get<TokensConfig>();
        private static List<string> _tokenize = new List<string>() { ".txt" };

        public static void OnPagePreRenderCompleteEventHandler(IPagePreRenderCompleteEvent e)
        {
            if (!e.PageSiteNode.IsBackend) 
            {
                if (!Path.HasExtension(e.Page.Request.Url.AbsolutePath) ||
                    (Path.HasExtension(e.Page.Request.Url.AbsolutePath) && _tokenize.Contains(Path.GetExtension(e.Page.Request.Url.AbsolutePath).ToLower())))
                {
                    e.Page.Response.Filter = new TokenizedStream(e.Page.Response.Filter);
                }
            }
        }
    }
}