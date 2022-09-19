using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCAD.Coordinates.Shapes
{
  public static class ShapeDrawer
  {
    public static void Draw(this CircleDef circle, MyCanvas canvas)
    {
      // Create a red Ellipse.
      Ellipse myEllipse = new Ellipse();

      // Create a SolidColorBrush with a red color to fill the
      // Ellipse with.
      SolidColorBrush mySolidColorBrush = new SolidColorBrush();

      // Describes the brush's color using RGB values.
      // Each value has a range of 0-255.
      string[] colorARGB = circle.Color.Split("; ");
      mySolidColorBrush.Color = System.Windows.Media.Color.FromArgb(byte.Parse(colorARGB[0]), byte.Parse(colorARGB[1]), byte.Parse(colorARGB[2]), byte.Parse(colorARGB[3]));
      if (circle.Filled)
        myEllipse.Fill = mySolidColorBrush;

      string[] circleCenterPointCoordinates = circle.Center.Split("; ");
      PointDef circleCenterPoint = new PointDef(float.Parse(circleCenterPointCoordinates[0]), float.Parse(circleCenterPointCoordinates[1]));

      myEllipse.StrokeThickness = 1;
      myEllipse.Stroke = mySolidColorBrush;

      // Set the width and height of the Ellipse.
      myEllipse.Width = circle.Radius * 2;
      myEllipse.Height = circle.Radius * 2;

      var canvasCenter = canvas.Center;

      Canvas.SetTop(myEllipse, canvasCenter.Y - circleCenterPoint.Y - circle.Radius);
      Canvas.SetLeft(myEllipse, canvasCenter.X - circleCenterPoint.X - circle.Radius);

      // Add the Ellipse to the StackPanel.
      canvas.Children.Add(myEllipse);
    }
  }
}
