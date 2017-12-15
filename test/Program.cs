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

   


        void Run()
        {

            FbxManager manager = FbxManager.Create();
            //manager.SetIOSettings()
            FbxIOSettings ios = FbxIOSettings.Create(manager, "IOSRoot");
            manager.SetIOSettings(ios);

        }


        static void Main(string[] args)
        {
            
            Program pro = new Program();
            pro.Run();
        }


    }
}
