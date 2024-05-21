//zad1, obrazac je promatrač, pripada skupini obrazaca ponašanja

using System.ComponentModel;

public interface IChannellable{
    public void Add(INotifiable notifiable);
    public void Remove(INotifiable notifiable);
    public void Notify(string message);
}

public interface INotifiable{
    public void PushNotification(string message);
}

public class User : INotifiable
{
    public void PushNotification(string message)
    {
        Console.WriteLine(message);
    }
}

public class Creator : IChannellable
{
    List<INotifiable> notifiables;
    bool HasErrorOccured {get; set;}
    public Creator(){
        notifiables = new List<INotifiable>();
    }
    public void Add(INotifiable notifiable){
        notifiables.Add(notifiable);
    }
    public void Remove(INotifiable notifiable){
        notifiables.Remove(notifiable);
    }
    public void Notify(string message){
        if(HasErrorOccured){
            foreach (INotifiable notifiable in notifiables){
                notifiable.PushNotification(message);
            }
        }
    }
}

public static class ClientCode1
{
    public static void Run()
    {
        IChannellable creator = new Creator();
        creator.Add(new User());
        creator.Notify("Notifikacija.");
    }
}


//zad2, obrazac je nemam pojma, pripada skupini obrazaca ponašanja jer te radimo sad lol

public class Activity{
    public int Price {get; set;}
    public string Name{get; set;}
    public Activity(string name){
        Name = name;
    }
}

public class VacationConfigurator
{
    public string Destination { get; private set; }
    private List<Activity> additionalActivities = new List<Activity>();

    public decimal CalculateTotal()
    {
        return additionalActivities.Sum(it => it.Price);
    }

    public void AddExtra(Activity activity)
    {
        additionalActivities.Add(activity);
    }

    public void Remove(Activity activity)
    {
        additionalActivities.Remove(activity);
    }

    public void LoadPrevious(VacationConfiguration configuration)
    {
        Destination = configuration.GetDestination();
        additionalActivities.Clear();
        additionalActivities.AddRange(configuration.GetAdditionalActivities());
    }

    public VacationConfiguration Store()
    {
        return new VacationConfiguration(Destination, additionalActivities);
    }
}

public class VacationConfiguration
{
    private string Destination;
    private List<Activity> AdditionalActivities;

    public VacationConfiguration(string destination, List<Activity> additionalActivities){
        Destination = destination;
        AdditionalActivities = additionalActivities;
    }
    
    public string GetDestination(){
        return Destination;
    }
    
    public List<Activity> GetAdditionalActivities(){
        return AdditionalActivities;
    }
}

public class ConfigurationManager
{
    private List<VacationConfiguration> configurations = new List<VacationConfiguration>();

    public void AddConfiguration(VacationConfiguration configuration)
    {
        configurations.Add(configuration);
    }

    public void DeleteConfiguration(VacationConfiguration configuration)
    {
        configurations.Remove(configuration);
    }

    public VacationConfiguration GetConfiguration(int index)
    {
        return configurations[index];
    }
}

//prepisano jer nemam pojma :)
public static class Program{
    public static void Main(){
        VacationConfigurator vacationConfigurator = new VacationConfigurator();
        VacationConfiguration vacationConfiguration = vacationConfigurator.Store();
        ConfigurationManager configurationManager = new ConfigurationManager();
        configurationManager.AddConfiguration(vacationConfiguration);
        vacationConfigurator.AddExtra(new Activity("Walking"));
        vacationConfigurator.LoadPrevious(configurationManager.GetConfiguration(0));
    }
}   



//zad3, obrazac je lanac odgovornosti, a pripada obrascima ponašanja

public abstract class Handler
{
    public Handler NextHandler;

    public void SetNextHandler(Handler nextHandler)
    {
        NextHandler = nextHandler;
    }
    public abstract void DispatchNote(long requestedAmount);
}

public class HundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 100;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + "Two hundred notes are dispatched by TwoHundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + "Two hundred note is dispatched by TwoHundredHandler");
            }
        }
    }
}
public class TwoHunderedHandler : Handler{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 200;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Hundred notes are dispatched by HundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Hundred note is dispatched by HundredHandler");
            }
        }

        long pendingAmountToBeProcessed = requestedAmount % 200;
        if (pendingAmountToBeProcessed > 0){
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}

public class FiveHunderedHandler : Handler{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 500;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred notes are dispatched by FiveHundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred note is dispatched by FiveHundredHandler");
            }
        }
        long pendingAmountToBeProcessed = requestedAmount % 500;
        if (pendingAmountToBeProcessed > 0)
        {
            NextHandler.DispatchNote(pendingAmountToBeProcessed);
        }
    }
}