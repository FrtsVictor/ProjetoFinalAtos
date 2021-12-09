using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAtos.Service.Exceptions
{
    public class TokenGenerationException : Exception
    {
        public TokenGenerationException(string message) : base(message) { }
        public TokenGenerationException() : base() { }
        public TokenGenerationException(string message, Exception innerException) : base(message, innerException) { }

    }
}
