namespace TestCreateAPI.DTO.Commons
{
    public class BaseDTO
    {
        public BaseDTO()
        {
            UserCreated = "System";
            DateCreated = DateTime.Now;
        }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
    }
}
