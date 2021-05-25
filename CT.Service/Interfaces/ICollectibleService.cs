using System;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;

namespace CT.Services
{
    public interface ICollectibleService<T> : INamedService<T> where T : CollectibleItem
    {
    }
}
