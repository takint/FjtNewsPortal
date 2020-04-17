using ConduitPortal.ViewModels;
using FjtFramework.Cores;
using FluentValidation;

namespace ConduitPortal.Validation
{
    public class ArticleValidation : BaseValidation<ArticleViewModel>
    {
        public ArticleValidation()
        {
            RuleFor(c => c.CreatedUser).NotEmpty();
            RuleFor(c => c.CreatedDate).NotEmpty();

            RuleFor(c => c.RowVersion).NotEmpty().When(c => c.Id > 0);
            RuleFor(c => c.UpdatedUser).NotEmpty().When(c => c.Id > 0);
            RuleFor(c => c.UpdatedDate).NotEmpty().When(c => c.Id > 0);
        }
    }
}
