using CancellationTokenExample.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample.Controllers
{
    /*
     * Server kaynaklar�n� verimli kullanmak ad�na yar�da kesilen i�lemlerde
     * (Kullan�c� bir sayfa y�klenirken sekmeyi kapadi vs.) 
     * kodunda yar�da kesilip gereksiz yere i�leme devam etmemesi i�in CancelationToken kullan�yoruz.
     * WebApp te Cancelation Token bize direkt olarak microsoft taraf�ndan sa�lan�yor. 
     * Console app te biraz daha farkl� bir yakla��m var.(CancelationTokenSource)
     * https://www.youtube.com/watch?v=b5dyPJ3zyRg&list=WL&index=8&t=17s linkte anlat�ml� hali mevcut.
     * 
     * Ara�t�rd���m kadar�yla Read i�lemi yap�lan yerlerde kullan�lmal�. 
     * Create,Update,Delete i�lemlerinin yar�da kesilmesini istemeyiz.
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