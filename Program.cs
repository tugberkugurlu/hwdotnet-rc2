using System;
using Microsoft.DotNet.InternalAbstractions;
using Microsoft.Extensions.DependencyModel;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
            var assemblies = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);
            
            foreach (var assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }
        }
    }
}
