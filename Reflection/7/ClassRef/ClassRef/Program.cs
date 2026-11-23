using System;
using System.Reflection;

namespace ClassRef
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("请输入所检测的类型名称：");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }
                try
                {
                    Type tp = Type.GetType("ClassRef."+input, false, false);
                    ClassB.Ref(tp);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Exceiption Message: {0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exceiption Message: {0}", e.Message);
                }
            }
        }
    }

    public interface IClassA { string MethodA(string s); }

    public interface IClassB { string Name { get; } }

    class ClassA : IClassA, IClassB
    {
        public string _name;
        public string Name
        {
            get {
                return _name;
            }
        }

        public string MethodA(string s)
        {
            _name = s;
            return _name;
        }

        public ClassA(string s)
        {
            Console.WriteLine("所接受的参数是：{0}", s);
        }
    }
    class ClassB
    {
        string _name;

        internal string MethodB(string s)
        {
            _name = s;
            return _name;
        }

        public static void Ref(Type tp)
        {
            string FullName = tp.FullName;
            Console.WriteLine("\n\t=============={0}类型的信息===============", FullName);

            Console.WriteLine("{0}Is generic type? -> {1}", FullName, tp.IsGenericType);
            Console.WriteLine("{0}Is interface? -> {1}", FullName, tp.IsInterface);
            Console.WriteLine("{0}Is class? -> {1}", FullName, tp.IsClass);
            Console.WriteLine("{0}Is Com Object? -> {1}", FullName, tp.IsCOMObject);
            Console.WriteLine("{0}Is public? -> {1}", FullName, tp.IsPublic);
            Console.WriteLine("{0}Is sealed? -> {1}", FullName, tp.IsSealed);
            Console.WriteLine("{0}Is value type? -> {1}", FullName, tp.IsValueType);

            MemberInfo[] mi = tp.GetMembers();
            foreach (MemberInfo m in mi)
            {
                Console.WriteLine("\t成员类别->{0}, 名称->{1}", m.MemberType, m.Name);
            }

            Type[] Itp = tp.GetInterfaces();

            if (Itp.Length != 0)
            {
                foreach (Type t in Itp)
                {
                    Console.WriteLine("{0}实现的接口类型->{1}", FullName, t.FullName);
                }
            }
            else
            {
                Console.WriteLine("{0}不实现的任何接口类型", FullName);
            }
        }
    }

}
