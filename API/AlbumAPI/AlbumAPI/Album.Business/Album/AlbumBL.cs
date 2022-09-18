using Album.Data.IRepositories;
using Album.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Business.Album
{
    public class AlbumBL : IAlbumBL
    {
        private readonly IAlbumRepository albumRepository;

        public AlbumBL(IAlbumRepository albumRepository) {
            this.albumRepository = albumRepository;
        }

        public async Task<List<string>> GetAllAlbums(CancellationToken cancellationToken = default)
        {
           return await albumRepository.GetAlbumNames(cancellationToken);
        }
    }
}
