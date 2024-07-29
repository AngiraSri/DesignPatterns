// See https://aka.ms/new-console-template for more information
using DesignPatterns;
using static DesignPatterns.FactoryDesignPattern;

Console.WriteLine("Hello, World!");

PaymentFactory paymentFactory = new();
paymentFactory.ProcessPayment("Credit").DoThePayment();
paymentFactory.ProcessPayment("Debit").DoThePayment();
paymentFactory.RegisterPayment("Paypal", () => new PaypalPayment());
paymentFactory.ProcessPayment("Paypal").DoThePayment();


if (Console.ReadLine() == "Credit")
{
    new CreditCardFactory().ProcessPayment().DoThePayment();
}
if (Console.ReadLine() == "Debit")
{
    new DebitCardFactory().ProcessPayment().DoThePayment();
}




