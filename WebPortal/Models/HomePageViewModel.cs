using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace WebPortal.Models
{
    public class HomePageViewModel : LayoutViewModel
    {
        public HomePageViewModel()
        {
            MidPageAdv = new List<string>
            {
                "<img src=\"/assets/adv3.png\" />",
                "<img src=\"/assets/adv4.png\" />",
                "<img src=\"/assets/adv5.png\" />"
            };

            FootPageAdv = new List<string>
            {
                "<img src=\"/assets/adv6.png\" />",
                "<img src=\"/assets/adv7.png\" />",
                "<img src=\"/assets/adv8.png\" />"
            };
        }

        public List<SyndicationItem> NewFeeds { get; set; }

        public List<SyndicationItem> BusinessNews { get; set; }

        public List<SyndicationItem> ShoppingNews { get; set; }

        public List<string> MidPageAdv { get; set; }

        public List<string> FootPageAdv { get; set; }
    }
}
