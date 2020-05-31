using System.Threading.Tasks;
using Notes.API.Domain.Repositories;
using Notes.API.Persistence.Context;

namespace Notes.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}