using System;

namespace DesignPatterns.StructuralPatterns
{

    internal class BridgeDemo
    {
        public void Show()
    {
        Figure f1 = new Figure();
        f1.AddComponent(new ShapeComponent("Circle"));
        f1.AddComponent(new StrokeComponent("Tomato", 3));
        f1.AddComponent(new FillComponent("Salmon","RadialGradient"));
        f1.Render();

        Figure f2 = new Figure();
        f2.AddComponent(new ShapeComponent("Diamond"));
        f2.AddComponent(new FillComponent("Blue", "Solid"));
        f2.Render();
    }
    }


    interface IFigureComponent
    {
        void Render();
    
    }


    class Figure
    {
        private List<IFigureComponent> components;

    public Figure()
    {
        components = new List<IFigureComponent>();
    }
    public void AddComponent(IFigureComponent component)
    {
        components.Add(component);
    }

    public void Render()
    {
        if(components.Count == 0)
        {
            Console.WriteLine("👻"); // empty figure - no comp
        }
        else 
        {
            foreach(IFigureComponent component in components)
            {
                component.Render();
            }
        }
    }
    }


    class ShapeComponent : IFigureComponent
    {
        private readonly string Shape;

        public ShapeComponent(String shape)
        {
            Shape = shape;
        }
        public void Render()
        {
            Console.Write($" {Shape} ");
        }
    }

    class StrokeComponent : IFigureComponent
{
private readonly String Color;
private readonly int Width;
public StrokeComponent(String Color, int Width)
{
this.Color = Color;
this.Width = Width;
}
public void Render()
{
Console.Write($" {Color} border {Width}px width ");
}
}

    class FillComponent : IFigureComponent
    {
        private readonly String _color;
        private readonly String _style;

        public FillComponent(string color , string style)
        {
            _color = color;
            _style = style;
        }

        public void Render() => Console.WriteLine($"fill {_color} style {_style}");
    }


   



    
}


/* Мост (Bridge)
Структурный шаблон, заменяющий наследование/реализацию на агрегацию
а) без паттерна
Есть фигуры : базовый класс Figure, наследники Square:Figure,Circle: Figure
Возникает необходимость рисовать фигуры с контуром StrokeSquare, StrokeCircle 
Фигуры с заполнением : FillSquare, FillCircle
Фигуры с контуром и заполнением : FillStrokeSquare
Добавляем концепцию рисования штрихом : DashFillStrokeSquare

б) Паттерн
Создаем фигуру как контейнер , а в ней - коллекцию компонент
Figure {
    Commponents [FillComponent,StrokeComponent,ShapeComponent,.....]
    }
*/