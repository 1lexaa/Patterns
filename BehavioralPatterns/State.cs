using System;

namespace DesignPatterns.BehavioralPatterns
{
    public class StateDemo
    {
        public void Show()
        {
            new Game().Update();
        }
    }


    class Game
    {
        private IGameState? state;                
         // Альтернатива:
        public IGameState State                // IGameState GetState() {
        {                  // return state;
            get => state;                  // }
            set{                   // void SetState(IGameState newState) {
                state = value;                 // state = newState;
                Update();               // Update();
                // Изменение состояние вызывает "перерисовку " }

            }
        }

        public Game()
        {
            state = new MenuState(this);
        }
        public void Update()
        {
            state.Update();
        }

private List<IGameState> states = new List<IGameState>();
    public void Play() 
    {
        foreach(var state in states)
        {
            if(state is PlayState)
            {
                State = state;
                return;
            }
        }
        var newState = new PlayState(this);
        states.Add(newState);
        State = newState;
    }
    public void Pause() 
    {
        foreach(var state in states)
        {
            if(state is PauseState)
            {
                State = state;
                return;
            }
        }
        var newState = new PauseState(this);
        states.Add(newState);
        State = newState;
    }

    public void Menu()
    {
        foreach(var state in states)
        {
            if(state is MenuState)
            {
                State = state;
                return;
            }
        }
        var newState = new MenuState(this);
        states.Add(newState);
        State = newState;
    }

    }


    interface IGameState
    {
        void Update();
    }


    class MenuState : IGameState
    {
        private readonly Game game;
        public MenuState(Game game)
        {
            this.game = game;
        }
        public void Update()
        {
            Console.WriteLine("Menu : ");
            Console.WriteLine("Any key: Play");
            Console.ReadKey();
            //game.State = new PlayState(game);
            game.Play();
        }
    }


    class PlayState : IGameState
    {
        private readonly Game game;
        public PlayState(Game game)
        {
            this.game = game;
        }
        public void Update()
        {
            ConsoleKeyInfo key;

            do{
                Console.WriteLine("Playing.....");
                key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.P)
                {
                    //game.State = new PauseState(game);
                    game.Pause();
                    return;
                }
            } while(key.Key != ConsoleKey.Escape);
        }
    }

    class PauseState : IGameState
    {
        private readonly Game game;
        public PauseState(Game game)
        {
            this.game = game;
        }

        public void Update()
        {
            Console.WriteLine("Pause.....");
            Console.WriteLine("Press a key");
            Console.ReadKey(true);
           // game.State = new PlayState(game);
           game.Play();
        }
    }
}

/* Состояние(State)
Шаблон "Состояние" используется для реализации приложений ,
имеющих разные "режимы" работы - состояния.

Например, игра          // приложение подразумевает использование управления
- Состояние "Меню"      // кнопок, манипуляторов. В режиме меню это управление
- Состояние "Игра"      // выбирает пункты , а в "игре" - управляет игрой 

Без паттерна - 
switch(GameMode) {              // Без Шаблона -- проблема дублирования кода
    case Mode.Menu:.....        // ? Получение сигнала управления (KeyUp) - общее
    case Mode.Play:.....        // ? Реакция на него различная
    case Mode.Loading:....      // а в этом состоянии управление не требуется 
}
С паттерном - создаются  классы , реализующие поведения в разных состояниях один из них является "текущим"

class Game {
    GameState state;
    ... state = new MenuState(); ...
    }
    class MenuState, PlayState, LoadingState : GameState
    LoadingState { onFinish() {Game.state = new PlayState() | Game.Play() } }
    PlayState { OnEscape() { Game.state = new MenuState() | Game.Menu() } }
}
 
 а) подход Game.state = new MenuState()
 + хорошая читаемость
 - сложно перевести на повторное использование объектов (Singleton), т.к. в конструктор
 передается ссылка на контекст . Можго отделить SetContext(game), но тогда ндо вызывать методы "дублетом":
 MenuState.SetContext(game);
 Game.State = MenuState.GetInstance();
 Можно передать ссылку в GetInstance(game), но придется принимать решения 
 что делать если в новом вызове game поменяется

б) подход Game.Menu()
+ переносит логику создания / повторного использования объектов состояний 
в контекст -- не объекты помнят о своем предыдущем 
*/