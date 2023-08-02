using TestCreateAPI.DTO.Commons;

namespace TestCreateAPI.DTO
{
    public class KuliahDTO : BaseDTO
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public int IdMahasiswa { get; set; }
        public string CodeMatakuliah { get; set; }
    }
}
