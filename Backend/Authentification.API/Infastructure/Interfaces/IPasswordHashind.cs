namespace Authentification.API.Infastructure.Interfaces
{
    public interface IPasswordHashind
    {
        public string GenerateHash(string password);

        public bool Verify(string password, string anotherPassword);
    }
}
