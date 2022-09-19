using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace WSCAD.Coordinates.Shapes
{
  /// <summary>
  /// Point definition with coordinates
  /// </summary>
  public class PointDef
  {
    public PointDef()
    {

    }

    public PointDef(string point)
    {
      string[] coordinates = point.Split("; ");

      X = float.Parse(coordinates[0]);
      Y = float.Parse(coordinates[1]);
    }

    public PointDef(float x, float y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    /// X coordinate
    /// </summary>
    public float X { get; set; }
    /// <summary>
    /// Y coordinate
    /// </summary>
    public float Y { get; set; }
  }
}
