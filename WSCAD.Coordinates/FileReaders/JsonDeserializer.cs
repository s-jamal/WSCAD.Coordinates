using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates.FileReaders
{
  public class JsonDeserializer : IDeserializer
  {
    public List<ShapeDef> DeserializeShapes(string data, Dictionary<string, Func<ShapeDef>> typeCommands)
    {
      List<ShapeDef> shapes = JsonConvert.DeserializeObject<List<ShapeDef>>(data, new LayoutItemConverter(typeCommands));
      return shapes;
    }
  }
}
