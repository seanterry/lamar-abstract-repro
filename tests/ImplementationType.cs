using System;

namespace tests
{
    public class ImplementationType : ServiceType, IServiceType
    {
        public override void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
