using AgendaLive.Api.Models;
using AgendaLive.Api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgendaLive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivesController : Controller
    {
        private readonly LiveService _liveService;

        public LivesController(LiveService liveService)
        {
            _liveService = liveService;
        }

        /// <summary>
        /// List all lives
        /// </summary>        
        [HttpGet]
        public ActionResult<List<LiveDocument>> GetAllLives() => _liveService.FindAll();

        /// <summary>
        /// List by id live
        /// </summary>        
        [HttpGet("{id}", Name = "GetLivesById")]
        public ActionResult<LiveDocument> GetLivesById(string id)
        {
            var live = _liveService.FindById(id);

            if (live.HasValue && live.Value != null)
                return live.Value;

            return NotFound();
        }

        /// <summary>
        /// Create new live
        /// </summary>
        [HttpPost]
        public ActionResult<LiveDocument> CreateLive(LiveDocument liveDocument)
        {
            _liveService.Save(liveDocument);

            return CreatedAtRoute(nameof(GetLivesById), new { id = liveDocument.Id.ToString() }, liveDocument);
        }

        /// <summary>
        /// Edit live
        /// </summary>        
        [HttpPut("{id}")]
        public IActionResult UpdateLive(string id, LiveDocument liveDocument)
        {
            if (!ExistLive(id))
                return NotFound();

            _liveService.Update(id, liveDocument);

            return NoContent();
        }

        /// <summary>
        /// Delete live by id 
        /// </summary>        
        [HttpDelete("{id}")]
        public IActionResult DeleteLive(string id)
        {
            if (!ExistLive(id))
                return NotFound();

            _liveService.Delete(id);

            return NoContent();
        }


        private bool ExistLive(string id)
        {
            var live = _liveService.FindById(id);

            return (live.HasValue && live.Value != null);
        }

    }
}