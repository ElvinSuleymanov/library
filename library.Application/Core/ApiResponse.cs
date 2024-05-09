
namespace library.Application.Core
{
    public class ApiResponse<TResponse>
    {
        public int Status { get; set; }
        public TResponse Data { get; set; } 
        public static ApiResponse<TResponse> Success(TResponse data)
        {
            return new ApiResponse<TResponse> { Status = 200, Data = data };
        }
       public static ApiResponse<TResponse> Error() {
            return new ApiResponse<TResponse> { Status = 400};
       }
       public static ApiResponse<TResponse> UnAuth() {
            return new ApiResponse<TResponse> { Status = 401};
       }
    }   
}


