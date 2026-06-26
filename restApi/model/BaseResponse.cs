namespace restApi.model
{
    public class BaseResponse<T>
    {
        public int Status {  get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }

        public T? Data {  get; set; }

        public static BaseResponse<T> Ok(T data)
        {
            return new BaseResponse<T>
            {
                Status = 200,
                Success = true,
                Message = "OK",
                Data = data
            };
        }

        public static BaseResponse<T> Error(T data)
        {
            return new BaseResponse<T>
            {
                Status = 500,
                Success = false,
                Message = "Terjadi kesalahan",
                Data = default
            };
        }
    }
}
