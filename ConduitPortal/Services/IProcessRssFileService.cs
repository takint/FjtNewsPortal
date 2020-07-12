using System.Collections.Generic;

namespace ConduitPortal.Services
{
    interface IProcessRssFileService<T>
    {
        List<T> LoadNewsFromRss(string rssFilePath);

        T ExtractNewsItem(string docContent);
    }
}
