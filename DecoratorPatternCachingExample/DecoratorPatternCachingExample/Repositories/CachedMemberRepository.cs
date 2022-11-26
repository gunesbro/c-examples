using DecoratorPatternCachingExample.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DecoratorPatternCachingExample.Repositories
{
    public class CachedMemberRepository : IMemberRepository
    {
        private readonly MemberRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        public CachedMemberRepository(MemberRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }
        public async Task<Member> GetById(Guid id, CancellationToken cancellationToken)
        {
            string key = $"member-{id}";

            return await _memoryCache.GetOrCreateAsync(
                key,
                factory => { 
                    factory.SetAbsoluteExpiration(TimeSpan.FromMinutes(2)); 
                    return _decorated.GetById(id, cancellationToken); 
                });
        }
    }
}
