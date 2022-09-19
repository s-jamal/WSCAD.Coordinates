using System;
using System.Collections.Generic;
using System.Text;

namespace WSCAD.Coordinates.Shapes
{
  public class CircleDef : ShapeDef
  {
    /// <summary>
    /// Center point
    /// </summary>
    public string Center { get; set; }
    /// <summary>
    /// Radius
    /// </summary>
    public float Radius { get; set; }
    /// <summary>
    /// If filled, shape has filling
    /// </summary>
    public bool Filled { get; set; }

    private PointDef _centerPoint;

    public PointDef CenterPoint
    {
      get
      {
        if (_centerPoint == null)
        {
          _centerPoint = new PointDef(Center);
        }

        return _centerPoint;
      }
    }

    

    public override void Resize(float ratio)
    {
      _centerPoint = new PointDef(CenterPoint.X * ratio, CenterPoint.Y * ratio);
      Radius = Radius * ratio;
    }

    protected override float CalculateLeft()
    {
      return CenterPoint.X - Radius;
    }

    protected override float CalculateTop()
    {
      return CenterPoint.Y + Radius;
    }

    protected override float CalculateRight()
    {
      return CenterPoint.X + Radius;
    }

    protected override float CalculateBottom()
    {
      return CenterPoint.Y - Radius;
    }

    public override void Draw(Renderer.Renderer renderer)
    {
      renderer.Draw(this);
    }
  }
}
