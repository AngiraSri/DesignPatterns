using DesignPatterns;
using static DesignPatterns.FactoryDesignPattern;
using static DesignPatterns.ObserverDesignPattern;

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




ObserverDesignPattern observerDesignPattern = new ObserverDesignPattern();
var investor1 = new Investor("Angira");
var investor2 = new Investor("Riddhi");
var stock = observerDesignPattern.GetStock(10);
stock.Attach(investor1);
stock.Attach(investor2);
// Simulate stock price change
stock.StockPrice = 11;
stock.Detach(investor2);
// Another stock price change
stock.StockPrice = 12;

