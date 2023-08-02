using TestCreateAPI.DTO.Commons;

namespace TestCreateAPI.DTO
{
    public class TokenDTO : BaseDTO
    {
        public string UserName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string TokenAuth { get; set; }
        public DateTime StartSession { get; set; }
        public DateTime EndSession { get; set; }
    }
}
