using System.ComponentModel.DataAnnotations;
using TestCreateAPI.Models.Models.Commons;

namespace TestCreateAPI.Models.Models
{
    public class MataKuliah : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
