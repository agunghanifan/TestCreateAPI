namespace TestCreateAPI.DTO.Commons
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            StatusCode = StatusCodes.Status200OK;
            Message = "Success Generate API";
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IQueryable<object> ListData { get; set; }
        public object SingleData { get; set; }
    }
}
