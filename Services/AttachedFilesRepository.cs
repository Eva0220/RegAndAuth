using InformBez.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InformBez.Services
{
    public class AttachedFilesRepository : CrudRepository<AttachedFile, int>
    {
        public AttachedFilesRepository(ApplicationContext dbContext) : base(dbContext) { }

        public async Task<AttachedFile?> FindByPath(string path)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(f => f.FullPath == path);
        }
    }
}
