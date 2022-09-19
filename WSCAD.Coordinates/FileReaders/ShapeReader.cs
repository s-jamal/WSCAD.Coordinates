using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates.FileReaders
{
  public class ShapeReader
  {
    private readonly IDeserializer _deserializer;
    private Dictionary<string, Func<ShapeDef>> _typeCommands;

    /// <summary>
    /// Tool to create correct types from data file
    /// </summary>
    /// <param name="deserializer"></param>
    /// <param name="typeCommands">Dictionary of item types, and their respctive constructors</param>
    public ShapeReader(IDeserializer deserializer, Dictionary<string, Func<ShapeDef>> typeCommands)
    {
      this._deserializer = deserializer;
      this._typeCommands = typeCommands;
    }

    /// <summary>
    /// Read file, and deserialize objects
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public List<ShapeDef> GetObjectsFromFile(string file)
    {
      string fileText = File.ReadAllText(file);
      var shapes = _deserializer.DeserializeShapes(fileText, _typeCommands);

      return shapes;
    }
  }
}
