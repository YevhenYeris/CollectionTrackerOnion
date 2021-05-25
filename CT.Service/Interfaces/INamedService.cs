using System;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;

namespace CT.Services
{
    public interface INamedService<T> : IBaseService<T> where T : BaseNamedEntity
    {
    }
}
