using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Business.Album
{
    public interface IAlbumBL
    {
        Task<List<string>> GetAllAlbums(CancellationToken cancellationToken = default);
    }
}
