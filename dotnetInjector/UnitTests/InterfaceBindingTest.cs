using System;
using dotnetInjector;
using Xunit;

namespace UnitTests
{
	public class InterfaceBindingTest
	{
		[Fact]
		public void InterfaceBindsToConcreteImplementation()
		{
			var container = new IocContainer();
			container.Bind<ISimpleInterface>().To<ParameterlessClass>();

			var resolvedObject = container.Get<ISimpleInterface>();

			Assert.NotNull(resolvedObject);
			Assert.True(resolvedObject is ParameterlessClass);
		}

		[Fact]
		public void InterfaceBindsToComplexConcreteImplementation()
		{
			var container = new IocContainer();
			container.Bind<ISimpleInterface>().To<ParentOfParameterlessClass>();

			var resolvedObjectA = container.Get<ISimpleInterface>();
			var resolvedObjectB = container.Get<ISimpleInterface>();

			Assert.NotEqual(resolvedObjectA.Identifier, resolvedObjectB.Identifier);
			Assert.True(resolvedObjectA is ParentOfParameterlessClass);
			Assert.True(resolvedObjectB is ParentOfParameterlessClass);
		}

		[Fact]
		public void UnregisteredInterfaceThrows()
		{
			var container = new IocContainer();

			Assert.Throws<InvalidOperationException>(() => container.Get<ISimpleInterface>());
		}
	}
}
