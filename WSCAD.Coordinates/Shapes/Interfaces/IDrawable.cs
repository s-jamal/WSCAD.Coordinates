using System;
using System.Collections.Generic;
using System.Text;

namespace WSCAD.Coordinates.Shapes.Interfaces
{
  public interface IDrawable
  {
    public void Draw(Renderer.Renderer renderer);
  }
}
