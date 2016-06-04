using System;
using System.IO;
using Microsoft.DotNet.InternalAbstractions;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class PrimaryDataStorageSettings 
    {
        public string MongoDbConnectionString { get; set; }
        public string MongoDbDatabase { get; set; }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "..", "..", "..");
            var fullPath = Path.GetFullPath(path);
            
            var config = new ConfigurationBuilder()
                .SetBasePath(fullPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables("CoreClrSample_")
                .Build();
            
            var mongoSettings = new PrimaryDataStorageSettings();
            ConfigurationBinder.Bind(config.GetSection("PrimaryDataStorage"), mongoSettings);
            
            Console.WriteLine(mongoSettings.MongoDbConnectionString);
            Console.WriteLine(mongoSettings.MongoDbDatabase);
        }
    }
}