﻿using System;

namespace BookStore.Data.Data.Common
{
    public abstract class BaseModel : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
