using ArcadaCMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Interfaces
{
    public interface IServiceUseCase
    {
        IEnumerable<Service> GetAll();
        int Create(Service service);
        IEnumerable<Service> Update(int id, Service service);
        int Delete(int id);
        bool isEmptyService(Service service);
    }
}
