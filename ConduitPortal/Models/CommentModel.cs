using FjtFramework.Cores;
using System.Text.Json.Serialization;

namespace ConduitPortal.Models
{
    public class CommentModel : BaseEntity
    {
        public string Body { get; set; }

        public PersonModel Author { get; set; }

        [JsonIgnore]
        public int AuthorId { get; set; }

        [JsonIgnore]
        public ArticleModel Article { get; set; }

        [JsonIgnore]
        public int ArticleId { get; set; }
    }
}
