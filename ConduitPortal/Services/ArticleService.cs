using AutoMapper;
using ConduitPortal.Models;
using FjtFramework.CoreServices;

namespace ConduitPortal.Services
{
    public class ArticleService : BaseService<ArticleModel, PortalDbContext>, IArticleService
    {
        public ArticleService(PortalDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
