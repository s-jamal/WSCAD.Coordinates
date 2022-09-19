using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using WSCAD.Coordinates.Shapes.Interfaces;

namespace WSCAD.Coordinates.Shapes
{
  public abstract class ShapeDef : IDrawable, IResizable
  {
    /// <summary>
    /// Type, used in deserialising
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// Color
    /// </summary>
    public string Color { get; set; }
    protected float? _left;
    public float Left
    {
      get
      {
        if (_left == null)
          _left = CalculateLeft();

        return _left.Value;
      }
    }
    protected float? _top;
    public float Top {
      get
      {
        if (_top == null)
          _top = CalculateTop();

        return _top.Value;
      }
    }
    protected float? _right;
    public float Right {
      get
      {
        if (_right == null)
          _right = CalculateRight();

        return _right.Value;
      }
    }
    protected float? _bottom;
    public float Bottom {
      get
      {
        if (_bottom == null)
          _bottom = CalculateBottom();

        return _bottom.Value;
      }
    }
    protected abstract float CalculateLeft();
    protected abstract float CalculateTop();
    protected abstract float CalculateRight();
    protected abstract float CalculateBottom();

    public abstract void Draw(Renderer.Renderer renderer);
    public abstract void Resize(float ratio);

    private ColorDef? _colorArgb;
    public ColorDef ColorArgb
    {
      get
      {
        if (_colorArgb == null)
          _colorArgb = GetColorARGB();

        return _colorArgb.Value;
      }
      protected set { ColorArgb = value; }
    }

    private ColorDef GetColorARGB()
    {
      // Describes the brush's color using RGB values.
      // Each value has a range of 0-255.
      string[] colorARGB = this.Color.Split("; ");
      var color = new ColorDef(byte.Parse(colorARGB[0]), byte.Parse(colorARGB[1]), byte.Parse(colorARGB[2]), byte.Parse(colorARGB[3]));
      return color;
    }

  }
}
