using System.Threading.Tasks;

namespace Notes.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}