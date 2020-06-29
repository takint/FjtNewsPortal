using AutoMapper;
using ConduitPortal.Mapping;
using ConduitPortal.Models;
using ConduitPortal.Validation;
using FjtFramework.Cores;
using FluentValidation;

namespace ConduitPortal.ViewModels
{
    public class ArticleViewModel : BaseViewModel, ICreateMapping
    {
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public string FeatureImage { get; set; }

        public ArticleStatus CurrentStatus { get; set; }

        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<ArticleModel, ArticleViewModel>()
                .IncludeBase<BaseEntity, BaseViewModel>();

            profile.CreateMap<ArticleViewModel, ArticleModel>()
                .IncludeBase<BaseViewModel, BaseEntity>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }

        public override void ValidateAndThrow()
        {
            new ArticleValidation().ValidateAndThrow(this);
        }
    }
}
