using FjtFramework.Cores;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConduitPortal.Models
{
    public class CommentModel : BaseEntity
    {
        public string Body { get; set; }


        [ForeignKey("Article")]
        public int ArticleId { get; set; }


        public virtual ArticleModel Article { get; set; }

    }
}
