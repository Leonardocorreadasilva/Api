using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Request
{
    public class UserRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressRequest Address { get; set; }
    }
}
