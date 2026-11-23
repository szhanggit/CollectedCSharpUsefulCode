using System;
using System.Reflection;
using System.IO;

namespace AppClassRef
{
    class AppClassRef
    {
        static void Main(string[] args)
        {
            DisAllAm();
            while (true)
            {
                Console.Write("请输入所检测的类型名称：");
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                Assembly am;
                try
                {
                    //am = Assembly.Load("ClassRef");
                    am = Assembly.LoadFrom(@"D:\C#\Reflection\8\ClassRef.exe");
                    Type tp = am.GetType("ClassRef." + input, false, false);
                    ClassB.Ref(tp);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("异常信息：{0}", e.Message);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("异常信息：{0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("异常信息：{0}", e.Message);
                }
                finally
                {
                    DisAllAm();
                }
            }
        }

        static void DisAllAm()
        {
            Console.WriteLine("\n\t=============当前应用程序域中所有加载的程序集================");
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine("程序集：{0}", a.FullName);
            }
        }
    }

    class ClassB
    {
        public static void Ref(Type tp)
        {
            string FullName = tp.FullName.ToString();
            Console.WriteLine("", FullName);

            MemberInfo[] mi = tp.GetMembers();
            foreach (MemberInfo m in mi)
            {
                Console.WriteLine("", m.MemberType, m.Name);
            }
            Type[] Itp = tp.GetInterfaces();
            if (Itp.Length != 0)
            {
                foreach (Type t in Itp)
                {
                    Console.WriteLine("", FullName, t.FullName);
                }
            }
            else
            {
                Console.WriteLine("", FullName);
            }
        }
    }
}
