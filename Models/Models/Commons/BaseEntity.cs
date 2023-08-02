using System.ComponentModel.DataAnnotations;

namespace TestCreateAPI.Models.Models.Commons
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            UserCreated = "System";
            DateCreated = DateTime.Now;
            Status = 1;
        }

        [MaxLength(2)]
        public int Status { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
    }
}
