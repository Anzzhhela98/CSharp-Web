namespace Git.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has Repositories collection – a Repository type
//•	Has Commits collection – a Commit type