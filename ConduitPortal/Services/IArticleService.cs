using ConduitPortal.ViewModels;
using FjtFramework.Interfaces;
using System.Threading.Tasks;

namespace ConduitPortal.Services
{
    public interface IArticleService : IBaseService
    {
        Task<ArticleViewModel> GetArticleBySlug(string slug);
    }
}
