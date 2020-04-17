using FjtFramework.Cores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace ConduitPortal.Models
{
    public class ArticleModel : BaseEntity
    {
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public string FeatureImage { get; set; }

        public ArticleStatus CurrentStatus { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual PersonModel Author { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }


        [NotMapped]
        public List<string> TagList => (ArticleTags?.Select(x => x.TagId) ?? Enumerable.Empty<string>()).ToList();

        [JsonIgnore]
        public virtual ICollection<ArticleTagModel> ArticleTags { get; set; }
    }
}
