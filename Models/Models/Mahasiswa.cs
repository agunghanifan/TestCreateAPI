using System.ComponentModel.DataAnnotations;
using TestCreateAPI.Models.Models.Commons;

namespace TestCreateAPI.Models.Models
{
    public class Mahasiswa : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
