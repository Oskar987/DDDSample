namespace DDDSample.Application
{
    using System.Reflection;

    public sealed class ApplicationAssemblyReference
	{
		internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
	}
}

