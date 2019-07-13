
namespace AdvancedTopics
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    class Program
    {
        static void Main()
        {
            var instance1 = new Person("FirstName ", new DateTime(2010, 12, 1));
            var instance2 = new Person("LastName", new DateTime(2012, 1, 2));
            Console.WriteLine((instance1 + instance2).Name);

            instance1.PropertyChanged += (sender, args) =>
            {
                Console.WriteLine($"\nThe value of Property: {args.PropertyName} \nChanged to: {instance1.Name}");
            };
            instance1.Name = "New Name";
        }
    }


    public static class NullSafeExtension
    {
        public static void SafeInvoke<TSender, TValue>(this PropertyChangedEventHandler handler,
            TSender sender, Expression<Func<TSender, TValue>> selector)
        {
            var expression = (MemberExpression)selector.Body;
            
            if (handler != null)
                handler(sender, new PropertyChangedEventArgs(expression.Member.Name));
        }
    }

    public class Person : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged.SafeInvoke(this, x => x.Name);
            }
        }

        // readonly Property
        public DateTime BirthDay { get; private set; }

        /* Expressions on Properties */
        public TimeSpan Age => DateTime.Now - BirthDay;

        // public TimeSpan Age
        // {
        //     get { return DateTime.Now - BirthDay; }
        // }

        public Person(string name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }

        /* Expressions on Methods */
        public static Person operator +(Person x, Person y) =>
            new Person(x.Name + y.Name, DateTime.Now);

        // public static Person operator +(Person x, Person y)
        // {
        //     return new Person(x.Name + y.Name, DateTime.Now);
        // }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
