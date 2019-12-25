using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Sites.Render;
using Kooboo.Sites.Render.Components;
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
        public string Execute(string name, object parameters)
        {
            return ExecuteAsync(name, parameters)?.Result;
        }

        public string Execute(string name)
        {
            return Execute(name, null);
        }

        private async Task<string> ExecuteAsync(string name, object parameters)
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
                if(parameters != null)
                {
                    newcontext.DataContext.Push("exView", parameters);
                }
                viewresult = await ViewComponent.RenderAsync(newcontext, setting);
            }
            return viewresult;
        }
    }
}
