//Copyright (c) 2018 Yardi Technology Limited. Http://www.kooboo.com 
//All rights reserved.
using Kooboo.Api;
using Kooboo.Data.Context;
using Kooboo.Sites.Extensions;
using Kooboo.Sites.Render;
using Kooboo.Sites.Render.Components;
using Kooboo.Sites.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kooboo.Extension
{
    public class TestApi : IApi
    {
        public string ModelName => "Test";
        public bool RequireSite => true;

        public bool RequireUser => true;

        public dynamic Index(ApiCall call)
        {
            return new
            {
                name = call.WebSite.DisplayName,
                id = call.WebSite.Id
            };
        }

        public List<Sites.Repository.SearchResult> Search(ApiCall call)
        {
            var sitedb = call.WebSite.SiteDb();
            var keyword = System.Net.WebUtility.UrlDecode(call.GetRequestValue("keywords"));
            string tag = "style='font-weight:bold;'";
            return sitedb.SearchIndex.Search(keyword, 99999, tag, call.Context);
        }

        public async Task<string> View(ApiCall call)
        {
            var setting = new ComponentSetting();
            setting.TagName = "view";
            setting.NameOrId = call.GetRequestValue("name");
            var ViewComponent = Sites.Render.Components.Container.Get("view");
            string viewresult = null;
            if (ViewComponent != null)
            {
                var newcontext = new RenderContext();
                newcontext.Request = call.Context.Request;
                newcontext.User = call.Context.User;
                newcontext.WebSite = call.Context.WebSite;
                newcontext.Culture = call.Context.Culture;

                FrontContext kooboocontext = new FrontContext();
                newcontext.SetItem<FrontContext>(kooboocontext);
                kooboocontext.RenderContext = newcontext;

                newcontext.DataContext.Push("hello", "nihao");
                viewresult = await ViewComponent.RenderAsync(newcontext, setting);
            }
            return viewresult;
        }
    }

}
