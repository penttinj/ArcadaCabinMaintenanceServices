using ArcadaCMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Interfaces
{
    public interface IserviceUseCase
    {
        IEnumerable<Room> GetAll();
    }
}
