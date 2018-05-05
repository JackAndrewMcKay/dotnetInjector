using System;

namespace UnitTests
{
	public class ParentOfParameterlessClass : ISimpleInterface
	{
		public ParameterlessClass A { get; }
		public ParameterlessClass B { get; }

		public ParentOfParameterlessClass(ParameterlessClass a, ParameterlessClass b)
		{
			A = a ?? throw new ArgumentNullException(nameof(a));
			B = b ?? throw new ArgumentNullException(nameof(b));

			Identifier = A.Identifier + B.Identifier;
		}

		public string Identifier { get; }
	}
}
