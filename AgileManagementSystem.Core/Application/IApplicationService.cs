using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Application
{
    /// <summary>
    /// Uygulamaya gelen iş isteklerini yakalayıp işlemek için kullancağımız servis(user-case)
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IApplicationService<in TRequest,out TResponse>
    {
        TResponse OnProcess(TRequest @request = default(TRequest));
    }
}
