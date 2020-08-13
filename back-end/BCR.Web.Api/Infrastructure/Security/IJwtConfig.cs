using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.Web.Api.Infrastructure.Security
{
    public interface IJwtConfig
    {
        String Algorithm { get; }

        Int32 ExpirationMinutes { get; }

        String Issuer { get; }

        Byte[] SecurityKey { get; }

        String TokenType { get; }
    }
}
