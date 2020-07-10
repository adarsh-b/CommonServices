using CommonServices.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServices.Business.Services
{
    public class TestService
    {
        public TestEntity GetTestData()
        {
            return new TestEntity { Field1 = "Value1", Field2 = "Value2" };
        }
    }
}
