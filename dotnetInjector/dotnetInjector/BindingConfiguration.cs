using System;

namespace dotnetInjector
{
	public class BindingConfiguration
	{
		private readonly Type _requestType;
		public Type ResolvedType { get; private set; }

		public BindingConfiguration(Type type)
		{
			_requestType = type ?? throw new ArgumentNullException(nameof(type));
		}

		public void To<T>()
		{
			ResolvedType = typeof(T);
		}
	}
}
