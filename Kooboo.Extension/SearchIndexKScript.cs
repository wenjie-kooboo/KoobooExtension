using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using Kooboo.Data.Models;
using Kooboo.Sites.Extensions;
using Kooboo.Sites.Repository;
using System;
using System.Collections.Generic;

namespace Kooboo.Extension
{
    /// <summary>
    /// k.ex.site.
    /// </summary>
    public class SearchIndexKScript : IkScript
    {
        public string Name => "SearchIndex";

        public RenderContext context { get; set; }

        public SearchIndexRepository Repository => new SearchIndexRepository(context.WebSite.SiteDb());

        public List<SearchResult> Search(string keywords, int top, string highLightAttr) 
            => Repository.Search(keywords, top, highLightAttr, context);

        public List<SearchResult> Search(string keywords) => Search(keywords, int.MaxValue, null);

        public List<SearchResult> Search(string keywords, int top) => Search(keywords, top, null);


        public PagedResult SearchWithPaging(string keywords, int pagesize, int pagenumber, string highLightAttr) 
            => Repository.SearchWithPaging(keywords, pagesize, pagenumber, highLightAttr, context);

        public PagedResult SearchWithPaging(string keywords, int pagesize, int pagenumber) 
            => SearchWithPaging(keywords, pagesize, pagenumber, null);


        public PagedResult SearchByFolders(List<Guid> folderIds, string keywords, int pagesize, int pagenumber, string highLightAttr)
            => Repository.SearchByFolders(folderIds, keywords, pagesize, pagenumber, highLightAttr, context);

        public PagedResult SearchByFolders(List<Guid> folderIds, string keywords, int pagesize, int pagenumber)
           => SearchByFolders(folderIds, keywords, pagesize, pagenumber, null);
    }
}
