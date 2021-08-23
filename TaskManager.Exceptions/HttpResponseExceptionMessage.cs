using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace TaskManager.Exceptions
{
    public class HttpResponseExceptionMessage
    {
        [Required]
        public string TraceID { get; set; }

        [Required]
        public HttpStatusCode Status { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
