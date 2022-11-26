using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPIExample.Abstact
{
    public interface IServerSelectionStage
    {
        public IDatabaseSelectionStage ForServer(string server);
    }
}
