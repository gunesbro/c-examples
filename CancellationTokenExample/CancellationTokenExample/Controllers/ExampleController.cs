using CancellationTokenExample.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample.Controllers
{
    /*
     * Server kaynaklarýný verimli kullanmak adýna yarýda kesilen iþlemlerde
     * (Kullanýcý bir sayfa yüklenirken sekmeyi kapadi vs.) 
     * kodunda yarýda kesilip gereksiz yere iþleme devam etmemesi için CancelationToken kullanýyoruz.
     * WebApp te Cancelation Token bize direkt olarak microsoft tarafýndan saðlanýyor. 
     * Console app te biraz daha farklý bir yaklaþým var.(CancelationTokenSource)
     * https://www.youtube.com/watch?v=b5dyPJ3zyRg&list=WL&index=8&t=17s linkte anlatýmlý hali mevcut.
     * 
     * Araþtýrdýðým kadarýyla Read iþlemi yapýlan yerlerde kullanýlmalý. 
     * Create,Update,Delete iþlemlerinin yarýda kesilmesini istemeyiz.
     */
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleRepository _exampleRepository;
        public ExampleController(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }
        
        [HttpGet]
        [Route("GetLongProcessRequest")]
        public async Task<IActionResult> GetLongProcessRequest(CancellationToken cancellationToken)
        {
            var result = await _exampleRepository.GetSomeNumberAsync(cancellationToken);
            return Ok(result);
        }
    }
}