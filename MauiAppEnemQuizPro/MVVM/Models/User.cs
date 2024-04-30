using SQLite;

namespace MauiAppEnemQuizPro.MVVM.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), NotNull]
        public string Email { get; set; }

        [MaxLength(250), NotNull]
        public string Password { get; set; }
        public bool Active { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }
    }
}
