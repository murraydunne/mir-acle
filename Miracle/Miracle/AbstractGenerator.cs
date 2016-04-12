using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public abstract class AbstractGenerator
    {
        public int CurrentScale = 0;

        public abstract List<Note> Generate();
    }
}
