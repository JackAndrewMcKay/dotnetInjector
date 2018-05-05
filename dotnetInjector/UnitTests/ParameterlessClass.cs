using System;

namespace UnitTests
{
	public class ParameterlessClass : ISimpleInterface
	{
		public string Identifier { get; }

		public ParameterlessClass()
		{
			var seed = (int) DateTime.Now.Ticks % 1000;
			var random = new Random(seed);
			Identifier = random.Next(1, 1000).ToString();
		}
	}
}
