using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    static class FunctionGenerator
    {
        const int rows = 16;
        const int columns = 5;

        static int[,] function = new int[,] {{0, 0, 0, 0, 0},
                                             {0, 0, 0, 1, 0},
                                             {0, 0, 1, 0, 0},
                                             {0, 0, 1, 1, 0},
                                             {0, 1, 0, 0, 0},
                                             {0, 1, 0, 1, 0},
                                             {0, 1, 1, 0, 0},
                                             {0, 1, 1, 1, 0},
                                             {1, 0, 0, 0, 0},
                                             {1, 0, 0, 1, 0},
                                             {1, 0, 1, 0, 0},
                                             {1, 0, 1, 1, 0},
                                             {1, 1, 0, 0, 0},
                                             {1, 1, 0, 1, 0},
                                             {1, 1, 1, 0, 0},
                                             {1, 1, 1, 1, 0}};

        public static string printFunc()
        {
            StringBuilder res = new StringBuilder();

            //Console.WriteLine("a  b  c  d  F");
            res.AppendLine("a    b    c    d    F");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //Console.Write(function[i, j] + "  ");
                    res.Append(function[i, j] + "    ");
                }
                //Console.WriteLine();
                res.AppendLine();
            }

            return res.ToString();
        }

        public static List<List<int>> getArrayOfUnits(int funcResult)
        {
            var res = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                if (function[i, columns - 1] == funcResult)
                {
                    var tmp = new List<int>();
                    for (int j = 0; j < columns - 1; j++)
                    {
                        tmp.Add(function[i, j]);
                    }
                    res.Add(tmp);
                }
            }
            return res;
        }

        public static void reduce(List<List<int>> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                //var tmp = arr[i];
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    int diffCnt = 0;
                    int diffInd = 0;
                    for (int k = 0; k < columns - 1; k++)
                    {
                        if (arr[i][k] != arr[j][k])
                        {
                            diffCnt++;
                            diffInd = k;
                        }
                    }

                    if (diffCnt == 1)
                    {
                        arr[i][diffInd] = 2;
                        arr.RemoveAt(j);
                        //arr[j][diffInd] = 2;
                        i = 0;
                    }
                }
            }
        }

        public static string printArrayAsDNF(List<List<int>> lst)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < lst.Count; i++)
            {
                StringBuilder s = new StringBuilder();
                for (int j = 0; j < columns - 1; j++)
                {
                    if (lst[i][j] == 2)
                    {
                        continue;
                    }

                    if (lst[i][j] == 0)
                    {
                        s.Append('!');
                    }

                    s.Append((char)(j + 'a') + "*");
                }
                s = s.Remove(s.Length - 1, 1);
                if (s.Length != 0)
                {
                    if (res.Length != 0)
                    {
                        res.Append(" + " + s);
                    }
                    else
                    {
                        res.Append(s);
                    }
                }
            }

            return res.ToString();
        }

        public static string printArrayAsKNF(List<List<int>> lst)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < lst.Count; i++)
            {
                StringBuilder s = new StringBuilder();
                s.Append('(');
                for (int j = 0; j < columns - 1; j++)
                {
                    if (lst[i][j] == 2)
                    {
                        continue;
                    }

                    if (lst[i][j] == 1)
                    {
                        s.Append('!');
                    }

                    s.Append((char)(j + 'a') + " + ");
                }

                if (s.Length != 0)
                {
                    s.Remove(s.Length - 3, 3);
                    s.Append(')');

                    if (res.Length != 0)
                    {
                        res.Append(" * " + s);
                    }
                    else
                    {
                        res.Append(s);
                    }
                }
            }

            return res.ToString();
        }

        public static void Init()
        {
            var rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                function[i, columns - 1] = rnd.Next(0, 2);
            }
        }

    }
}
