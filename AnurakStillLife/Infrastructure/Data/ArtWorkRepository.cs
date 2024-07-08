using Core;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ArtWorkRepository : IArtWorkRepository
    {
        private readonly StillLifeContext stillLifeContext;

        public ArtWorkRepository(StillLifeContext stillLifeContext)
        {
            this.stillLifeContext = stillLifeContext;
        }

        public async Task<ArtWork> GetArtworkByIdAsync(int id)
        {
            return await this.stillLifeContext.ArtWorks.FindAsync(id);
        }

        public async Task<IReadOnlyList<ArtWork>> GetArtworksAsync()
        {
            return await this.stillLifeContext.ArtWorks.ToListAsync();
        }
    }
}
