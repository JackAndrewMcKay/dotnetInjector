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
	}
}
