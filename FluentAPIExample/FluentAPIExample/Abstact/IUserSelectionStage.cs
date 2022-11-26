using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPIExample.Abstact
{
    public interface IUserSelectionStage
    {
        public IPasswordSelectionStage AsUser(string userName);
    }
}
