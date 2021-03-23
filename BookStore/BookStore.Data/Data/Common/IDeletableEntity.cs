using System;

namespace BookStore.Data.Data.Common
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime DeletedOn { get; set; }
    }
}
