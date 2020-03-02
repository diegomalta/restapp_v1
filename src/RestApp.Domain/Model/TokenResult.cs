using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Domain.Model
{
    public class TokenResult
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
