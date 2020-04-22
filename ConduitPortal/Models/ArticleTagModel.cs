using FjtFramework.Cores;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConduitPortal.Models
{
    public class ArticleTagModel : Entity
    {
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual ArticleModel Article { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public virtual TagModel Tag { get; set; }
    }
}
