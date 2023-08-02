using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCreateAPI.DTO;
using TestCreateAPI.DTO.Commons;
using TestCreateAPI.Models.Context;
using TestCreateAPI.Models.Models;

namespace TestCreateAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class MataKuliahController : ControllerBase
    {
        public readonly UniversityContext _context;
        public MataKuliahController(UniversityContext universityContext)
        {
            _context = universityContext;
        }

        /// <summary>
        /// Get All Active Mata Kuliah
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public Task<JsonResult> GetMataKuliah()
        {
            try
            {
                var listMataKuliah = _context.MataKuliah.Where(i => i.Status == 1);

                return Task.FromResult(new JsonResult(new BaseResponse()
                {
                    ListData = listMataKuliah,
                    StatusCode = 200
                }));
            }
            catch (Exception)
            {
                return Task.FromResult(new JsonResult(new BaseResponse()
                {
                    StatusCode = 500,
                    Message = "Internal Service Error"
                }));
            }
        }

        /// <summary>
        /// Action for Post / Add new Mata Kuliah to table Database
        /// </summary>
        /// <param name="dto">Object parameter for post new Mahasiswa</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> PostMataKuliah(MataKuliahDTO dto)
        {
            try
            {
                MataKuliah newObjMataKuliah = new()
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    UserCreated = dto.UserCreated,
                };
                await _context.AddAsync(newObjMataKuliah);
                await _context.SaveChangesAsync();

                return Ok(new BaseResponse()
                {
                    SingleData = newObjMataKuliah
                });
            }
            catch (Exception)
            {
                return new JsonResult(new BaseResponse()
                {
                    StatusCode = 500,
                    Message = "Internal service error"
                });
            }
        }

        /// <summary>
        /// Action for Delete / Unactive MataKuliah from table database
        /// </summary>
        /// <param name="idMataKuliah">Id Mahasiswa in the database</param>
        /// <param name="userModified">User who deleted the Mahasiswa</param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<JsonResult> RemoveMataKuliah(string idMataKuliah, string userModified)
        {
            try
            {
                MataKuliah getExistingMataKuliah = await _context.MataKuliah.SingleAsync(i => i.Code == idMataKuliah);
                getExistingMataKuliah.Status = 0;
                getExistingMataKuliah.DateModified = DateTime.Now;
                getExistingMataKuliah.UserModified = userModified;
                _context.Update(getExistingMataKuliah);
                await _context.SaveChangesAsync();

                return new JsonResult(new BaseResponse()
                {

                });
            }
            catch (Exception)
            {
                return new JsonResult(new BaseResponse()
                {
                    StatusCode = 500,
                    Message = "ID Mata Kuliah is not found."
                });
            }
        }
    }
}
