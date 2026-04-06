using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Models
{
    public class ApiResponse<T,dto>
    {

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dto Data { get; set; }
      //  public IEnumerable<dto> Datas { get; set; }

        public List<string> Errors { get; set; }

        public ApiResponse() { }

        public ApiResponse(dto data, string message = "null")
        {
            IsSuccess = true;
            StatusCode = 200;
            Message = message;
            Data = data;
        }

     

        public ApiResponse(string message, int statusCode = 400)
        {
            IsSuccess = false;
            StatusCode = statusCode;
            Message = message;
            Errors = new List<string> { message };
        }
    }

    }
