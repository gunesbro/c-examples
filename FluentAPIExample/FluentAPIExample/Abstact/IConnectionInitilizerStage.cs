using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FluentAPIExample.Abstact
{
    public interface IConnectionInitilizerStage
    {
        public IDbConnection Connect();
    }
}
