﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak.DI
{
    public interface IDependancyResolver
    {
        T Resolve<T>();

        T Resolve<T>(string name);
    }
}
