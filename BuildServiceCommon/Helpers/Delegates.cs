using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildServiceCommon.Helpers
{
    public delegate void VoidDelegate();
    public delegate void StringDelegate(string s);
    public delegate void BoolDelegate(bool b);
    public delegate bool BoolReturnDelegate(bool b);
    public delegate T Constraint<T>(T value);
}
