namespace AddWords.Services
{
    public interface IValidationUser
    {
        public string HashedPassword(string password);
        public bool ValidateEmail(string email);
    }
}
