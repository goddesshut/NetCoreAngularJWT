using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Security
{
    public interface IJsonWebToken
    {
        TokenValidationParameters TokenValidationParameters { get; }

        Dictionary<string, object> Decode(string token);

        string Encode(string sub, string[] roles);
    }
}
