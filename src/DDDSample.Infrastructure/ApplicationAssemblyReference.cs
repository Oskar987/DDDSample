namespace DDDSample.Infrastructure
{
    using System.Reflection;

    public sealed class InfrastructureAssemblyReference
	{
		internal static readonly Assembly Assembly = typeof(InfrastructureAssemblyReference).Assembly;
	}
}

