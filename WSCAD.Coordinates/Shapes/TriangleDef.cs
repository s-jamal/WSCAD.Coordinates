using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCAD.Coordinates.Shapes
{
  public class TriangleDef : ShapeDef
  {
    public TriangleDef()
    {

    }

    /// <summary>
    /// Point A
    /// </summary>
    public string A { get; set; }
    private PointDef _pointA;

    /// <summary>
    /// Point A
    /// </summary>
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
    /// Point B
    /// </summary>
    public string B { get; set; }

    private PointDef _pointB;
    /// <summary>
    /// Point B
    /// </summary>
    public PointDef PointB
    {
      get
      {
        if (_pointB == null)
          _pointB = new PointDef(B);

        return _pointB;
      }
    }

    /// <summary>
    /// Point C
    /// </summary>
    public string C { get; set; }

    private PointDef _pointC;
    /// <summary>
    /// Point C
    /// </summary>
    public PointDef PointC
    {
      get
      {
        if (_pointC == null)
          _pointC = new PointDef(C);

        return _pointC;
      }
    }
    /// <summary>
    /// If filled, shape has filling
    /// </summary>
    public bool Filled { get; set; }


    public override void Draw(Renderer.Renderer renderer)
    {
      renderer.Draw(this);
    }

    public override void Resize(float ratio)
    {
      _pointA = new PointDef(PointA.X * ratio, PointA.Y * ratio);
      _pointB = new PointDef(PointB.X * ratio, PointB.Y * ratio);
      _pointC = new PointDef(PointC.X * ratio, PointC.Y * ratio);
    }

    protected override float CalculateLeft()
    {
      return Math.Min(PointA.X, Math.Min(PointB.X, PointC.X));
    }

    protected override float CalculateTop()
    {
      return Math.Max(PointA.Y, Math.Max(PointB.Y, PointC.Y));
    }

    protected override float CalculateRight()
    {
      return Math.Max(PointA.X, Math.Max(PointB.X, PointC.X));
    }

    protected override float CalculateBottom()
    {
      return Math.Min(PointA.Y, Math.Min(PointB.Y, PointC.Y));
    }
  }
}
