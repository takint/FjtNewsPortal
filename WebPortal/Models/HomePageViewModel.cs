using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace WebPortal.Models
{
    public class HomePageViewModel
    {
        public List<SyndicationItem> NewFeeds { get; set; }
    }
}
