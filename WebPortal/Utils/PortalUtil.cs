using ConduitPortal.ViewModels;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace WebPortal.Utils
{
    public static class PortalUtil
    {
        const string SLUG_PATTER = @"\b\/.+$";
        private static readonly Regex slugReg = new Regex(SLUG_PATTER);

        public static async Task<List<ArticleViewModel>> LoadNewsFromRss(string rssFilePath = "./wwwroot/rss/tin-moi-nhat.rss")
        {
            // Link to download rss
            // https://vnexpress.net/rss

            StreamReader sr = new StreamReader(rssFilePath);
            XmlReader reader = XmlReader.Create(sr);

            List<SyndicationItem> newsFeed = SyndicationFeed.Load(reader).Items.ToList();
            List<ArticleViewModel> results = new List<ArticleViewModel>();

            await Task.Run(() =>
            {
                foreach (var item in newsFeed)
                {
                    var newsItem = ExtractNewsItem(item.Summary.Text);
                    if (newsItem != null)
                    {
                        newsItem.Title = item.Title.Text;
                        newsItem.CreatedDate = item.PublishDate.UtcDateTime;
                        newsItem.CreatedUser = "admin";
                        results.Add(newsItem);
                    }
                }
            });

            sr.Close();

            return results;
        }


        public static ArticleViewModel ExtractNewsItem(string docContent)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(docContent);

            var root = htmlDoc.DocumentNode.SelectSingleNode("//a");

            if (root == null) return null;

            var newsUrl = root.Attributes["href"].Value;
            var newsFeatureImg = root.SelectSingleNode("//img").Attributes["src"].Value;
            var newsSummary = htmlDoc.DocumentNode.InnerText;


            ArticleViewModel model = new ArticleViewModel
            {
                FeatureImage = newsFeatureImg,
                Description = newsSummary,
                Body = newsUrl,
                Slug = slugReg.Match(newsUrl).Value,
            };

            return model;
        }
    }
}
