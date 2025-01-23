using System.ComponentModel.DataAnnotations;
using System.Net;

namespace test.Helpers
{
    public class BaseResponse
    {
        private bool _success;

        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Code { get; set; }
    }

    public class BaseResponseModel<T>
    {
        private bool _success;

        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Code { get; set; }
        public T Data { get; set; }
        public int TotalRecords { get; set; }
    }
    public class BaseResponseObject<T>
    {
        private bool _success;

        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Code { get; set; }
        public T Data { get; set; }
    }

    public class ApiRequest
    {
        public HttpMethod Method { get; set; }
        public string? Url { get; set; }
        public object Body { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new();
        public bool IsJsonRequest { get; set; } = true;
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string? ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class ResponseContent
    {
        public string? ErrorMessage { get; set; }
        public string? ExtraData { get; set; }
    }

    public class BaseResponseObjectTree<T>
    {
        private bool _success;

        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }

        [Required]
        public string? Message { get; set; }

        [Required]
        public int Code { get; set; }
        public T Data { get; set; }
        public bool IsMobileVisible { get; set; }
    }

}
