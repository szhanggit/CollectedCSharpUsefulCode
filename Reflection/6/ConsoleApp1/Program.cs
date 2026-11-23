using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Type tp = Type.GetType("ConsoleApp1.ClassA", false ,false);            
            MethodInfo[] ma = tp.GetMethods();      //Only get public methods.

            foreach (MethodInfo s in ma)
            {
                Console.WriteLine("\n\t【{0}方法】", s.Name);
                Console.Write("方法所属类名称：【{0}】", s.DeclaringType);
                Console.WriteLine("\t方法是否为构造函数：【{0}】", s.IsConstructor);
                Console.Write("方法是否为public成员：【{0}】", s.IsPublic);
                Console.WriteLine("\t方法是否为internal成员：【{0}】", s.IsAssembly);
                Console.Write("方法是否为protected成员：【{0}】", s.IsFamily);
                Console.WriteLine("\t方法是否为private成员：【{0}】",s.IsPrivate);
                Console.Write("方法是否为泛型方法：【{0}】",s.IsGenericMethod);
                Console.WriteLine("\t方法是否为static方法：【{0}】",s.IsStatic);
                Console.Write("方法是否为virtual方法：【{0}】",s.IsVirtual);
                Console.WriteLine("\t方法返回类型为：【{0}】", s.ReturnType);

                foreach (ParameterInfo pms in s.GetParameters())
                {
                    Console.WriteLine("\n\t-------【{0}参数】---------", pms.Name);
                    Console.Write("参数类型：【{0}】", pms.ParameterType);
                    Console.WriteLine("\t参数位置：【{0}】",pms.Position);
                }
            }

            /*
                public:  对任何类和成员都公开, 无限制访问;
                protected: 仅仅对该类以及该类的派生类公开;     s.IsFamily
                private: 仅仅对该类公开;
                internal: 只能值包含该类的程序集中访问该类(只是单独的项目,而不是整个解决方案);      s.IsAssembly
                protected internal: 只能在本类,派生类或者包含该类的程序集中访问.

                The default accessibility of top-level types is internal.
                The default accessibility of class and struct members is private.
                The only possible accessibility of interface and enum members is public.

             */

            ClassA a = new ClassA();
            Type tp1 = a.GetType();
            Type tp2 = typeof(ClassA);
            Console.WriteLine("The hash code is: {0}", a.GetHashCode().ToString());
            Console.ReadLine();
        }
    }

    class ClassA
    {
        string _name;

        //[System.Security.Permissions.ReflectionPermission]
        internal string MethodA(string s)
        {
            _name = s;
            return _name;
        }

        public void MethodB(int i, string j)
        {
            Console.WriteLine("MethodA方法已调用，所传递参数为{0}和{1}", i, j);
        }

        public override string ToString()
        {
            return "ClassA类的对象";
        }
    }
}
