using System;
using System.Text.RegularExpressions;

namespace DesignPatterns.BehavioralPatterns
{
    internal class ObserverDemo
    {
        public void Show()
        {
            TextWriter writer = new TextWriter();
            SymbolCounter symbolCounter = new SymbolCounter();
            writer.Subscribe(symbolCounter);

            WordSearcher wordSearcher = new WordSearcher();

            Console.WriteLine("Type smth");
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                writer.State = writer.State  +  k.KeyChar;

            }while(k.Key != ConsoleKey.Enter);
        }
    }

    interface Observer
    {
        void Update(object state);
    }


    abstract class Subject
    {
        private List<Observer> Observers;
        private String State;
        

        private object state;

public Subject()
{
    Observers = new List<Observer>();
}

        public void Subscribe(Observer observer)
        {
            if(!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }


        public void Unsubscribe(Observer observer)
        {
            if(Observers.Contains(observer))
            {
                Observers.Remove(observer);
            }
        }

        virtual public void Notify(object arg = null)
        {
           if(arg is null) arg = this.state;

           foreach(Observer observer in Observers)
           {
               observer.Update(arg);
           }
        }
    }


    class TextWriter : Subject
    {
        private String _state;

        public String State
        {
        get => _state;
            set
            {
                _state = value;
                base.Notify(_state);
            }
        }
    

        public TextWriter() : base()
        {
            State = String.Empty;
        }

        
    }


       class SymbolCounter : Observer 
       {
           public void Update(object state)
           {
               if(state is String str)
               {
                   Console.WriteLine($"cnt: {str.Length}");
               }
               else throw new ArgumentException("String expected");
           }
       }



    class WordSearcher : Observer
    {
        public void Update(object state)
        {
            if(state is String str)
            {
                //find "hi" word and count its appearencies
                Console.WriteLine($"'hi' cnt: {Regex.Matches(str,"hi").Count}");
            }
            else throw new ArgumentException("String expected");
        }
    }

    
}

/* Наблюдатель ( Observer )
Шаблон , реализующующий "поток" событий от центра (Subject) к
подписчикам (Subscribers). Противопоставляется клиент-серверной
схеме , в которой клиенты проявляют активность ,а серверы лишь
отвечаюь, не имея возможности инициировать обмен данными.

Наиболее популярный пример - события и обработчики событий .

Ключевые моменты :
- Две группы участников - Источники событий (Subject) и Наблюдатели
- Каждый источник содержит коллекцию наблюдателей 
- При возникновении события источник перебирая коллекцию
уведомляет наблюдателей путем вызова их методов
- Традиционно , источник имеет состояние , которое передается как аргумент
при вызове методов наблюдателей

Пример : 
Набор текста ( как источник , состояние - текст) и наблюдатели
- считающий кол-во символов
- проводящий поиск ключевых слов 
*/