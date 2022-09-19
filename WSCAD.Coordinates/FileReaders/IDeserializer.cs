using System;
using System.Collections.Generic;
using System.Text;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates.FileReaders
{
  public interface IDeserializer
  {
    /// <summary>
    /// Create list of shapes from data
    /// </summary>
    /// <param name="data"></param>
    /// <param name="typeCommands"></param>
    /// <returns></returns>
    public List<ShapeDef> DeserializeShapes(string data, Dictionary<string, Func<ShapeDef>> typeCommands);
  }
}
