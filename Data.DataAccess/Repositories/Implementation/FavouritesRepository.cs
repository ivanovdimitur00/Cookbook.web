using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public class FavouritesRepository : BaseRepository<Favourites>, IFavouritesRepository
    {
        public FavouritesRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public override bool Exists(IQueryable<Favourites> favourites, Favourites favouritesToFind)
        {
            Expression<Func<Favourites, bool>> favouritesExistsPredicate = f =>
                f.ApplicationUserId == favouritesToFind.ApplicationUserId &&
                f.RecipeId == favouritesToFind.RecipeId;

            bool favouritesExists = favourites.Any(favouritesExistsPredicate);

            return favouritesExists;
        }
    }
}