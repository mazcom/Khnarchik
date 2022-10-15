using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace json
{
  
  public class Product
  {

    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("productPrice")]
    [JsonConverter (typeof(DecimalJsonConverter))]
    public decimal ProductPrice { get; set; }
    
  }

  public class DecimalJsonConverter : JsonConverter<decimal>
  {
    public override decimal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
            decimal.Parse(reader.GetString()!, CultureInfo.InvariantCulture);

    public override void Write(
        Utf8JsonWriter writer,
        decimal dateTimeValue,
        JsonSerializerOptions options) =>  dateTimeValue.ToString(CultureInfo.InvariantCulture);
  }

  public class DecimalJsonConverter2 : JsonConverter<decimal>
  {
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
      throw new NotImplementedException();
    }
  }
}
