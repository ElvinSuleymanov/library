namespace library.API;

public  class ApiResponse<TResponse>
{
    
    public static SuccessResponse<TResponse> Success(TResponse data) {
        return new SuccessResponse<TResponse> {Status = 200, Data = data};    
    }
    public class SuccessResponse<T> {
        public int Status {get; set;}
        public required T Data {get;set;}
    }
}   
