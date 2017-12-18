using System;
using System.Collections.Generic;
using System.Text;
using Fbx;

namespace test
{

    class Log
    {
        public static void Info(object s)
        {
            Console.WriteLine(s);
        }

        public static void Error(object s)
        {
            Console.WriteLine(s);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {

            //Program pro = new Program();
            MyExport aMyExport = new MyExport();
            aMyExport.Init();
            aMyExport.CreateDocument();
            aMyExport.Clear();

        }


    }
}
