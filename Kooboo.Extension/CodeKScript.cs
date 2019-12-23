using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Sites.Extensions;
using Kooboo.Sites.Render;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kooboo.Extension
{
    public class CodeKScript : IkScript
    {
        public string Name => "Code";

        public RenderContext context { get; set; }

        const string CODE_REQUIRE = "k.ex.code.require";

        /// <summary>
        ///  Include codes or scripts (k.ex.code.require)
        /// </summary>
        /// <param name="codeNames">Code/Script names or ids</param>
        public void Require(params string[] codeNames)
        {
            if (codeNames.Length == 0)
            {
                var frontcontext = context.GetItem<FrontContext>();
                var viewName = frontcontext.ExecutingView.Name;
                codeNames = new string[] { viewName };
            }
            var codes = context.GetItem<List<string>>(CODE_REQUIRE) ?? new List<string>();
            var siteDb = context.WebSite.SiteDb();
            Array.ForEach(codeNames, name =>
            {
                var executed = codes.Contains(name, StringComparer.OrdinalIgnoreCase);
                if (!executed)
                {
                    codes.Add(name);
                    context.SetItem(codes, CODE_REQUIRE);
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
                }
            });
        }
    }
}
