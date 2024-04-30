using MauiAppEnemQuizPro.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppEnemQuizPro.Services
{
    public interface IUserService
    {
        Task InicializeAsync();
        Task<User> GetUser(string email, string password);
        Task<User> GetUserByEmail(string email);
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
    }
}
