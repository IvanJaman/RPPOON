//dz5, zad2, obrazac je dekorater i pripada skupini strukturnih obrazaca 

public interface ICoffee {
    double GetCost();
    string GetDescription();
}

public class Espresso: ICoffee {

    public double GetCost() {
        return 1.99;
    }

    public string GetDescription() {
        return "Espresso";
    }
}

public abstract class CoffeeDecorator: ICoffee {
    protected ICoffee Coffee;

    public CoffeeDecorator(ICoffee coffee) {
        Coffee = coffee;
    }
    public virtual double GetCost() {
        return Coffee.GetCost();
    }

    public virtual string GetDescription() {
        return Coffee.GetDescription();
    }
}

public class Milk: CoffeeDecorator {

    public Milk(ICoffee coffee):base(coffee){}
    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }
    public override string GetDescription()
    {
        return base.GetDescription() + " with Milk";
    }
}
public static class ClientCode
{
    public static void Run()
    {
        ICoffee espresso = new Espresso();
        Console.WriteLine(espresso.GetDescription());
        Console.WriteLine(espresso.GetCost());

        ICoffee latte = new Milk(new Espresso());
        Console.WriteLine(latte.GetDescription());
        Console.WriteLine(latte.GetCost());
    }
}

class Program
{
    public static void Main(string[] args)
    {
        ClientCode.Run();
    }
}