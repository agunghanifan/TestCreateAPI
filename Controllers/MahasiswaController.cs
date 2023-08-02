using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCreateAPI.DTO.Commons;
using TestCreateAPI.DTO;
using TestCreateAPI.Models.Context;
using TestCreateAPI.Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace TestCreateAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class MahasiswaController : ControllerBase
    {
        public readonly UniversityContext _context;
        public MahasiswaController(UniversityContext universityContext)
        {
            _context = universityContext;
        }

        /// <summary>
        /// Get All Active Mahasiswa
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public Task<JsonResult> GetMahasiswa()
        {
            try
            {
                var listMahasiswa = _context.Mahasiswa.Where(i => i.Status == 1);

                return Task.FromResult(new JsonResult(new BaseResponse()
                {
                    ListData = listMahasiswa,
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
        /// Action for Post / Add new Mahasiswa to table Database
        /// </summary>
        /// <param name="dto">Object parameter for post new Mahasiswa</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> PostMahasiswa(MahasiswaDTO dto)
        {
            try
            {
                Mahasiswa newObjMahasiswa = new()
                {
                    Name = dto.Name,
                    UserCreated = dto.UserCreated,
                };
                await _context.AddAsync(newObjMahasiswa);
                await _context.SaveChangesAsync();

                return Ok(new BaseResponse()
                {
                    SingleData = newObjMahasiswa
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
        /// Action for Delete / Unactive Mahasiswa from table database
        /// </summary>
        /// <param name="idMahasiswa">Id Mahasiswa in the database</param>
        /// <param name="userModified">User who deleted the Mahasiswa</param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<JsonResult> RemoveMahasiswa(int idMahasiswa, string userModified)
        {
            try
            {
                Mahasiswa getExistingMahasiswa = await _context.Mahasiswa.SingleAsync(i => i.Id == idMahasiswa);
                getExistingMahasiswa.Status = 0;
                getExistingMahasiswa.DateModified = DateTime.Now;
                getExistingMahasiswa.UserModified = userModified;
                _context.Update(getExistingMahasiswa);
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
                    Message = "ID Mahasiswa is not found."
                });
            }
        }
    }
}
