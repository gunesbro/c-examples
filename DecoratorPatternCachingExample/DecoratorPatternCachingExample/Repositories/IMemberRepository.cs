using DecoratorPatternCachingExample.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DecoratorPatternCachingExample.Repositories
{
    public interface IMemberRepository
    {
        Task<Member> GetById(Guid id, CancellationToken cancellationToken);
    }
}
