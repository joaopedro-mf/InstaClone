using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    interface IEntity
    {
        Response<string> Validate();
    }
}
