namespace Store.G03.APIs.Error
{
    public class ApiErrorResponse
    {
        public int Statuscode { get; set; }
        public string? Message { get; set; }
        public ApiErrorResponse(int statuscode,string? message=null)
        {
            Statuscode=statuscode;
            Message=message??GetDefaultMessageForStatusCode(statuscode);
        }
        private string? GetDefaultMessageForStatusCode(int statuscode)
        {
            var message = statuscode switch
            {
                400 => "A bad request,you have made",
                401 => "Authorized,you are not",
                404 => "Resource was not found",
                500=>"server error",
                _=>null
            };
            return message;
        }
    }
}
