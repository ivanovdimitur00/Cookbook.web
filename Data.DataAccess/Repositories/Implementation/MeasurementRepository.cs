using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public abstract class MeasurementRepository : BaseRepository<Measurement>, IMeasurementRepository
    {
        public MeasurementRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        //will not be needed as we dont need duplicate entries. Will leave it as a reminder.
        //public override bool Exists(IQueryable<TMeasurementEntity> measurementEntities, TMeasurementEntity measurementEntityToFind)
        //{
        //    Expression<Func<TMeasurementEntity, bool>> existingMeasurementPredicate = cm =>
        //        cm.Unit.Trim().ToLower() ==
        //            measurementEntityToFind.Unit.Trim().ToLower();

        //    bool measurementExists = measurementEntities.Any(existingMeasurementPredicate);

        //    return measurementExists;
        //}
    }
}

