using System;
using Tao.FreeGlut;
using Tao.OpenGl;


namespace CGOpenGL1
{
    class Task3
    {
        private static int width = 800, height = 600;
        private static bool FillFlag = false;
        private static Random random = new Random();

        public static void Execute()
        {
            Glut.glutInit();
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutInitDisplayMode(Glut.GLUT_RGB);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("OpenGL Task3");
            Glut.glutDisplayFunc(Display);
            //Glut.glutIdleFunc(Display);
            //Glut.ReshapeFunc(Reshape);
            //Glut.glutKeyboardFunc(Keyboard);
            Glut.glutMouseFunc(Mouse);
            Init();
            Glut.glutMainLoop();
        }

        private static void Init()
        {
            random = new Random(DateTime.Now.Millisecond);
            Gl.glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
        }

        private static void Reshape(int w, int h)
        {
            width = w;
            height = h;
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(65.0f, (float)width / (float)height, 1.0f, 1000.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW); Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_MODELVIEW);
        }

        private static void Display()
        {
            float r,g,b;
			float x1,x2,y1,y2;
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            r = random.Next(0, 1); g = random.Next(0, 1); b = random.Next(0, 1);
            Gl.glColor3f(r,g,b);
            x1 = random.Next(0, 1)*height;
            x2 = random.Next(0, 1)*height;
            y1 = random.Next(0, 1)*width;
            y2 = random.Next(0, 1)*width;
            Gl.glBegin(FillFlag?Gl.GL_QUADS:Gl.GL_LINE_LOOP);
                Gl.glVertex2f(x1, y1);
                Gl.glVertex2f(x2, y1);
                Gl.glVertex2f(x2, y2);
                Gl.glVertex2f(x1, y2);
            Gl.glEnd();
            Gl.glFinish();
        }

        static void Mouse(int button, int state, int x, int y)
        {
            if (state == Glut.GLUT_DOWN ) {
                switch (button) {
                    case Glut.GLUT_LEFT_BUTTON:
                        random = new Random(DateTime.Now.Millisecond);
                        break;
                    case Glut.GLUT_RIGHT_BUTTON:
                        FillFlag = !FillFlag;
                    break;
                }
                Glut.glutPostRedisplay();
            }
        }


    }
}

