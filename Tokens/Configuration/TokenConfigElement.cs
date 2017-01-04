using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.Tokens.Configuration
{
    public class TokenConfigElement : ConfigElement
    {
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        [ObjectInfo(Title = "Key", Description = "")]
        public virtual string Key
        {
            get
            {
                return (string)this["key"];
            }
            set
            {
                this["key"] = value;
            }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        [ObjectInfo(Title = "Value", Description = "")]
        public virtual string Value
        {
            get
            {
                return (string)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }

        public TokenConfigElement(ConfigElement parent)
            : base(parent)
        {
        }
    }
}