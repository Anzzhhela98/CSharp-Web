namespace SMS.Services
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
    }
}
