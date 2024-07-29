namespace DesignPatterns
{

    //    In the classic factory pattern, we often end up violating the Open-Closed Principle(OCP) because we modify the factory class to add new product types.To resolve this, we can use the Abstract Factory Pattern.
    
    //    In the Abstract Factory Pattern, instead of creating a single factory class that directly returns instances based on conditions,we define an abstract factory class with an abstract method for creating instances.
    //    Concrete factory classes inherit from this abstract factory and provide implementations for the abstract method, creating instances of specific product classes.
  
    //    This approach adheres to the OCP because adding a new product type(e.g., a new payment method) does not require modifying any existing classes.
    //    Instead, we simply add a new concrete factory(e.g., PayPalPaymentFactory) that inherits from the abstract factory and implements the method to create instances of the new product class (PayPalPayment).
    //    Thus, our Abstract Factory Pattern follows the OCP by allowing extension through new factories while keeping existing code unchanged.Depending on the condition,
    //    we can select the appropriate factory, which in turn creates the required product instance.

    public interface IPayment
    {
        void DoThePayment();
    }
    public class CreditCardPayment : IPayment
    {
        public void DoThePayment() => Console.WriteLine("Credit Card Payment");
    }
    public class DebitCardPayment : IPayment
    {
        public void DoThePayment() => Console.WriteLine("Debit Card Payment");
    }

    public abstract class AbstractPaymentFactory
    {
        public abstract IPayment ProcessPayment();
    }
    public class CreditCardFactory : AbstractPaymentFactory
    {
        public override IPayment ProcessPayment() => new CreditCardPayment();
    }
    public class DebitCardFactory : AbstractPaymentFactory
    {
        public override IPayment ProcessPayment() => new DebitCardPayment();
    }
}
