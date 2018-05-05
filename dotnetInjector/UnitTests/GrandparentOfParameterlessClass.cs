using System;

namespace UnitTests
{
	public class GrandparentOfParameterlessClass
	{
		public ParentOfParameterlessClass A { get; }
		public ParameterlessClass B { get; }

		public GrandparentOfParameterlessClass(ParentOfParameterlessClass a, ParameterlessClass b)
		{
			A = a ?? throw new ArgumentNullException(nameof(a));
			B = b ?? throw new ArgumentNullException(nameof(b));
		}
	}
}
