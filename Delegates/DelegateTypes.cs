
namespace Delegates
{
    using System.Collections.Generic;

    public class DelegateTypes
    {
        private delegate void SingleDelegate<T>(T[] arr);
        private delegate void MulticastDelegate<T>(T[] arr);

        private string[] arr = new string[] { "a", "b", "c", "d", "e", "f", "g" };

        // Single Cast Delegate examples
        public void SingleDelegateExample()
        {
            SingleDelegate<string> single = delegate (string[] vals)
            {
                System.Console.WriteLine(string.Join(" ", vals));
            };

            var @delegate = new SingleDelegate<string>(single);

            // OR
            // var @delegate = new SingleDelegate<string>(_ => System.Console.WriteLine(string.Join(" ", arr)));

            @delegate.Invoke(arr);
        }


        // Multi Cast Delegate examples
        public void MulticastDelegateExample()
        {
            var @delegate = new MulticastDelegate<string>(ReverseArr);
            @delegate += Print;

            @delegate.Invoke(arr);
        }


        // Generic Delegate examples
        public void GenericDelegates()
        {
            // Simple use of Action. Func and Predicate
            System.Action<string[]> action = ReverseArr;  
            System.Func<string[], IEnumerable<string>> func = x => ChangeToUpper(x);  
            System.Func<string, bool> predicate = x => x != "G";  
            

            action(arr);
            var upperArr = func(arr);
            foreach(var a in upperArr)
            {
                if (predicate(a))
                    System.Console.Write(a + " ");
            }
        }

        private void ReverseArr<T>(T[] array) => System.Array.Reverse(array);

        private void Print<T>(T[] array) => System.Console.WriteLine(string.Join(" ", array));

        private IEnumerable<string> ChangeToUpper(string[] source)
        {
            foreach (var n in source)
                 yield return n.ToUpper();
        }
    }
}

