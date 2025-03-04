namespace AddWords.Services
{
    public interface IHashedPassword
    {
        public string HashedPassword(string password);
    }
}
