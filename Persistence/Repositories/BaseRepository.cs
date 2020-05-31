using Notes.API.Persistence.Context;

namespace Notes.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        
    }
}