using System;

namespace BookStore.Data.Data.Common
{
    public abstract class BaseDeletableModel : BaseModel, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}
