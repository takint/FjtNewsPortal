using ConduitPortal;
using ConduitPortal.Models;
using ConduitPortal.ViewModels;
using FjtFramework.Cores;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace FetchNews
{
    class Program
    {
        const string SLUG_PATTER = @"\b\/.+$";
        private static readonly Regex slugReg = new Regex(SLUG_PATTER);

        static void Main(string[] args)
        {
            List<ArticleModel> lstNews = LoadNewsFromRss("./newsfeed/startup.rss");
            StoreNewsToDb(lstNews);
            Console.WriteLine("News Loaded!");
        }


        private static int StoreNewsToDb(List<ArticleModel> lstArticles)
        {
            using (PortalDbContext dbContext = new PortalDbContext())
            {
                dbContext.Articles.AddRange(lstArticles);
                dbContext.SaveChanges();
            }

            return 0;
        }

        private static List<ArticleModel> LoadNewsFromRss(string rssFilePath)
        {
            StreamReader sr = new StreamReader(rssFilePath);
            XmlReader reader = XmlReader.Create(sr);

            List<SyndicationItem> newsFeed = SyndicationFeed.Load(reader).Items.ToList();
            List<ArticleModel> results = new List<ArticleModel>();

            foreach (var item in newsFeed)
            {
                var newsItem = ExtractNewsItem(item.Summary.Text);
                if (newsItem != null)
                {
                    newsItem.Title = item.Title.Text;
                    newsItem.CreatedDate = item.PublishDate.UtcDateTime;
                    newsItem.CreatedUser = "admin";
                    newsItem.AuthorId = 1;
                    newsItem.CurrentStatus = ArticleStatus.Published;
                    results.Add(newsItem);
                }
            }

            sr.Close();

            return results;
        }


        private static ArticleModel ExtractNewsItem(string docContent)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(docContent);

            var root = htmlDoc.DocumentNode.SelectSingleNode("//a");

            if (root == null) return null;

            var newsUrl = root.Attributes["href"].Value;
            var newsFeatureImg = root.SelectSingleNode("//img").Attributes["src"].Value;
            var newsSummary = htmlDoc.DocumentNode.InnerText;


            ArticleModel model = new ArticleModel
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
