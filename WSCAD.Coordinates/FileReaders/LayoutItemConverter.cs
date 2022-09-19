using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates.FileReaders
{
  /// <summary>
  /// This converter is used when deserializing a layout where we have multiple LayoutItems
  /// It reads the type element so that it can instantiate the correct subclass
  /// </summary>
  public class LayoutItemConverter : JsonConverter
  {
    private Dictionary<string, Func<ShapeDef>> _commands;

    public LayoutItemConverter(Dictionary<string, Func<ShapeDef>> commands)
    {
      _commands = commands;
    }

    public override bool CanConvert(Type objectType)
    {
      return typeof(ShapeDef).IsAssignableFrom(objectType);
    }


    public override object ReadJson(JsonReader reader,
        Type objectType, object existingValue, JsonSerializer serializer)
    {
      JObject jo = JObject.Load(reader);

      string itemType = jo["type"]?.ToString();

      //create correct subclass depending on itemType
      ShapeDef item = null;

      if (_commands.ContainsKey(itemType.ToUpper()))
      {
        item = _commands[itemType.ToUpper()].Invoke();
      }
      else
      {
        throw new NotImplementedException("type of the object is not implemented");
      }

      serializer.Populate(jo.CreateReader(), item);

      return item;
    }

    public override bool CanWrite
    {
      get { return false; }
    }

    public override void WriteJson(JsonWriter writer,
        object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }
  }
}
