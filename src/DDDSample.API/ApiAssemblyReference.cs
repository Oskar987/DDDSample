namespace DDDSample.API
{
    using System.Reflection;

    public sealed class ApiAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApiAssemblyReference).Assembly;
    }
}

