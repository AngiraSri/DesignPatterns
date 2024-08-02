//The Observer Design Pattern is a behavioral design pattern that defines a one-to-many dependency
//between objects so that when one object (the subject) changes state, all its dependents (observers) are notified
//and updated automatically. It is useful for implementing distributed event-handling systems.

//Key Concepts:
//ISubject: The object that holds the state and can be observed.
//It maintains a list of observers and provides methods to attach, detach and notify all of them.

//IObserver: The objects that need to be notified of changes in the subject's state.
//They implement an update method that is called when the subject changes.

//ConcreteSubject: The implementation of the subject.
//It stores state of subject
//Attach the Observer
//Detach the Observer
//and sends notifications to all the observers when the state of subject changes.

//ConcreteObserver: The implementation of the observer.
//It performs some action based on the notifications received from the subject.

//Structure:
//Subject: Interface or abstract class with methods to attach, detach, and notify observers.
//Observer: Interface or abstract class with an update method.
//ConcreteSubject: Implementation of the subject.
//ConcreteObserver: Implementation of the observer.

namespace DesignPatterns
{
    public class ObserverDesignPattern
    {
        public interface IStock
        {
            public decimal StockPrice { get; set; }
            public string? StockName { get; set; }
            void Attach(IInvestor investor);
            void Detach(IInvestor investor);
            void Notify();

        }
        public class Stock : IStock
        {
            private List<IInvestor> _investors = [];
            private decimal _stockPrice;
            public decimal StockPrice
            {
                get { return _stockPrice; }
                set 
                { 
                    _stockPrice = value;
                    Notify();
                }

            }
            public string? StockName { get; set; }

            public void Attach(IInvestor investor) => _investors.Add(investor);
            public void Detach(IInvestor investor) => _investors.Remove(investor);
            public void Notify() => _investors.ForEach(x => x.Update(this));
        }
        public interface IInvestor
        {
            public void Update(IStock stock);
        }

        public class Investor : IInvestor
        {
            public string? InvestorName { get; set; }
            public Investor(string name)
            {
                InvestorName = name;
            }
            public void Update(IStock stock)
            {
                Console.WriteLine($"Hey {InvestorName}!, {stock.StockName} Stock price changed to {stock.StockPrice}");
            }
        }

        public IStock GetStock(decimal stockPrice)
        {
            return new Stock
            {
                StockName = "CAMS",
                StockPrice = stockPrice
            };
        }
    }
}
