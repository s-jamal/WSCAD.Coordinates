using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WSCAD.Coordinates.Shapes
{
  public class LineDef : ShapeDef
  {
    public LineDef()
    {

    }
    public LineDef(string a, string b)
    {
      A = a;
      B = b;
    }

    /// <summary>
    /// Starting point
    /// </summary>
    public string A { get; set; }
    private PointDef _pointA;

    public PointDef PointA
    {
      get
      {
        if (_pointA == null)
          _pointA = new PointDef(A);

        return _pointA;
      }
    }
    /// <summary>
    /// Ending point
    /// </summary>
    public string B { get; set; }


    private PointDef _pointB;

    public PointDef PointB
    {
      get
      {
        if (_pointB == null)
          _pointB = new PointDef(B);

        return _pointB;
      }
    }

    public override void Draw(Renderer.Renderer renderer)
    {
      renderer.Draw(this);
    }

    public override void Resize(float ratio)
    {
      _pointA = new PointDef(PointA.X * ratio, PointA.Y * ratio); 
      _pointB = new PointDef(PointB.X * ratio, PointB.Y * ratio); 
    }

    protected override float CalculateLeft()
    {
      return Math.Min(PointA.X, PointB.X);
    }

    protected override float CalculateTop()
    {
      return Math.Max(PointA.Y, PointB.Y);
    }

    protected override float CalculateRight()
    {
      return Math.Max(PointA.X, PointB.X);
    }

    protected override float CalculateBottom()
    {
      return Math.Min(PointA.Y, PointB.Y);
    }
  }
}
