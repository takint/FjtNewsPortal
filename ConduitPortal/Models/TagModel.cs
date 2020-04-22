using FjtFramework.Cores;
using System.Collections.Generic;

namespace ConduitPortal.Models
{
    public class TagModel : Entity
    {
        public string TagId { get; set; }

        public virtual ICollection<ArticleTagModel> ArticleTags { get; set; }
    }
}
