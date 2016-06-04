using System;
using System.Collections.Generic;
using Microsoft.DotNet.InternalAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using SharedLib;

namespace ConsoleApplication
{
    public class Foo 
    {
        public string Bar { get; set; }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {   
            var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
            var assemblies = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);
            
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> 
                {
                    { "Foo__Bar", "foobar"}
                })
                .Build();
            
            var foo = config.GetValue(typeof(Foo), "Foo");
            
            Speaker.Speak();
            
            foreach (var assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }
        }
    }
}
