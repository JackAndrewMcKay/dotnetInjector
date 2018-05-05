using System;

namespace dotnetInjector
{
	public class IocContainer
	{
		public T Get<T>() where T : class
		{
			var type = typeof(T);

			return Activator.CreateInstance(type) as T;
		}
	}
}
