using Services.A.Core.Events;
using Services.A.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.A.Core.Interfaces
{
    public interface IServiceRepo
    {
        Task<bool> SendMessage();
    }
}
