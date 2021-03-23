using System;

namespace BookStore.Data.Data.Common
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
