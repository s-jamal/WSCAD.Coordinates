using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WSCAD.Coordinates.Shapes
{
  public class MyCanvas : Canvas
  {
    public PointDef Center => new PointDef((float)Width / 2, (float)Height / 2);
    public string Color { get; private set; }
    private float? _leftCoordinate;
    public float LeftCoordinate
    {
      get
      {
        if (_leftCoordinate == null)
          _leftCoordinate = (float)Width / 2 * -1;

        return _leftCoordinate.Value;
      }
    }
    private float? _topCoordinate;
    public float TopCoordinate {
      get
      {
        if (_topCoordinate == null)
          _topCoordinate = (float)Height / 2;

        return _topCoordinate.Value;
      }
    }
    private float? _rightCoordinate;
    public float RightCoordinate {
      get
      {
        if (_rightCoordinate == null)
          _rightCoordinate = (float)Width / 2;

        return _rightCoordinate.Value;
      }
    }
    private float? _bottomCoordinate;
    public float BottomCoordinate {
      get
      {
        if (_bottomCoordinate == null)
          _bottomCoordinate = (float)Height / 2 * -1;

        return _bottomCoordinate.Value;
      }
    }
  }
}
