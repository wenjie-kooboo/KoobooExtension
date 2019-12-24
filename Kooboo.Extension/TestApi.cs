//Copyright (c) 2018 Yardi Technology Limited. Http://www.kooboo.com 
//All rights reserved.
using Kooboo.Api;
using Kooboo.Sites.Extensions;
using Kooboo.Sites.ViewModel;
using System;
using System.Collections.Generic;

namespace Kooboo.Extension
{
    public class TestApi : IApi
    {
        public string ModelName => "Test";
        public bool RequireSite => true;

        public bool RequireUser => true;

        public dynamic Index(ApiCall call)
        {
            // call.WebSite.SiteDb();
            return new
            {
                name = "hello",
                age = 17
            };
        }
    }

}
