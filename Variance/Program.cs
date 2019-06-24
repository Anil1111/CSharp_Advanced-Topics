
namespace Variance
{
    // Covariance and Contravariance only work with delegates and interfaces 

    public interface ICovariant<out T> { }
    public interface IContravariant<in T> { }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Enables you to use a more derived type than originally specified.
            ICovariant<string> co = null;
            ICovariant<object> moreGeneralType = co;


            // Enables you to use a more generic (less derived) type than originally specified.
            IContravariant<object> contra = null;
            IContravariant<string> moreGenericType = contra;


            // ICovariant can be declared with the base or every class that base inherit from
            CovariantDerivedClass coDerived = new CovariantDerivedClass();
            ICovariant<CovariantBaseClass> coBase = coDerived;


            // ICovariant can be declared with the base or every class that base inherit from
            ContravariantBaseClass contraBase = new ContravariantBaseClass();
            IContravariant<ContravariantDerivedClass> contraDerived = contraBase;

            // Work in both ways
            SomeMethod(contraBase);
            SomeMethod(contraDerived);
        }
        
        public static void SomeMethod(IContravariant<ContravariantDerivedClass> tmp)
        {
            //.....
        }

        // Get the default value of T
        public static T GetDefaultValue<T>(T value)
        {
            return default(T);
        }
    }

    //--------------------------------------------------------------------------------------------------//

    public class CovariantBaseClass : ICovariant<CovariantBaseClass>
    {
        public string Property { get; set; }

        public virtual string Method() =>
            throw new System.NotImplementedException();
        
    }
    
    public class CovariantDerivedClass : CovariantBaseClass
    {
        public override string Method()
        {
            throw new System.NotImplementedException();
        }
    }

    //--------------------------------------------------------------------------------------------------//

    public class ContravariantBaseClass : IContravariant<ContravariantBaseClass>
    {
        public string Property { get; set; }

        public virtual string Method() =>
            throw new System.NotImplementedException();
    }

    public class ContravariantDerivedClass : ContravariantBaseClass
    {
        public override string Method()
        {
            throw new System.NotImplementedException();
        }
    }
}

