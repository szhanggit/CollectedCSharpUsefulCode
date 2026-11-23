using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableEx
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                https://www.dotnetperls.com/dictionaryentry
                DictionaryEntry is used with Hashtable.The Hashtable collection provides a way to access objects based on a key.
                But it does not implement advanced logic for iterating over the contents.We use DictionaryEntry in a foreach-loop.
             */

            // Create hashtable with some keys and values.
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "one");
            hashtable.Add(2, "two");
            hashtable.Add(3, "three");

            // Enumerate the hashtable.
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }
        }
    }
}
