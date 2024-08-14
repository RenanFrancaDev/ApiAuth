using System;
using System.IdentityModel.Tokens.Jwt; //Gerar Token
using System.Security.Claims; //DIsponibilizar infos para os controllers 
using System.Text; //Codificar o Token
using ApiAuth.Models;
using Microsoft.IdentityModel.Tokens; //Identificar Token

namespace ApiAuth.Services
{
    public class TokenService
    {
        public static string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); //Gerador de token
            var key = Encoding.ASCII.GetBytes(Settings.Secret); //bytes da chave encryptada
            var tokenDescriptor = new SecurityTokenDescriptor //informações do token 3 partes: Subject, expires, Signin credentials
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5), //Tempo de expiração do Token
                SigningCredentials = new SigningCredentials( //2 parametros
                    new SymmetricSecurityKey(key), //Chave para encryptar
                    SecurityAlgorithms.HmacSha256Signature)  //Tipo de chave
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
