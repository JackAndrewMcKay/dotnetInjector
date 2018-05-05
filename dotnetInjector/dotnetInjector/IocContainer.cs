using System;
using System.Collections.Generic;
using System.Reflection;

namespace dotnetInjector
{
	public class IocContainer
	{
		private readonly Dictionary<Type, BindingConfiguration> _map;

		public IocContainer()
		{
			_map = new Dictionary<Type, BindingConfiguration>();
		}

		public T Get<T>() where T : class
		{
			var type = typeof(T);

			if (_map.TryGetValue(type, out BindingConfiguration configuration))
			{
				return Get(configuration.ResolvedType) as T;
			}

			return Get(type) as T;
		}

		public BindingConfiguration Bind<T>() where T : class
		{
			var configuration = new BindingConfiguration(typeof(T));
			_map.Add(typeof(T), configuration);

			return configuration;
		}

		private object Get(Type type)
		{
			var selectedConstructor = GetConstructorWithMostArguments(type);
			var parameters = selectedConstructor.GetParameters();

			if (parameters.Length == 0)
			{
				return Activator.CreateInstance(type);
			}

			var injectedArguments = new object[parameters.Length];

			for (var i = 0; i < parameters.Length; i++)
			{
				var parameterType = parameters[i].ParameterType;
				var resolvedParameter = Get(parameterType);
				injectedArguments[i] = resolvedParameter;
			}
			return Activator.CreateInstance(type, injectedArguments);
		}

		private ConstructorInfo GetConstructorWithMostArguments(Type type)
		{
			var constructors = type.GetConstructors();

			ConstructorInfo constructorWithMostParameters = null;
			var mostParameters = -1;

			foreach (var constructor in constructors)
			{
				var parameters = constructor.GetParameters();
				var length = parameters.Length;

				if (length > mostParameters)
				{
					mostParameters = length;
					constructorWithMostParameters = constructor;
				}
			}

			if (constructorWithMostParameters == null)
			{
				throw new InvalidOperationException($"No constructor found for type {type}");
			}

			return constructorWithMostParameters;
		}
	}
}
