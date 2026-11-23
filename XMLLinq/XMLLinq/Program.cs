using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Xml.Linq.XElement doc = System.Xml.Linq.XElement.Load(@"C:\Users\steven.zhang\Documents\Visual Studio 2012\Projects\Examples\C#\XMLLinq\XMLLinq\File\Authors.xml");
            var authorids = from authors in doc.Elements("author")
                            select authors.Attribute("id").Value;

            foreach(var id in authorids)
            {
                Console.WriteLine(id.ToString());
            }

            /*********************************************/

            System.Xml.Linq.XElement root = System.Xml.Linq.XElement.Load(@"C:\Users\steven.zhang\Documents\Visual Studio 2012\Projects\Examples\C#\XMLLinq\XMLLinq\File\class.xml");
            var Names = from n in root.Elements()
                        where (int)n.Attribute("Math") > 60
                        orderby (int)n.Attribute("Chinese") descending
                        select n;

            foreach (var m in Names)
            {
                Console.WriteLine(m.Name.ToString());
            }

            Console.ReadLine();
        }
    }
}
