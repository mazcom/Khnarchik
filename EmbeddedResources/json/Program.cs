// See https://aka.ms/new-console-template for more information

// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-6-0

using json;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using System.Text.Json;

//Console.WriteLine("Hello, World!");

// https://josef.codes/using-embedded-files-in-dotnet-core/


var prov = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
var stream = prov.GetFileInfo("products.json").CreateReadStream();

string allData;
using (StreamReader reader = new StreamReader(stream))
{
  allData = reader.ReadToEnd();
}

//allData = File.ReadAllText("products.json");

var options = new JsonSerializerOptions();
options.Converters.Add(new DecimalJsonConverter());


var products =
                JsonSerializer.Deserialize<List<Product>>(allData, options);


Console.WriteLine("End of program");




