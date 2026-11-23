using System;
using System.Reflection;
using System.IO;

namespace LateBindingOther
{
    class LateBindingOther
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n【1】请输入需写入Person的属性值：");
                string inputA = Console.ReadLine();
                Console.Write("\n【2】请输入需写入Person的字段值：");
                int inputB = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n\t==================以下是属性和字段被写入后读出的结果===================\n");
                ClassOP(inputA, inputB);
            }
            catch (FormatException e)
            {
                Console.WriteLine("异常信息：{0}", e.Message);
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

        static void ClassOP(string a, int b)
        {
            Assembly am = Assembly.Load("Human");
            Type tp = am.GetType("Person", false, false);
            object obj = Activator.CreateInstance(tp);
            tp.InvokeMember("Name", BindingFlags.SetProperty, null, obj, new string[] { a });
            string name = (string)tp.InvokeMember("Name", BindingFlags.GetProperty, null, obj, null);
            Console.WriteLine("Person类的Name属性值为：【{0}】", name);
            tp.InvokeMember("_age", BindingFlags.SetField, null, obj, new object[] { b });
            int age = (int)tp.InvokeMember("_age", BindingFlags.GetField, null, obj, null);
            Console.WriteLine("Person类的_age字段值为：【{0}】", age);
        }
    }
}
