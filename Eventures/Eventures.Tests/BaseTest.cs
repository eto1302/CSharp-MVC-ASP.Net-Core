using System;
using System.Collections.Generic;
using System.Text;
using Eventures.Mapping;

namespace Eventures.Tests
{
    public abstract class BaseTest
    {
        protected BaseTest()
        {
            AutoMapperConfig.ConfigureMapping();
        }
    }
}
