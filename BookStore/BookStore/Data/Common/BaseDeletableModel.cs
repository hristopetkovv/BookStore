using System;

namespace BookStore.Data.Common
{
    public abstract class BaseDeletableModel : BaseModel, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}
