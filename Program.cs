using System;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns
{
    class Program
    {

        
        static void Main(string[] args)
        {
            #region CW
            
            Console.Clear();
            Console.WriteLine("Desing patterns");
            Console.WriteLine("1  Creational: ");
            Console.WriteLine(" 11 Singleton: ");
            Console.WriteLine(" 12 Simple Factory: ");
            Console.WriteLine(" 13 Factory Method: ");
            Console.WriteLine(" 14 Abstract Factory: ");
            Console.WriteLine(" 15 Builder: ");
            Console.WriteLine("2  Behavioral: ");
            Console.WriteLine(" 21 Strategy: ");
            Console.WriteLine(" 22 Observer: ");
            Console.WriteLine(" 23 State: ");
            Console.WriteLine(" 24 Chain: ");
            Console.WriteLine("3  Structural: ");
            Console.WriteLine(" 31 Decorator: ");
            Console.WriteLine(" 32 Bridge: ");
            Console.WriteLine(" 33 Proxy: ");
             Console.WriteLine(" 34 Composite: ");
            String? userChoice = Console.ReadLine();
            Console.Clear();

            #endregion 
            switch(userChoice)
            {
               #region CreationalPatterns
                case "11":
                    #region Singleton
                    // Приватный конструктор не дает создать объект через new 
                    // var obj = new CreationalPatterns.Singleton();

                    // Xарактерным признаком паттерная "Одиночка" является запрос GetInstance
                    var obj = CreationalPatterns.Singleton.GetInstance();
                    Console.WriteLine(obj.Moment);
                    var obj2 = CreationalPatterns.Singleton.GetInstance();
                    Console.WriteLine(obj == obj2 ? "Equals" : "Not equals");
                    #endregion
                    break;
                case "12":
                    #region Factory
                    new CreationalPatterns.FactoryDemo().Show();
                    #endregion
                    break;

                    case "13":
                    #region FactoryMethod
                    new CreationalPatterns.FactoryMethod().Show();
                    #endregion
                    break;

                    case "14":
                    #region  AbstractFactory
                     new CreationalPatterns.AbstractFactory().Show();
                    #endregion
                    break;

                    case "15":
                    #region Builder
                    new CreationalPatterns.BuilderDemo().Show();
                    #endregion 
                    break;

                    #endregion

#region BehavioralPatterns
                case "21":
                    #region Strategy
                    var StrategyDemo = new BehavioralPatterns.Strategy();
                    // Автоматическая работа
                    StrategyDemo.Show();
                    // Задание: Вывести по всем стратегиям
                    // Название - значение
                    StrategyDemo.ShowDetails();
                    
                    #endregion
                    break;

                    case "22":
                    #region observer
                new BehavioralPatterns.ObserverDemo().Show();
                #endregion
                    break;

                    case "23":
                    #region State
                    new BehavioralPatterns.StateDemo().Show();
                    #endregion
                    break;

                    case "24":
                    #region Chain
                    new BehavioralPatterns.ChainDemo().Show();
                    #endregion
                    break;
                    #endregion
                

                    #region StructuralPatterns
                case "31":
                    #region Decorator
                    new Decorator().Show();
                    #endregion
                    break;

                    case "32":
                    #region Bridge
                    new BridgeDemo().Show();
                    #endregion
                    break;
                    
                    case "33":
                    #region Proxy
                    new ProxyDemo().Show();
                    #endregion
                    break;

                    case "34":
                    #region Composite
                        new CompositeDemo().Show();
                    #endregion
                    break;

                    #endregion
                default:
                    Console.WriteLine("Invalid Choice 💩");
                    break;

            }
            

            
        }
    }
}