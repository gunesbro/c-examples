using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample.Repositories
{
    public interface IExampleRepository
    {
        Task<int> GetSomeNumberAsync(CancellationToken cancellationToken);
    }
}
