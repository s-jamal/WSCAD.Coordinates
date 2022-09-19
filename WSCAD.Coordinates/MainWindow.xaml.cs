using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSCAD.Coordinates.FileReaders;
using WSCAD.Coordinates.Shapes;

namespace WSCAD.Coordinates
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    MyCanvas mainCanvas;

    public MainWindow()
    {
      InitializeComponent();
      // set culture, mainly for comma separator in coordinates
      SetCulture();
      // create canvas with center point
      InitializeCanvas();

      // define types with respective constructor
      Dictionary<string, Func<ShapeDef>> typeCommands = new Dictionary<string, Func<ShapeDef>>()
      {
        {"LINE", () => new LineDef() },
        {"TRIANGLE", () => new TriangleDef() },
        {"CIRCLE", () => new CircleDef() },
      };

      ShapeReader shapeReader = new ShapeReader(new JsonDeserializer(), typeCommands);

      var dataDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Data\shapes.json";
      List<ShapeDef> shapes = shapeReader.GetObjectsFromFile(dataDirectory);

      Draw(shapes, mainCanvas);
    }


    private static void SetCulture()
    {
      var culture = new System.Globalization.CultureInfo("en-IN");
      culture.NumberFormat.NumberDecimalSeparator = ",";
      System.Threading.Thread.CurrentThread.CurrentCulture = culture;
      System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
      FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                  XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)));
    }

    public void InitializeCanvas()
    {
      // Create a SolidColorBrush with a red color to fill the
      // Ellipse with.
      SolidColorBrush mySolidColorBrush = new SolidColorBrush();

      // Describes the brush's color using RGB values.
      // Each value has a range of 0-255.
      mySolidColorBrush.Color = Color.FromArgb(127, 127, 127, 127);


      mainCanvas = new MyCanvas();
      mainCanvas.Height = 200;
      mainCanvas.Width = 200;
      mainCanvas.Background = mySolidColorBrush;

      AddCenterPoint(mainCanvas);

      this.Content = mainCanvas;
    }

    public void AddCenterPoint(MyCanvas canvas)
    {
      // Create a SolidColorBrush with a black color to fill the
      // Ellipse with.
      SolidColorBrush mySolidColorBrush = new SolidColorBrush();

      // Describes the brush's color using RGB values.
      // Each value has a range of 0-255.
      mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 0);

      // Create a black for center Ellipse.
      Ellipse myEllipse = new Ellipse();
      myEllipse.Fill = mySolidColorBrush;
      myEllipse.StrokeThickness = 1;
      myEllipse.Stroke = Brushes.Black;

      // Set the width and height of the Ellipse.
      myEllipse.Width = 1;
      myEllipse.Height = 1;

      Canvas.SetTop(myEllipse, canvas.Center.Y - (myEllipse.Height / 2));
      Canvas.SetLeft(myEllipse, canvas.Center.X - (myEllipse.Width / 2));

      canvas.Children.Add(myEllipse);
    }

    public void Draw(List<ShapeDef> shapes, MyCanvas canvas)
    {
      var renderer = new Renderer.Renderer(canvas);

      // resize shapes to fit into canvas
      renderer.ResizeShapesToFit(shapes);

      foreach (ShapeDef item in shapes)
      {
        item.Draw(renderer);
      }
    }
  }
}
