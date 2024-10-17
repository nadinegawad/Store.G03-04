namespace Store.G03.APIs.Error
{
    public class ApiEceptionResponse : ApiErrorResponse
    {
        public string? Details {get;set;}
        public ApiEceptionResponse(int statuscode,string? message=null, string? details=null):base(statuscode,message)
        {
            Details=details;
        }
    }
}
