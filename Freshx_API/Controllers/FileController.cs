using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFilesRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileController(IFilesRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Savefile>> CreateFile([FromForm] FileDto fileDto)
        {
            var result = await _fileRepository.CreateFile(fileDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Savefile>> GetFile(int id)
        {
            var file = await _fileRepository.GetFileById(id);
            if (file == null)
                return NotFound();
            return Ok(file);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Savefile>>> GetAllFiles()
        {
            var files = await _fileRepository.GetAllFiles();
            return Ok(files);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            var result = await _fileRepository.DeleteFile(id);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Savefile>> UpdateFile(int id, [FromForm] FileDto fileDto)
        {
            var updatedFile = await _fileRepository.UpdateFile(id, fileDto);
            if (updatedFile == null)
                return NotFound();
            return Ok(updatedFile);
        }

        [HttpGet("GetAllFilesInBlob")]
        public async Task<ActionResult<List<string>>> GetAllFilesInBlob()
        {
            var files = await _fileRepository.GetAllFilesAsync();
            return Ok(files);
        }
    }
}
