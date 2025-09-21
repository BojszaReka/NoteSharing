using class_library.DTO;
using class_library.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SubjectController(IUnitOfWork uow) : Controller
    {
        private readonly IUnitOfWork _uow = uow;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectCreateDTO dto)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.SubjectRepository.Create(dto); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubjectViewDTO dto)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.SubjectRepository.Update(dto); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.SubjectRepository.Delete(id); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.SubjectRepository.GetById(id); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var r = new ApiResponse();
            try { r.Data = await _uow.SubjectRepository.GetAll(); return Ok(r); }
            catch (Exception e) { r.StatusCode = 400; r.Message = e.Message; return BadRequest(r); }
        }
    }
}
