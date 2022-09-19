using System;
using System.Collections.Generic;
using System.Text;

namespace WSCAD.Coordinates.Shapes
{
  public struct ColorDef
  {
    // alpha
    public byte A { get; set; }
    // red
    public byte R { get; set; }
    // green
    public byte G { get; set; }
    // blue
    public byte B { get; set; }

    public ColorDef(byte a, byte r, byte g, byte b)
    {
      A = a;
      R = r;
      G = g;
      B = b;
    }
  }
}
