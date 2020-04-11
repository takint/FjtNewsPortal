using FjtFramework.Cores;
using System.Collections.Generic;

namespace ConduitPortal.Models
{
    public class TagModel : Entity
    {
        public string TagId { get; set; }

        public List<ArticleTagModel> ArticleTags { get; set; }
    }
}
