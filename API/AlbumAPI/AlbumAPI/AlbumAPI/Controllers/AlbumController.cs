using Album.Business.Album;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlbumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumBL albumBL;

        public AlbumController(IAlbumBL albumBL)
        {
            this.albumBL = albumBL;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await albumBL.GetAllAlbums());
        }

    }
}
