using static DesignPatterns.FactoryDesignPattern;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System;

namespace DesignPatterns
{
    public class FactoryDesignPattern
    {
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
        public class PaypalPayment : IPayment
        {
            public void DoThePayment() => Console.WriteLine("Paypal Payment");
        }
        public class PaymentFactory
        {
            //This is not following open close principle because here if we have to add a new payment method we have to modify this class
            //To solve this problem there can be 2 approach
            //1. Use abstract factory design pattern
            //2. One same factory design pattern method but use a better version of it and use dictionary to create the instances.

            //public IPayment ProcessPayment(string paymentType)
            //{
            //    if(paymentType =="Credit") return new CreditCardPayment();
            //    else return new DebitCardPayment();
            //} 

            #region solution2
            //The reason for using Dictionary is that we fully adhere to the open-closed principle

            //To fully adhere to the open-closed principle, we can improve our factory class to avoid modifications when adding new payment methods.
            //The previous implementation was functional but not fully compliant with the open-closed principle.
            //By using a dictionary to manage payment method instances, we can make our factory class more robust and maintainable.

            //Instead of directly returning instances of payment methods, we store these instances in a dictionary with key-value pairs 
            //where the key is a string and the value is a function returning a new instance of the payment method class.
            //The reason of using function that returns a new instance instead of directly storing the instance is that we get fresh instance every time
            //This ensures that each time we retrieve a payment method, we get a fresh instance, avoiding issues with shared instances.

            //Implementation Steps:
            //   Create a Dictionary: The dictionary will store string keys and functions that return instances of payment method classes.
            //   Process Payment Method: The method to process payments will check if the payment type is present in the dictionary and then return a new instance by executing the stored function.
            //   Register Payment Method: A method to register new payment methods by passing the string key and the function returning the instance.This allows new payment methods to be added without modifying the factory class.
            #endregion


            private readonly Dictionary<string, Func<IPayment>> _processPayment = [];
            public PaymentFactory()
            {
                _processPayment.Add("Credit", () => new CreditCardPayment());
                _processPayment.Add("Debit", () => new DebitCardPayment());
            }
            public void RegisterPayment(string paymentType, Func<IPayment> instance)
            {
                _processPayment.Add(paymentType, instance);
            }
            public IPayment ProcessPayment(string paymentType)
            {
                if (_processPayment.TryGetValue(paymentType, out var instance))
                {
                    return instance();
                }
                throw new Exception("Invalid Payment Type");
            }
        }

    }
}
