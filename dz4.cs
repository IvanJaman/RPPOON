//zad1
//Obrazac je graditelj (builder), pripada skupini obrazaca stvaranja.

public interface IConstructable{
    public IConstructable AddSubject(string subject);
    public IConstructable AddContent(string content);
    public IConstructable AddRecipient(string recipient);
    public IConstructable AddAttachments(string attachments);
    public Mail Construct();
    public IConstructable Reset();

}

public class Mail{
    public string Subject {get;set;}
    public string Content {get;set;}
    public string Recipient {get;set;}
    public string Attachments {get;set;}
}

public class MailConstructor : IConstructable{
    Mail mail;
    public MailConstructor(){
        mail = new Mail();
    }
    public IConstructable AddSubject(string subject){
        mail.Subject = subject;
        return this;
    }
    public IConstructable AddContent(string content){
        mail.Content = content;
        return this;
    }
    public IConstructable AddRecipient(string recipient){
        mail.Recipient = recipient;
        return this;
    }
    public IConstructable AddAttachments(string attachments){
        mail.Attachments = attachments;
        return this;
    }

    public Mail Construct(){
        return mail;
    }
    public IConstructable Reset()
    {
        mail = new Mail();
        return this;
    }
}

public class NoReplyMailSender {
    IConstructable MailConstructor;
    public NoReplyMailSender(IConstructable mailConstructor) {
        MailConstructor = mailConstructor;
    }

    public void SendNoReplyMail(){
        mailConstructor.AddSubject("No Reply").AddContent("Hello World").Construct();
        //Sending logic here
    }
}

class ClientCode1{
    public static void Run(){
        IConstructable mailConstructor = new IConstructable();
        NoReplyMailSender noReplyMailSender = new NoReplyMailSender(mailConstructor);
        noReplyMailSender.SendNoReplyMail();
    }
}





//zad2
//obrazac je apstraktna tvornica, pripada skupini obrazaca stvaranja.

public class WebElement{
    string Name;
    public WebElement(string name){
        Console.WriteLine($"Found {name}");
        Name = name;
    }
    public void Click(){
        Console.WriteLine($"Clicked {Name}");
    }
}

public interface LoginPage{
    public WebElement CreateLoginButton();
    public WebElement InputUsername();
    public WebElement InputPassword();
}

public class ChromeLoginPage : LoginPage{
    public WebElement CreateLoginButton(){
        WebElement loginButton = new WebElement("loginButton");
        return loginButton;
    }
    public WebElement InputUsername(){
        WebElement username = new WebElement("Username");
        return username;
    }
    public WebElement InputPassword(){
        WebElement password = new WebElement("Password");
        return password;
    }
}

public abstract class LoginPageFactory{
    public abstract LoginPage CreatePage();
}

public class ChromeLoginPageFactory : LoginPageFactory{
    public override LoginPage CreatePage()
    {
        return new ChromeLoginPage();
    }
}

class ClientCode2{
    public static void Run(){
        LoginPageFactory loginPageFactory = new ChromeLoginPageFactory();
        LoginPage loginPage = loginPageFactory.CreatePage();
        loginPage.CreateLoginButton().Click();
    }
}
