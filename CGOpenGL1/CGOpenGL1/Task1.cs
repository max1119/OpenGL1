using System;
using Tao.FreeGlut;
using Tao.OpenGl;


namespace CGOpenGL1
{
    class Task1
    {
        private static int width = 800, height = 600;
        private static int rotate_x=0, rotate_y=0, rotate_z=0;

        public static void Execute()
        {
            Glut.glutInit();
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("OpenGL Task1");
            Glut.glutDisplayFunc(RenderWireCube);
            Glut.glutIdleFunc(RenderWireCube);
            Glut.glutSpecialFunc(specialKeys);
            Init();
            Glut.glutMainLoop();
        }

        private static void specialKeys(int key, int x, int y)
        {
            switch (key) {
                case Glut.GLUT_KEY_UP: rotate_x += 5; break;
                case Glut.GLUT_KEY_DOWN: rotate_x -= 5; break;
                case Glut.GLUT_KEY_RIGHT: rotate_y += 5; break;
                case Glut.GLUT_KEY_LEFT: rotate_y -= 5; break;
                case Glut.GLUT_KEY_PAGE_UP: rotate_z += 5; break;
                case Glut.GLUT_KEY_PAGE_DOWN: rotate_z -= 5; break;
            }
            Glut.glutPostRedisplay();
        }

        private static void Init()
        {
            Gl.glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
        }

        private static void RenderWireCube()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            
            Gl.glRotated(15+rotate_x, 1.0, 0.0, 0.0);
            Gl.glRotated(15+rotate_y, 0.0, 1.0, 0.0);
            Gl.glRotated(15+rotate_z, 0.0, 0.0, 1.0);
            Glut.glutWireCube(1);

            Gl.glFlush();
            Glut.glutSwapBuffers();
        }
    }
}
