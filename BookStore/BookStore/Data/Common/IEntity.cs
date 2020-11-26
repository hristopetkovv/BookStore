using System;

namespace BookStore.Data.Common
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
