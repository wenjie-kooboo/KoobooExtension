using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Sites.Extensions;
using System;

namespace Kooboo.Extension
{
    public class CodeKScript : IkScript
    {
        public string Name => "Code";

        public RenderContext context { get; set; }

        /// <summary>
        /// Execute code for view (k.ex.code.load)
        /// </summary>
        /// <param name="codeNames">Code/Script names or ids</param>
        public void Load(params string[] codeNames)
        {
            if (codeNames.Length == 0)
            {
                var frontcontext = context.GetItem<Kooboo.Sites.Render.FrontContext>();
                var viewName = frontcontext.ExecutingView.Name;
                codeNames = new string[] { viewName };
            }
            Array.ForEach(codeNames, name =>
            {
                var executedKey = $"__code_{name}__";
                var executed = context.GetItem<bool>(executedKey);
                if (!executed)
                {
                    var siteDb = context.WebSite.SiteDb();
                    if (name.EndsWith(".js", StringComparison.OrdinalIgnoreCase))
                    {
                        var script = siteDb.Scripts.GetByNameOrId(name);
                        if (script != null)
                        {
                            Kooboo.Sites.Scripting.Manager.ExecuteCode(context, script.Body);
                        }
                    }
                    else
                    {
                        var code = siteDb.Code.GetByNameOrId(name);
                        if (code != null)
                        {
                            Kooboo.Sites.Scripting.Manager.ExecuteCode(context, code.Body, code.Id);
                        }
                    }
                    context.SetItem(true, executedKey);
                }
            });
        }
    }
}
