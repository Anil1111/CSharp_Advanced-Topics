
namespace CSharp_Advanced
{
    using System;

    class Program
    {
        static void Main()
        {
            var delegateTypes = new Delegates.DelegateTypes();

            delegateTypes.SingleDelegateExample();
            delegateTypes.MulticastDelegateExample();
            delegateTypes.GenericDelegates();
            
        }
    }
}
