using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            glControl1.Paint += glControl1_Paint;
            glControl1.Load += glControl1_Load;
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.White);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            DrawBlackSquare();
            DrawRedSquareWithBlackShadow();
            DrawBlackDiagonalLine();
            DrawRectangleWithFourBlackLines();
            DrawTriangleWithGradient();

            glControl1.SwapBuffers();
        }

        private void DrawBlackSquare()
        {
            GL.PushMatrix();
            GL.Translate(-0.5, 0.5, 0);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.2, -0.2);
            GL.Vertex2(-0.2, 0.2);
            GL.Vertex2(0.2, 0.2);
            GL.Vertex2(0.2, -0.2);
            GL.End();
            GL.PopMatrix();
        }

        private void DrawRedSquareWithBlackShadow()
        {
            GL.PushMatrix();
            GL.Translate(0.5, 0.5, 0);

            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.2, -0.2);
            GL.Vertex2(-0.2, 0.2);
            GL.Vertex2(0.2 + 0.05, 0.2 + 0.05);
            GL.Vertex2(0.2 + 0.05, -0.2 - 0.05);
            GL.End();

            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.2, -0.2);
            GL.Vertex2(-0.2, 0.2);
            GL.Vertex2(0.2, 0.2);
            GL.Vertex2(0.2, -0.2);
            GL.End();

            GL.PopMatrix();
        }

        private void DrawBlackDiagonalLine()
        {
            GL.PushMatrix();
            GL.Translate(-0.5, -0.5, 0);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(-0.2, -0.2);
            GL.Vertex2(0.2, 0.2);
            GL.End();
            GL.PopMatrix();
        }

        private void DrawRectangleWithFourBlackLines()
        {
            GL.PushMatrix();
            GL.Translate(0.5, -0.5, 0);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex2(-0.2, -0.2);
            GL.Vertex2(-0.2, 0.2);
            GL.Vertex2(0.2, 0.2);
            GL.Vertex2(0.2, -0.2);
            GL.End();
            GL.PopMatrix();
        }

        private void DrawTriangleWithGradient()
        {
            GL.PushMatrix();
            GL.Translate(0, 0, 0);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Blue);
            GL.Vertex2(-0.2, 0.2);

            GL.Color3(Color.Red);
            GL.Vertex2(-0.6, -0.2);

            GL.Color3(Color.Green);
            GL.Vertex2(0.2, -0.2);
            GL.End();
            GL.PopMatrix();
        }
    }
}
