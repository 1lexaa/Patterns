using System;
namespace DesignPatterns.StructuralPatterns
{
    public class Decorator
    {
        public void Show()
        {
            IComponent product;

            product = new Coffee();
            // product = new CoffeeDecorator(null!);
            product = new WaterDecorator(product);
            product = new SugarDecorator(product);
            product = new LiquorDecorator(product);
            product = new SyropDecorator(product);

            PrintComponent(product);


            IComp product1;

            product1 = new Coctail();
            product1 = new MilkDecor(product1);
            product1 = new ChocoDecor(product1);
            product1 = new AlcoDecor(product1);
            product1 = new IceCreamDecor(product1);
            product1 = new SyropCDecor(product1);

            PrintComp(product1);


            ICompM  product2;

            product2 = new Macbook();
            product2 = new MemoryDecor(product2);
            product2 = new StorageDecor(product2);
            product2 = new FinalCutDecor(product2);
            product2 = new LogicProDecor(product2);

            PrintCompM(product2);

        }

        private void PrintComponent(IComponent component)
        {
            Console.WriteLine(component.GetDescription());
            Console.WriteLine(component.GetPrice());
        }

         private void PrintComp(IComp comp)
        {
            Console.WriteLine(comp.GetDescription());
            Console.WriteLine(comp.GetPrice());
        }

        private void PrintCompM(ICompM compM)
        {
            Console.WriteLine(compM.GetDescription());
            Console.WriteLine(compM.GetPrice());
        }
    }

#region 1st Decorator
    interface IComponent
    {
        float GetPrice();
        String GetDescription(); // Название - кофе/сливки/сахар
    }



    class Coffee : IComponent
    {
        private float price;
        private String description;
        public Coffee()
        {
            description = "Coffee";
            price = 15;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Water : IComponent
    {
        private float price;
        private String description;
        public Water()
        {
            description = "Water";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Sugar : IComponent
    {
        private float price;
        private String description;
        public Sugar()
        {
            description = "Sugar";
            price = 1;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }

    class Liquor : IComponent
    {
        private float price;
        private String description;
        public Liquor()
        {
            description = "Liquor";
            price = 10;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }

    class Syrop : IComponent
    {
        private float price;
        private String description;
        public Syrop()
        {
            description = "Syrop";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }



    abstract class IDecorator : IComponent
    {
        protected float price;
        protected String description;
        protected IComponent wrappee;
        public IDecorator(IComponent wrappee)
        {
            this.wrappee = wrappee;
        }

        public String GetDescription()
        {
            String description = String.Empty;
            if (wrappee != null) description += wrappee.GetDescription() + " + ";
            description += this.description;
            return description;
        }

        public float GetPrice()
        {
            float price = this.price;
            if (wrappee != null) price += wrappee.GetPrice();
            return price;
        }
    }

    class CoffeeDecorator : IDecorator
    {
        public CoffeeDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Coffee();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class WaterDecorator : IDecorator
    {
        public WaterDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Water();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class SugarDecorator : IDecorator
    {
        public SugarDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Sugar();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class LiquorDecorator : IDecorator
    {
        public LiquorDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Liquor();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class SyropDecorator : IDecorator
    {
        public SyropDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Syrop();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }     
#endregion



#region 2nd Decorator 
interface IComp
{
 float GetPrice();
        String GetDescription();
}


class Coctail : IComp
{
     private float price;
        private String description;
        public Coctail()
        {
            description = "Coctail";
            price = 20;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
}


class Milk : IComp
{
    private float price;
    private String description;

    public Milk()
    {
        description = "Milk";
        price = 1;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;   
}

class SyropC : IComp
{
private float price;
private String description;
public SyropC()
{
    description = "Syrop";
    price = 2;
}
public string GetDescription() => description;
public float GetPrice() => price;
}



class Choco : IComp
{
    private float price;
    private String description;
    public Choco()
    {
        description = "Chocolate";
        price = 3;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}

class IceCream : IComp
{
    private float price;
    private String description;

    public IceCream()
    {
        description = "Ice-Cream";
        price = 2;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}


class Alco : IComp
{
    private float price;
    private String description;

    public Alco()
    {
        description = "Alcohol";
        price = 5;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;

}



abstract class IDecor : IComp
    {
        protected float price;
        protected String description;
        protected IComp wrappee;
    
    public IDecor(IComp wrappee)
    {
        this.wrappee = wrappee;
    }

        public String GetDescription()
        {
            String description = String.Empty;
            if (wrappee != null) description += wrappee.GetDescription() + " + ";
            description += this.description;
            return description;
        }

        public float GetPrice()
        {
            float price = this.price;
            if (wrappee != null) price += wrappee.GetPrice();
            return price;
        }
    }



    #region Decor
class CoctailDecor : IDecor
{
    public CoctailDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}


class MilkDecor : IDecor
{
    public MilkDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new Milk();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}


class ChocoDecor : IDecor
{
    public ChocoDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new Choco();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}


class SyropCDecor : IDecor
{
    public SyropCDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new SyropC();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}


class IceCreamDecor : IDecor
{
    public IceCreamDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new IceCream();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}



class AlcoDecor : IDecor
{
    public AlcoDecor(IComp wrapee) : base(wrapee)
    {
        IComp component = new Alco();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}

#endregion



#endregion



#region 3nd Decorator 



interface ICompM
{
    float GetPrice();
        String GetDescription();
}


class Macbook : ICompM
{
 private float price;
    private String description;

    public Macbook()
    {
        description = "Macbook";
        price = 999;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}


class Memory : ICompM
{
    private float price;
    private String description;

    public Memory()
    {
        description = "Memory";
        price = 200;

    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}

class Storage : ICompM
{
    private float price;
    private String description;
    public Storage()
    {
        description = "Storage";
        price = 200;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}

class FinalCut : ICompM
{
    private float price;
    private String description;
    
    public FinalCut()
    {
        description = "FinatCut app";
        price = 299;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}

class LogicPro : ICompM
{
    private float price;
    private String description;
    
    public LogicPro()
    {
        description = "LogicPro app";
        price = 199;
    }
    public string GetDescription() => description;
    public float GetPrice() => price;
}

abstract class IDec : ICompM
    {
        protected float price;
        protected String description;
        protected ICompM wrappee;
    
    public IDec(ICompM wrappee)
    {
        this.wrappee = wrappee;
    }

        public String GetDescription()
        {
            String description = String.Empty;
            if (wrappee != null) description += wrappee.GetDescription() + " + ";
            description += this.description;
            return description;
        }

        public float GetPrice()
        {
            float price = this.price;
            if (wrappee != null) price += wrappee.GetPrice();
            return price;
        }
    }

class MacbookDecor : IDec
{
    public MacbookDecor(ICompM wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}

class MemoryDecor : IDec
{
    public MemoryDecor(ICompM wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}

class StorageDecor : IDec
{
    public StorageDecor(ICompM wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}

class FinalCutDecor : IDec
{
    public FinalCutDecor(ICompM wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}

class LogicProDecor : IDec
{
    public LogicProDecor(ICompM wrapee) : base(wrapee)
    {
        IComp component = new Coctail();
        description = component.GetDescription();
        price = component.GetPrice();
    }
}
#endregion
}

/*
Декоратор - структурный паттерн
Пример: кофе
У нас есть кофейня и посетитель может заказать кофе
К кофе можно добавить:
 - молоко
 - сахар
 - сливки
 - сироп
 - корица
Особенность: открыты для расширения, т.е. меню может быть дополнено:
 - шоколад
 - мороженное
Альтернатива: паттерн строитель - похож, но плохо расширяется
Альтернатива: агрегация - кофе + массив добавок --
               особая роль отводится контейнеру (кофе), это усложняет
               смену контейнера
Декоратор:
Первый элемент заказа берется за основу (кофе/молоко/вода)
Остальные добавляются, "расширяя" основной,
    создавая для него "оболочку"-декорацию
1. Кофе
2. +Сахар сахар(кофе)
3. +сливки сливки(сахар(кофе))
4. +что-то что-то(сливки(сахар(кофе)))
 */