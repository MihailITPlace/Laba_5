using System;
using System.Drawing;

namespace WindowsFormsApp
{
    static class FunctionDraftsman
    {
        static int x1 = 10;
        static int x2 = 110;
        static int x3 = 210;
        static int x4 = 310;
        static int y = 10;

        public static void Draws(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, x1, y, x1, y + 700);
            g.DrawLine(pen, x1, y + 20, x1 + 50, y + 20);
            g.DrawLine(pen, x1 + 50, y + 20, x1 + 50, y + 40);
            DrawNot(g, x1 + 35, y + 40);
            g.DrawLine(pen, x1 + 50, y + 75, x1 + 50, y + 700);


            g.DrawLine(pen, x2, y, x2, y + 700);
            g.DrawLine(pen, x2, y + 20, x2 + 50, y + 20);
            g.DrawLine(pen, x2 + 50, y + 20, x2 + 50, y + 40);
            DrawNot(g, x2 + 35, y + 40);
            g.DrawLine(pen, x2 + 50, y + 75, x2 + 50, y + 700);


            g.DrawLine(pen, x3, y, x3, y + 700);
            g.DrawLine(pen, x3, y + 20, x3 + 50, y + 20);
            g.DrawLine(pen, x3 + 50, y + 20, x3 + 50, y + 40);
            DrawNot(g, x3 + 35, y + 40);
            g.DrawLine(pen, x3 + 50, y + 75, x3 + 50, y + 700);


            g.DrawLine(pen, x4, y, x4, y + 700);
            g.DrawLine(pen, x4, y + 20, x4 + 50, y + 20);
            g.DrawLine(pen, x4 + 50, y + 20, x4 + 50, y + 40);
            DrawNot(g, x4 + 35, y + 40);
            g.DrawLine(pen, x4 + 50, y + 75, x4 + 50, y + 700);

            Font myFont = new Font("TimesNewRoman", 10, FontStyle.Regular);
            g.DrawString("A", myFont, Brushes.Black, new Point(x1 + 5, y));
            g.DrawString("! A", myFont, Brushes.Black, new Point(x1 + 45, y));
            g.DrawString("B", myFont, Brushes.Black, new Point(x2 + 5, y));
            g.DrawString("! B", myFont, Brushes.Black, new Point(x2 + 45, y));
            g.DrawString("C", myFont, Brushes.Black, new Point(x3 + 5, y));
            g.DrawString("! C", myFont, Brushes.Black, new Point(x3 + 45, y));
            g.DrawString("D", myFont, Brushes.Black, new Point(x4 + 5, y));
            g.DrawString("! D", myFont, Brushes.Black, new Point(x4 + 45, y));
        }

        public static void DrawNot(Graphics g, int a, int b)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, a, b, a + 30, b);
            g.DrawLine(pen, a, b, a, b + 30);
            g.DrawLine(pen, a + 30, b, a + 30, b + 30);
            g.DrawLine(pen, a, b + 30, a + 10, b + 30);
            g.DrawLine(pen, a + 20, b + 30, a + 30, b + 30);
            g.DrawEllipse(pen, a + 10, b + 25, 10, 10);

        }

        private static string[] getMultipliers(string term)
        {
            return term.Split('*');
        }

        private static string[] getTerms(string str)
        {
            var result = str.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }

        public static void DrawDNF(Graphics g, string str)
        {
            Draws(g);
            int k = 0;
            string[] terms = getTerms(str);
            foreach (var term in terms)
            {
                int l = 0;

                string[] multipliers = getMultipliers(term);

                foreach (var mult in multipliers)
                {
                    switch (mult)
                    {
                        case "a":
                            DrawA(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!a":
                            DrawNotA(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "b":
                            DrawB(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!b":
                            DrawNotB(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "c":
                            DrawC(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!c":
                            DrawNotC(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "d":
                            DrawD(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!d":
                            DrawNotD(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                    }

                }

                DrawAnd(g, x1 + 400, 80 + k, l * 5 + 25);
                k += 40;
            }

            Draw1(g, x1 + 467, y + 80, k);
        }

        public static void DrawKNF(Graphics g, string str)
        {
            Draws(g);
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            int k = 0;
            string[] multipliers = getMultipliers(str);
            foreach (var mult in multipliers)
            {
                int l = 0;

                string[] terms = getTerms(mult);

                foreach (var term in terms)
                {
                    switch (term)
                    {
                        case "a":
                            DrawA(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!a":
                            DrawNotA(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "b":
                            DrawB(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!b":
                            DrawNotB(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "c":
                            DrawC(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!c":
                            DrawNotC(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "d":
                            DrawD(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                        case "!d":
                            DrawNotD(g, y + 100 + k);
                            k += 5;
                            l++;
                            break;
                    }
                }

                Draw1(g, x1 + 400, 80 + k, l * 5 + 25);
                k += 40;
            }

            DrawAnd(g, x1 + 467, y + 80, k);

        }

        public static void DrawA(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x1 - 5, b, 10, 10);
            g.DrawLine(pen, x1, b + 5, x1 + 400, b + 5);
        }

        public static void DrawNotA(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x1 + 50 - 5, b, 10, 10);
            g.DrawLine(pen, x1 + 50, b + 5, x1 + 50 + 350, b + 5);
        }

        public static void DrawB(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x2 - 5, b, 10, 10);
            g.DrawLine(pen, x2, b + 5, x2 + 300, b + 5);
        }

        public static void DrawNotB(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x2 + 50 - 5, b, 10, 10);
            g.DrawLine(pen, x2 + 50, b + 5, x2 + 50 + 250, b + 5);
        }

        public static void DrawC(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x3 - 5, b, 10, 10);
            g.DrawLine(pen, x3, b + 5, x3 + 200, b + 5);
        }

        public static void DrawNotC(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x3 + 50 - 5, b, 10, 10);
            g.DrawLine(pen, x3 + 50, b + 5, x3 + 50 + 150, b + 5);
        }

        public static void DrawD(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x4 - 5, b, 10, 10);
            g.DrawLine(pen, x4, b + 5, x4 + 100, b + 5);
        }

        public static void DrawNotD(Graphics g, int b)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x4 + 50 - 5, b, 10, 10);
            g.DrawLine(pen, x4 + 50, b + 5, x4 + 50 + 50, b + 5);
        }

        public static void Draw1(Graphics g, int a, int b, int d)
        {
            Pen pen = new Pen(Color.Black);

            g.DrawRectangle(pen, a, b, 30, d);
            g.DrawLine(pen, a + 30, b + 25, a + 65, b + 25);
            Font myFont = new Font("TimesNewRoman", 14);
            g.DrawString("1", myFont, Brushes.Black, new Point(a + 5, b + 5));
        }

        public static void DrawAnd(Graphics g, int a, int b, int d)
        {
            Pen pen = new Pen(Color.Black);

            g.DrawRectangle(pen, a, b, 30, d);
            g.DrawLine(pen, a + 30, b + 25, a + 65, b + 25);
            Font myFont = new Font("TimesNewRoman", 14);
            g.DrawString("&", myFont, Brushes.Black, new Point(a + 5, b + 5));


        }
    }
}
