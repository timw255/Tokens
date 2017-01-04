using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.Tokens.Configuration
{
    // register in global.asax (bootstrapper section) - Config.RegisterSection<TokensConfig>();
    [ObjectInfo(Title = "Tokens Config", Description = "TokensConfig")]
    public class TokensConfig : ConfigSection
    {
        [ConfigurationCollection(typeof(TokenConfigElement), AddItemName = "tokens")]
        [ConfigurationProperty("tokens")]
        [ObjectInfo(Title = "Tokens", Description = "")]
        public ConfigElementDictionary<string, TokenConfigElement> Tokens
        {
            get
            {
                return (ConfigElementDictionary<string, TokenConfigElement>)this["tokens"];
            }
        }
    }
}