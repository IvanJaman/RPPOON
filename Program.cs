//zad1
//Obrazac je graditelj (builder), pripada skupini obrazaca stvaranja.

public interface IConstructable{
    public MailConstructor AddSubject(string subject);
    public MailConstructor AddContent(string content);
    public MailConstructor AddRecipient(string recipient);
    public MailConstructor AddAttachments(string attachments);
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
    public MailConstructor AddSubject(string subject){
        mail.Subject = subject;
        return this;
    }
    public MailConstructor AddContent(string content){
        mail.Content = content;
        return this;
    }
    public MailConstructor AddRecipient(string recipient){
        mail.Recipient = recipient;
        return this;
    }
    public MailConstructor AddAttachments(string attachments){
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
    MailConstructor mailConstructor;
    public NoReplyMailSender(MailConstructor mailConstructor) {
        this.mailConstructor = mailConstructor;
    }

    public void SendNoReplyMail(){
        mailConstructor.AddSubject("No Reply").AddContent("Hello World").Construct();
            //Sending logic here
    }
}

class ClientCode1{
    MailConstructor mailConstructor = new MailConstructor();
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

class ClientCode2{

}