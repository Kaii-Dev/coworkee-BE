using Coworkee.Data;
using Coworkee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coworkee.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
         
        public MusicController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet]
        //[Route("list")]
        public async Task<IActionResult> List()
        {
            var music = await _dbContext.Music.ToListAsync();

            var results = music.AsEnumerable().Select(x => new Coworkee.Model.Music
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Link = x.Link,
                Active = x.Active,
                Description = x.Description,

            })
                .OrderBy(x => x.Name);
            //return Ok(results);
            return Ok(JsonConvert.SerializeObject(results));
            
        }

        [HttpGet]
        [Route("detail/{id:Guid}")]
        public async Task<IActionResult> Detail([FromRoute] Guid id)
        {
            var music = await _dbContext.Music.FindAsync(id);
            if(music == null)
            {
                return NotFound("Can not find infomation !");
            }
            return Ok(music);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(RequestMusicModel request)
        {
            var music = new Music()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Author = request.Author,
                Link = request.Link,
                Active = request.Active,
                Description = request.Description,
            };
           await _dbContext.Music.AddAsync(music);
           await _dbContext.SaveChangesAsync();

            return Ok(music);
        }

        //[HttpPost]
        [HttpPut]
        [Route("update/{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, RequestMusicModel request)
        {
            var music = await _dbContext.Music.FindAsync(id);
            if(music != null)
            {
                music.Name = request.Name;
                music.Author = request.Author;
                music.Link = request.Link;
                music.Active = request.Active;
                music.Description = request.Description;

                await _dbContext.SaveChangesAsync();
                return Ok(music);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
          var music =  await _dbContext.Music.FindAsync(id);
            if(music != null)
            {
                _dbContext.Remove(music);
               await _dbContext.SaveChangesAsync();
                return Ok(music);
            }

            return NotFound("Delete successfully!");
        }

        []
    }
}
