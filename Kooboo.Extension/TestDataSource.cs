using Kooboo.Data.Interface;
using Kooboo.Sites.DataSources;
using Kooboo.Sites.Render;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kooboo.Extension
{
    public class TestDataSource : SiteDataSource
    {
        public FrontContext Context { get; internal set; }

        [Kooboo.Attributes.ReturnType(typeof(Int32))]
        public int Test()
        {
            return 34;
        }
    }
}
