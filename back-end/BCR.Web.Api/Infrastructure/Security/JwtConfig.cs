using Microsoft.IdentityModel.Tokens;
using System;

namespace BCR.Web.Api.Infrastructure.Security
{
    public class JwtConfig : IJwtConfig
    {
        public string Algorithm => SecurityAlgorithms.HmacSha256Signature;

        public int ExpirationMinutes => 720;

        public string Issuer => "bcr";

        public byte[] SecurityKey => Convert.FromBase64String("WWFyZEFwcFNlY3VyaXR5S2V5");

        public string TokenType => "Bearer";
    }
}
