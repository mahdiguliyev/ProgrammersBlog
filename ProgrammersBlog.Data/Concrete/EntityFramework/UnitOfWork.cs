using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _efArticleRepository;
        private EfCategoryRepository _efCategoryRepository;
        private EfCommentRepository _efCommentRepository;
        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }
        
        public IArticleRepository Articles => _efArticleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Categories => _efCategoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _efCommentRepository ?? new EfCommentRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
