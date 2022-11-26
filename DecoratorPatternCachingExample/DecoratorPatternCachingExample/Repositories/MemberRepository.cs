using DecoratorPatternCachingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DecoratorPatternCachingExample.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly List<Member> dbContext_Members;
        public MemberRepository()
        {
            dbContext_Members = DbContext_Members.DummyMembersTable;
        }
        public async Task<Member> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return dbContext_Members.FirstOrDefault(member => member.Id == id); },cancellationToken);
        }
    }
}
