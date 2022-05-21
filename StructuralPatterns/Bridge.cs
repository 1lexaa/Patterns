using System;
using System.ComponentModel.Design;

namespace DesignPatterns.StructuralPatterns
{
    public class BridgeDemo
    {
       public void Show()
        {
            Figure f1 = new Figure();
            f1.AddComponent(new ShapeComponent("Circle"));
            f1.AddComponent(new StrokeComponent("Tomato", 3));
            f1.AddComponent(new FillComponent("Salmon", "RadialGradient"));
            f1.AddComponent(new ShadowComponent(3, 3, 80));
            f1.Render();

            Figure f2 = new Figure()
            .AddComponent(new ShapeComponent("Toilet Paper"))
            .AddComponent(new FillComponent("Gold", "Solid"));
            f2.Render();
        }
    }

    interface IFigureComponent
    {
        void Render();  // метод своего отображения (рисования)
    }

    class Figure
    {
        private List<IFigureComponent> components;

        public Figure()
        {
            components = new List<IFigureComponent>();
        }

        public Figure AddComponent(IFigureComponent component)
        {
            components.Add(component);
            return this;
        }

        public void Render()
        {
            if(components.Count == 0)
            {
                Console.WriteLine("👻"); // empty figure - no components
            }
            else
            {
                foreach(IFigureComponent component in components)
                {
                    component.Render();
                }
                Console.WriteLine();
            }
            
        }
    }

    class ShapeComponent : IFigureComponent
    {
        private readonly String Shape;
        public ShapeComponent(String Shape)
        {
            this.Shape = Shape;
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
            Console.Write($"{Color} border {Width}px width ");
        }
    }

    class FillComponent :IFigureComponent
    {
        private readonly String Color;
        private readonly String Style;

        public FillComponent(String color, String style)
        {
            this.Color = color;
            this.Style = style;
        }
        public void Render()
        {
            Console.Write($"{Style} fill with {Color} color ");
        }

    }

    class ShadowComponent : IFigureComponent
    {
        private readonly int OffsetX;
        private readonly int OffsetY;
        private readonly int Blur;

        public ShadowComponent(int X, int Y, int Blur)
        {
            this.OffsetX = X;
            this.OffsetY = Y;
            this.Blur = Blur;
        }
        public void Render()
        {
            Console.Write($" and shadow with [{OffsetX},{OffsetY}] pos and {Blur}% blur");
        }

    }
}

/* Мост(Bridge)
Структурный шаблон, заменяющий наследование/реализацию на агрегацию
а) Без паттерна
 Есть фигуры: базовый класс Figure, наследники Square:Figure, Circle:Figure
 Возникает необходимость рисовать фигуры с контуром StrokeSquare, StrokeCircle
 Фигуры с заполнением FillSquare, FillCircle
 Фигуры с контуром и заполнением FillStrokeSquare...

б) Паттерн
 Создает Фигуру как контейнер, а в ней - коллекцию компонент
 Figure
 {
    Components [FillComponent, StrokeComponent, ShapeComponent...]
    

 }
 */
