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
    public class KuliahController : ControllerBase
    {
        public readonly UniversityContext _context;
        public KuliahController(UniversityContext universityContext) 
        {
            _context = universityContext;
        }

        /// <summary>
        /// Get All Active Kuliah 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public Task<JsonResult> GetKuliah()
        {
            try
            {
                var listKuliah = _context.Kuliah.Where(i => i.Status == 1);

                return Task.FromResult(new JsonResult(new BaseResponse()
                {
                    ListData = listKuliah,
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
        /// Action for Post / Add new Kuliah to table Database
        /// </summary>
        /// <param name="dto">Object parameter for post new Mahasiswa</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> PostKuliah(KuliahDTO dto)
        {
            try
            {
                bool isCodeMataKuliahActive = await _context.MataKuliah.AnyAsync(i => i.Code == dto.CodeMatakuliah && i.Status == 1);
                bool isMahasiswaActive = await _context.Mahasiswa.AnyAsync(i => i.Id == dto.IdMahasiswa && i.Status == 1);
                
                if (isCodeMataKuliahActive && isMahasiswaActive) 
                { 
                    Kuliah newObjKuliah = new()
                    {
                        CodeMatakuliah = dto.CodeMatakuliah,
                        Semester = dto.Semester,
                        IdMahasiswa = dto.IdMahasiswa,
                        UserCreated = dto.UserCreated,
                    };
                    await _context.AddAsync(newObjKuliah);
                    await _context.SaveChangesAsync();

                    return Ok(new BaseResponse()
                    {
                        SingleData = newObjKuliah
                    });

                }

                return Ok(new BaseResponse()
                {
                    StatusCode = 400,
                    Message = "Bad Request, please check The Parameter again"
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
        /// Action for Delete / Unactive Kuliah from table database
        /// </summary>
        /// <param name="IdKuliah">Id Kuliah in the database</param>
        /// <param name="userModified">User who deleted the Kuliah</param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<JsonResult> RemoveKuliah(int IdKuliah, string userModified)
        {
            try
            {
                Kuliah getExistingKuliah = await _context.Kuliah.SingleAsync(i => i.Id == IdKuliah);
                getExistingKuliah.Status = 0;
                getExistingKuliah.DateModified = DateTime.Now;
                getExistingKuliah.UserModified = userModified;
                _context.Update(getExistingKuliah);
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
                    Message = "ID Kuliah is not found."
                });
            }
        }
    }
}
