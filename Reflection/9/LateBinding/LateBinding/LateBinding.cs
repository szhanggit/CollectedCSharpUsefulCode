using System;
using System.Reflection;
using System.IO;

namespace LateBinding
{
    class LateBinding
    {
        static void Main(string[] args)
        {
            Console.Write("\n【1】请输入传递给OldClass类Method静态方法的参数：");
            string inputA = Console.ReadLine();
            Console.Write("\n【2】请输入传递给NewClass类Method方法的参数：");
            string inputB = Console.ReadLine();
            Console.Write("\n【3】请输入传递给MyClass类Method方法的参数：");
            string inputC = Console.ReadLine();
            Console.WriteLine("\n\t===========以下是不同程序集的不同方法调用结果============\n");

            try
            {
                LoadOldClass(inputA);
                LoadNewClass(inputB);
                LoadMyClass(inputC);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("异常信息：{0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("异常信息：{0}", e.Message);
            }
        }

        static void LoadOldClass(string input)
        {
            //Assembly am = Assembly.Load("OldClass");
            Assembly am = Assembly.LoadFrom(@"D:\C#\Reflection\9\OldClass.dll");
            Type OldTp = am.GetType("OldClass", false, false);
            string[] OldList = new string[1] { input };
            string txt = (string)OldTp.InvokeMember("Method", BindingFlags.InvokeMethod, null, null, OldList);
            Console.WriteLine(txt);
        }

        static void LoadNewClass(string input)
        {
            object obj = AppDomain.CurrentDomain.CreateInstanceAndUnwrap("NewClass", "NewClass");
            Type Newtp = obj.GetType();
            string[] NewList = new string[1] { input };
            string txt = (string)Newtp.InvokeMember("Method", BindingFlags.InvokeMethod, null, obj, NewList);
            Console.WriteLine(txt);
        }

        static void LoadMyClass(string input)
        {
            string[] MyList = new string[1] { input };
            Assembly MyAm = Assembly.Load("MyClass");
            Type MyTp = MyAm.GetType("MyClass", false, false);
            object MyObj = Activator.CreateInstance(MyTp);
            MethodInfo mi = MyTp.GetMethod("Method");
            string txt = (string)mi.Invoke(MyObj, MyList);
            Console.WriteLine(txt);
            mi = MyTp.GetMethod("MethodTxt");
            txt = (string)mi.Invoke(MyObj, null);
            Console.WriteLine(txt);
        }
    }
}
