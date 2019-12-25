using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Sites.Render;
using Kooboo.Sites.Render.Components;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Kooboo.Extension
{
    public class ViewKScript : IkScript
    {
        public string Name => "View";

        public RenderContext context { get; set; }

        /// <summary>
        /// k.ex.view.execute
        /// </summary>
        public string Execute(string name, ExpandoObject jsObject = null)
        {
            return ExecuteAsync(name, jsObject)?.Result;
        }

        private async Task<string> ExecuteAsync(string name, ExpandoObject jsObject)
        {
            var setting = new ComponentSetting()
            {
                TagName = "view",
                NameOrId = name
            };
            var ViewComponent = Container.Get("view");
            string viewresult = null;
            if (ViewComponent != null)
            {
                var newcontext = new RenderContext();
                newcontext.Request = context.Request;
                newcontext.User = context.User;
                newcontext.WebSite = context.WebSite;
                newcontext.Culture = context.Culture;

                var kooboocontext = new FrontContext();
                newcontext.SetItem(kooboocontext);
                kooboocontext.RenderContext = newcontext;
                if (jsObject != null)
                {
                    var parameters = new Dictionary<string, object>();
                    foreach (var item in jsObject)
                    {
                        parameters.Add(item.Key, item.Value);
                    }
                    newcontext.DataContext.Push(parameters);
                }
                viewresult = await ViewComponent.RenderAsync(newcontext, setting);
            }
            return viewresult;
        }
    }
}
