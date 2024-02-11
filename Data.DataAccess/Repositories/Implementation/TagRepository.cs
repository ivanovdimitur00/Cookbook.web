using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public  class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public override bool Exists(IQueryable<Tag> tagEntities, Tag tagEntityToFind)
        {
            Expression<Func<Tag, bool>> existingTagPredicate = cm =>
                cm.Name.Trim().ToLower() ==
                    tagEntityToFind.Name.Trim().ToLower();

            bool tagExists = tagEntities.Any(existingTagPredicate);

            return tagExists;
        }
    }
}
