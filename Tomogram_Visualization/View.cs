using OpenTK.Graphics.ES10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogram_Visualization
{
    class View
    {
        public void SetupView(int width, int height)
        {
            GL.ShadeModel((All)ShadingModel.Smooth);
            GL.MatrixMode((All)MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }
    }
}
