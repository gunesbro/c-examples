using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPIExample.Abstact
{
     public interface IPasswordSelectionStage
    {
        public IConnectionInitilizerStage WithPassword(string password);
    }
}
