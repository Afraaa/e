using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("输入一个数字：");
            string str = System.Console.ReadLine();
            double n = int.Parse(str);
            Random r = new Random();
            double count = 0;
            for (int i = 0; i < n;i++ )
            {
                double pointx = r.NextDouble();
                double pointy = r.NextDouble();
                double t = (pointy - 0.5) * (pointy - 0.5) + (pointx - 0.5) * (pointx - 0.5);
                if (t <= 0.25)
                {
                    count++;
                }
            }
            double pi = (count*4) / n;
            System.Console.WriteLine("pi:" + pi);

            System.Console.ReadKey();
        }
    }
}
