using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kooboo.Extension
{
    public class TestDashBoard : IDashBoard
    {
        public string Name => "Test";

        public string DisplayName(RenderContext Context)
        {
            return Data.Language.Hardcoded.GetValue(Name, Context);
        }

        public IDashBoardResponse Render(RenderContext Context)
        {
            var html = new DashBoardResponseHtml();
            html.Body = $"<h1>{Name}</h1>";
            return html;
        }
    }
}
