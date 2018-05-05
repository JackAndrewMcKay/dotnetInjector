using dotnetInjector;
using Xunit;

namespace UnitTests
{
	public class SelfBindingTest
	{
		[Fact]
		public void ParameterlessConstructorSelfBindsInTransientScope()
		{
			var container = new IocContainer();
			var resultA = container.Get<ParameterlessClass>();
			var resultB = container.Get<ParameterlessClass>();
			
			Assert.NotEqual(resultA.Identifier, resultB.Identifier);
		}

		[Fact]
		public void ParameterlessConstructorParentSelfBindsInTransientScope()
		{
			var container = new IocContainer();
			var parent = container.Get<ParentOfParameterlessClass>();
			var childA = parent.A;
			var childB = parent.B;

			Assert.NotEqual(childA.Identifier, childB.Identifier);
		}

		[Fact]
		public void ParameterlessConstructorGrandparentSelfBindsInTransientScope()
		{
			var container = new IocContainer();
			var grandparent = container.Get<GrandparentOfParameterlessClass>();
			var a = grandparent.A.A;
			var b = grandparent.A.B;
			var c = grandparent.B;

			Assert.NotEqual(a.Identifier, b.Identifier);
			Assert.NotEqual(b.Identifier, c.Identifier);
			Assert.NotEqual(a.Identifier, c.Identifier);
		}
	}
}
