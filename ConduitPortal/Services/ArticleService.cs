using AutoMapper;
using ConduitPortal.Models;
using ConduitPortal.ViewModels;
using FjtFramework.CoreServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ConduitPortal.Services
{
    public class ArticleService : BaseService<ArticleModel, PortalDbContext>, IArticleService
    {
        public ArticleService(PortalDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<ArticleViewModel> GetArticleBySlug(string slug)
        {
            var model = await _dbSet.SingleOrDefaultAsync(a => a.Slug.Equals(slug));
            return _mapper.Map<ArticleViewModel>(model);
        }
    }
}
