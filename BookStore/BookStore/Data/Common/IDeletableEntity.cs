using System;

namespace BookStore.Data.Common
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime DeletedOn { get; set; }
    }
}
