using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestCreateAPI.Models.Models.Commons;

namespace TestCreateAPI.Models.Models
{
    public class Kuliah : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Semester { get; set; }
        [ForeignKey(nameof(Mahasiswa))]
        public int IdMahasiswa { get; set; }
        [ForeignKey(nameof(MataKuliah))]
        public string CodeMatakuliah { get; set; }

        public Mahasiswa Mahasiswa { get; set; }
        public MataKuliah MataKuliah { get; set; }
    }
}
