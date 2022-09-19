using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates.Renderer
{
  /// <summary>
  /// Converts to Windows shapes, and draws on canvas
  /// </summary>
  public class Renderer
  {
    private readonly MyCanvas _canvas;

    /// <summary>
    /// Creates Renderer object with canvas to draw onto
    /// </summary>
    /// <param name="canvas"></param>
    public Renderer(MyCanvas canvas)
    {
      this._canvas = canvas;
    }

    private System.Windows.Media.Color ConvertColor(ColorDef colorDef)
    {
      return System.Windows.Media.Color.FromArgb(colorDef.A, colorDef.R, colorDef.G, colorDef.B);
    }

    public void Draw(CircleDef circle)
    {
      // Create a red Ellipse.0
      Ellipse myEllipse = new Ellipse();


      // Create a SolidColorBrush with a object's color
      var color = ConvertColor(circle.ColorArgb);
      SolidColorBrush mySolidColorBrush = new SolidColorBrush(color);

      myEllipse.StrokeThickness = 1;
      myEllipse.Stroke = mySolidColorBrush;

      // fill the shape if flagged
      if (circle.Filled)
        myEllipse.Fill = mySolidColorBrush;


      // Set the width and height of the Ellipse.
      myEllipse.Width = circle.Radius * 2;
      myEllipse.Height = circle.Radius * 2;

      Canvas.SetTop(myEllipse, _canvas.Center.Y - circle.CenterPoint.Y - circle.Radius);
      Canvas.SetLeft(myEllipse, _canvas.Center.X + circle.CenterPoint.X - circle.Radius);

      // Add the Ellipse to the StackPanel.
      _canvas.Children.Add(myEllipse);
    }

    public void Draw(TriangleDef triangle)
    {
      //Add the Polygon Element
      Polygon myPolygon = new Polygon();

      // Create a SolidColorBrush with a object's color
      var color = ConvertColor(triangle.ColorArgb);
      SolidColorBrush mySolidColorBrush = new SolidColorBrush(color);

      myPolygon.StrokeThickness = 1;
      myPolygon.Stroke = mySolidColorBrush;

      // fill the shape if flagged
      if (triangle.Filled)
        myPolygon.Fill = mySolidColorBrush;


      System.Windows.Point Point1 = new System.Windows.Point(_canvas.Center.X + triangle.PointA.X, _canvas.Center.Y - triangle.PointA.Y);
      System.Windows.Point Point2 = new System.Windows.Point(_canvas.Center.X + triangle.PointB.X, _canvas.Center.Y - triangle.PointB.Y);
      System.Windows.Point Point3 = new System.Windows.Point(_canvas.Center.X + triangle.PointC.X, _canvas.Center.Y - triangle.PointC.Y);

      PointCollection myPointCollection = new PointCollection();
      myPointCollection.Add(Point1);
      myPointCollection.Add(Point2);
      myPointCollection.Add(Point3);

      myPolygon.Points = myPointCollection;

      _canvas.Children.Add(myPolygon);
    }

    public void Draw(LineDef line)
    {
      // Add a Line Element
      Line myLine = new Line();

      // Create a SolidColorBrush with a object's color
      var color = ConvertColor(line.ColorArgb);
      SolidColorBrush mySolidColorBrush = new SolidColorBrush(color);
      myLine.Stroke = mySolidColorBrush;

      myLine.StrokeThickness = 1;

      myLine.X1 = _canvas.Center.X + line.PointA.X;
      myLine.Y1 = _canvas.Center.Y - line.PointA.Y;

      myLine.X2 = _canvas.Center.X + line.PointB.X;
      myLine.Y2 = _canvas.Center.Y - line.PointB.Y;

      // Add the Line to the Canvas.
      _canvas.Children.Add(myLine);
    }

    /// <summary>
    /// Checks if shapes fit into canvas, if not resizes shapes with same aspect ratio
    /// </summary>
    /// <param name="shapes"></param>
    public void ResizeShapesToFit(List<ShapeDef> shapes)
    {
      float leftMost = float.MaxValue;
      float rightMost = float.MinValue;
      float topMost = float.MinValue;
      float bottomMost = float.MaxValue;
      float ratio = 1;

      for (int i = 0; i < shapes.Count; i++)
      {
        leftMost = Math.Min(leftMost, shapes[i].Left);
        rightMost = Math.Max(rightMost, shapes[i].Right);
        topMost = Math.Max(topMost, shapes[i].Top);
        bottomMost = Math.Min(bottomMost, shapes[i].Bottom);
      }

      if (leftMost < 0 && leftMost < _canvas.LeftCoordinate)
      {
        ratio = Math.Max(ratio, leftMost / _canvas.LeftCoordinate);
      }

      if (rightMost > 0 && rightMost > _canvas.RightCoordinate)
      {
        ratio = Math.Max(ratio, rightMost / _canvas.RightCoordinate);
      }

      if (topMost > 0 && topMost > _canvas.TopCoordinate)
      {
        ratio = Math.Max(ratio, topMost / _canvas.TopCoordinate);
      }

      if (bottomMost < 0 && bottomMost < _canvas.BottomCoordinate)
      {
        ratio = Math.Max(ratio, bottomMost / _canvas.BottomCoordinate);
      }

      if (ratio == 1)
      {
        return;
      }

      for (int i = 0; i < shapes.Count; i++)
      {
        shapes[i].Resize(1 / ratio);
      }
    }
  }
}
