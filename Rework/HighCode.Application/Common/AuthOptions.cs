﻿#region

using System.Text;
using Microsoft.IdentityModel.Tokens;

#endregion

namespace HighCode.Application.Common;

public class AuthOptions
{
    public const string ISSUER = "Lightless"; // издатель токена
    public const string AUDIENCE = "HIGHCODE.APP"; // потребитель токена
    private const string KEY = "8dfc88a0-7a8e-41a5-8320-60ad8a64280d";

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}