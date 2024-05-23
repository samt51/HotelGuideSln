namespace HotelGuide.Shared.Dtos.ResponseModel
{
    public class Response<T>
    {
        public T Data { get; set; }

        public int StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }

        public Response<T> Success()
        {
            return new Response<T> { Data = Data, StatusCode = 200, IsSuccess = true, Errors = new List<string>() };
        }
        public Response<T> Success(T data)
        {
            return new Response<T> { Data = data, StatusCode = 200, IsSuccess = true, Errors = new List<string>() };
        }
        public Response<T> Fail(T data, List<string> errors, int statusCode)
        {
            return new Response<T> { Data = data, Errors = errors, StatusCode = statusCode, IsSuccess = false };
        }
        public Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
        }
        public Response<T> Fail(T data, string errors, int statusCode)
        {
            Errors.Add(errors);
            return new Response<T> { Data = data, Errors = Errors, StatusCode = statusCode, IsSuccess = false };
        }
        public Response<T> Fail(string errors, int statusCode)
        {
            Errors.Add(errors);
            return new Response<T> { Errors = Errors, StatusCode = statusCode, IsSuccess = false };
        }

    }
}
