﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate() {

            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//burdada sifreleme algoritamamısı vs gridik
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience: "http://localhost",
                notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);

        }
    }
}
