using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CGOpenGL1
{
    class Task2
    {
        private static int width = 800, height = 600;
        private static bool isColor = false;

        public static void Execute(int i = 1)
        {
            Glut.glutInit();
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("OpenGL Task2");
            if(i == 1) 
                Glut.glutDisplayFunc(RenderTriangle);
            if (i == 2)
                Glut.glutDisplayFunc(RenderQuads);
            if (i == 3)
            {
                isColor = true;
                Glut.glutDisplayFunc(RenderTriangle);
            }
            Init();
            Glut.glutMainLoop();
        }

        private static void Init()
        {
            Gl.glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
        }

        private static void RenderTriangle()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            if (isColor) Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            Gl.glBegin(Gl.GL_TRIANGLES);
            if (isColor) Gl.glColor3f(1.0f, 0.0f, 0.0f);
            else Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2f(-0.5f, -0.5f);
            if (isColor) Gl.glColor3f(0.0f, 1.0f, 0.0f);
            else Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2f(-0.5f, 0.5f);
            if (isColor) Gl.glColor3f(0.0f, 0.0f, 1.0f);
            else Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2f(0.5f, 0.5f);
            Gl.glEnd();

            Gl.glFlush();
            Glut.glutSwapBuffers();
        }

        private static void RenderQuads()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0.0f, 0.0f, 0.0f); Gl.glVertex2f(-0.5f, -0.5f);
            Gl.glColor3f(0.0f, 0.0f, 0.0f); Gl.glVertex2f(-0.5f, 0.5f);
            Gl.glColor3f(0.0f, 0.0f, 0.0f); Gl.glVertex2f(0.5f, 0.5f);
            Gl.glColor3f(0.0f, 0.0f, 0.0f); Gl.glVertex2f(0.5f, -0.5f);
            Gl.glEnd();

            Gl.glFlush();
            Glut.glutSwapBuffers();
        }
    }
}
