namespace Infrastructure.Services
{
    public interface IKeyVaultManager
    {
        public Task<string> GetVaultSecret();
    }
}
