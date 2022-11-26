using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        public async Task<int> GetSomeNumberAsync(CancellationToken cancellationToken)
        {
            /*
             * Kulllandığımız kütüphanenin CancelationToken i işlemesi gerekiyorki kullanabilelim. 
             * Task.Delay(), SQL lite vs. CancelationToken i işleyebiliyor. EfCore dan emin değilim
            */
            Debug.WriteLine("Task started");
            await Task.Delay(10000, cancellationToken);
            Debug.WriteLine("Task ended");

            return 0;
        }
    }
}
