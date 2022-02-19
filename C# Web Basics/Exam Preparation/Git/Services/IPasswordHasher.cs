namespace Git.Services
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
    }
}
