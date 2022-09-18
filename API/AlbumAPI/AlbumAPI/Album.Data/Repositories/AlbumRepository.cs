using Album.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Data.Repositories
{
    public class AlbumRepository : BaseReporitory<Album>, IAlbumRepository
    {
        private readonly ChinookContext chinookContext;

        public AlbumRepository(ChinookContext chinookContext) : base(chinookContext)
        {
            this.chinookContext = chinookContext;
        }

        public async Task<List<string>> GetAlbumNames(CancellationToken cancellationToken = default)
        {
            return await chinookContext.Album.AsNoTracking().Select(x => x.Title).ToListAsync(cancellationToken);
        }
    }
}
