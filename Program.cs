﻿using System;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Desing patterns");
            Console.WriteLine("1  Creational: ");
            Console.WriteLine(" 11 Singleton: ");
            Console.WriteLine(" 12 Simple Factory: ");
            Console.WriteLine(" 13 Factory Method: ");
            Console.WriteLine(" 14 Abstract Factory: ");
            Console.WriteLine("2  Behavioral: ");
            Console.WriteLine(" 21 Strategy: ");
            Console.WriteLine("3  Structural: ");
            Console.WriteLine(" 31 Decorator: ");
            String? userChoice = Console.ReadLine();
            switch(userChoice)
            {
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
                case "31":
                    #region Decorator
                    new Decorator().Show();
                    #endregion
                    break;
                default:
                    Console.WriteLine("Invalid Choice 💩");
                    break;

            }
            

            
        }
    }
}