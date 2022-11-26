using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPIExample.Abstact
{
    public interface IDatabaseSelectionStage
    {
        public IUserSelectionStage ForDatabase(string database);
    }
}
