using AutoMapper;
using ConduitPortal.Models;
using ConduitPortal.Validation;
using FjtFramework.Cores;
using FluentValidation;

namespace ConduitPortal.ViewModels
{
    public class ArticleViewModel : BaseViewModel
    {



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
