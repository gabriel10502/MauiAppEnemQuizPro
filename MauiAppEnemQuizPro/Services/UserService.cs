using MauiAppEnemQuizPro.MVVM.Models;
using SQLite;

namespace MauiAppEnemQuizPro.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;
        public async Task InicializeAsync()
        {
            await SetUpDb();
        }

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuizDB.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<User>();
            }
        }

        public async Task<int> CreateUser(User user)
        {
            return await _dbConnection.InsertAsync(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _dbConnection.DeleteAsync(id);
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await _dbConnection.Table<User>().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbConnection.Table<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<int> UpdateUser(User user)
        {
            return await _dbConnection.UpdateAsync(user);
        }
    }
}
