using Kooboo.Data.Context;
using Kooboo.Data.Language;
using Kooboo.Web.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kooboo.Extension
{
    public class TestSiteBar : ISideBarMenu
    {
        public SideBarSection Parent => SideBarSection.Root;

        public string Name => "TestBar";

        public string Icon => "icon fa fa-money";

        public string Url => "TestBar/Index";

        public int Order => 10;

        public List<ICmsMenu> SubItems { get; set; }

        public string GetDisplayName(RenderContext Context)
        {
            return Hardcoded.GetValue("TestBar", Context);
        }
    }
}
