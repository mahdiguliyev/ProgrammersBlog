using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IArticleRepository Articles { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        Task<int> SaveAsync();
    }
}
