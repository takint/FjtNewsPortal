using FjtFramework.Cores;
using System;
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

        public PersonModel Author { get; set; }

        public List<CommentModel> Comments { get; set; }


        [NotMapped]
        public List<string> TagList => (ArticleTags?.Select(x => x.TagId) ?? Enumerable.Empty<string>()).ToList();

        [JsonIgnore]
        public List<ArticleTagModel> ArticleTags { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
