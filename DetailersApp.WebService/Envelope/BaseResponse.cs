using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Envelope
{
    public abstract class BaseResponse<T>
    {
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<T> Results { get; set; }
        public bool IsSuccess { get; set; }
    }
}
