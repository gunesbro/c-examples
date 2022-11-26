using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternCachingExample.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }

    public class DbContext_Members
    {
        private static List<Member> _dbContext_Members { get; set; }
        public static List<Member> DummyMembersTable
        {
            get
            {
                if(_dbContext_Members == null)
                {
                    _dbContext_Members = new List<Member>();
                    _dbContext_Members.Add(new Member() { Id = Guid.Empty, Email = $"a{0}@member.com" });
                    for (int i = 1; i <= 1000; i++)
                    {
                        _dbContext_Members.Add(new Member() { Id = Guid.NewGuid(), Email = $"a{i}@member.com" });
                    }
                }
                return _dbContext_Members;
            }
            set { _dbContext_Members.AddRange(value); }
        }
    }
}
