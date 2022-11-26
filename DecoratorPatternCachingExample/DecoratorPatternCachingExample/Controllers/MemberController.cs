using DecoratorPatternCachingExample.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DecoratorPatternCachingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken cancellationToken)
        {
            string jsonstr = JsonSerializer.Serialize(await _memberRepository.GetById(id, cancellationToken));
            return Ok(jsonstr);
        }
    }
}
