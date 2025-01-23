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

}
