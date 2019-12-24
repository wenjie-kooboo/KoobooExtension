using Kooboo.Data.Context;
using Kooboo.Sites.Render.Functions;
using System;
using System.Collections.Generic;

namespace Kooboo.Extension
{
    public class TestFunction : IFunction
    {
        public string Name => "Test";

        public List<IFunction> Parameters { get; set; }

        public object Render(RenderContext context)
        {
            var paras = FunctionHelper.RenderParameter(context, this.Parameters);
            return paras[0];
            //var max = Convert.ToInt32(paras[1]);
            //var min = Convert.ToInt32(paras[0]);

            //return max + min;
        }
    }
}
