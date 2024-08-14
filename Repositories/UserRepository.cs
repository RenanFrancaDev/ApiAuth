using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public class UserRepository
    {
        public static UserModel Get(string email, string password)
        {
            var users = new List<UserModel>

            {

            new() { Id = 1, Name = "Renan", Email = "renan@gmail.com", Password = "123456"},
            new() { Id = 2, Name = "Joao", Email = "joao@gmail.com", Password = "654321" }
            };
            return users
                .FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
    //public static UserModel GetByToken(string token)
    //{
    //    var users = new List<UserModel>
    //    // busque na lista de usuários aquele com o token correspondente
    //    return users.FirstOrDefault(u => u.Token == token);
    //}
}
