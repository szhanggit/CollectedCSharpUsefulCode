using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1
{
    internal class ClassA
    {
        String _name;

        internal ClassA() { }

        internal String MethodA(String s)
        {
            _name = s; return _name;
        }

        public void MethodB(int i, String j)
        {
            Console.WriteLine("{0}, {1}", i, j);
        }

        public override string ToString()
        {
            return "asdf";
        }

        public static String Method(String s)
        {
            String output = "The return result of Method in ClassA is: " + s;
            return output;
        }
    }

    class Program
    {
        static void DisAllAm()
        { 
            foreach(System.Reflection.Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
            
            }
        }

        static void Main(string[] args)
        {
            //System.Reflection.Assembly am = System.Reflection.Assembly.Load("ClassRef");
            //System.Reflection.Assembly am = System.Reflection.Assembly.LoadFrom(@"D:\web\NET\ClassRef.exe");
            //Type tp = am.GetType("ClassName", false, false);
            ClassA a = new ClassA(); String test = ClassA.Method("Steven Zhang");
            Type tp = Type.GetType("ClassA", true, false);//Throw on error; Ignore case
            
            //tp.FullName; tp.IsGenericType; tp.IsInterface; tp.IsClass; tp.IsCOMObject
            
            /*Start: Method Info*/
            System.Reflection.MethodInfo[] ma = tp.GetMethods();

            foreach(System.Reflection.MethodInfo s in ma)
            {
                //s.Name; s.DeclaringType; s.IsConstructor; s.IsPublic; s.IsAssembly; s.IsFamily
                foreach(System.Reflection.ParameterInfo psm in s.GetParameters())
                {
                    //pms.Name; pms.ParameterType; pms.Position;
                }
            }
            /*End: Method Info*/

            /*Start: Member Info*/
            System.Reflection.MemberInfo[] mi = tp.GetMethods();
            foreach (System.Reflection.MemberInfo m in mi)
            { 
            
            }
            /*End: Member Info*/

            /*Start: Interface Info*/
            Type[] Itp = tp.GetInterfaces();
            foreach(Type t in Itp)
            {
                
            }
            /*End: Interface Info*/

            System.Reflection.Assembly am = System.Reflection.Assembly.Load("ClassA");
            Type ClassATp = am.GetType("ClassA", false, false);
            String[] MethodList = new String[1] { "asdf" };
            String txt = (String)ClassATp.InvokeMember("Method", System.Reflection.BindingFlags.InvokeMethod,
                null, null, MethodList);
            Console.WriteLine(txt);
            Console.ReadLine();
        }
    }
}
