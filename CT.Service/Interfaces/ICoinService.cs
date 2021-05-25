using System;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;

namespace CT.Services
{
    public interface ICoinService<T> : ICollectibleService<T> where T : Coin
    {
    }
}
