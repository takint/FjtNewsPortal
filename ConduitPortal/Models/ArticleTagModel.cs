using FjtFramework.Cores;

namespace ConduitPortal.Models
{
    public class ArticleTagModel : Entity
    {
        public int ArticleId { get; set; }
        public ArticleModel Article { get; set; }

        public string TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
