namespace Core.Interface
{
    public interface IArtWorkRepository
    {
        Task<ArtWork> GetArtworkByIdAsync(int id);
        Task<IReadOnlyList<ArtWork>> GetArtworksAsync();
    }
}
