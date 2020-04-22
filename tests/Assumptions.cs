using Lamar;
using Lamar.IoC;
using Xunit;

namespace tests
{
    public class Assumptions
    {
        readonly ServiceRegistry registry = new ServiceRegistry();
        T resolve<T>()
        {
            using var container = new Container( registry );
            return container.GetInstance<T>();
        }

        [Fact]
        public void unregistered_abstract_type_should_not_resolve_on_empty_container()
        {
            Assert.Throws<LamarMissingRegistrationException>( resolve<ServiceType> );
        }

        [Fact]
        public void unregistered_interface_type_should_not_resolve_on_empty_container()
        {
            Assert.Throws<LamarMissingRegistrationException>( resolve<IServiceType> );
        }

        [Fact]
        public void unregistered_abstract_type_should_not_resolve_after_assembly_scan()
        {
            // this fails; the implementation type is returned
            registry.Scan( _ => _.AssemblyContainingType<Assumptions>() );
            Assert.Throws<LamarMissingRegistrationException>( resolve<ServiceType> );
        }

        [Fact]
        public void unregistered_interface_type_should_not_resolve_after_assembly_scan()
        {
            // this fails; the implementation type is returned
            registry.Scan( _ => _.AssemblyContainingType<Assumptions>() );
            Assert.Throws<LamarMissingRegistrationException>( resolve<IServiceType> );
        }
    }
}
