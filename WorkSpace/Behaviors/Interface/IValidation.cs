using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Behaviors.Interface
{
    public interface IValidation
    {
        void CheckObjectForValid(object instance);
        void CheckId(int id);
        void CheckObjectForNull(object instance);
    }
}
