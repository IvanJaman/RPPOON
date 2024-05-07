public abstract class Wizard{
    public abstract void DoMagic(); 
}

public abstract class Goblin{
    public abstract void DoDamage();
}

public class FireWizard : Wizard{
        public override void DoMagic()
        {
            Console.WriteLine("Do Fire Magic");
        }
    }

    public class WaterWizard : Wizard{
        public override void DoMagic(){
            Console.WriteLine("Do Water Magic");
        }
    }

    public class FireGoblin : Goblin{
        public override void DoDamage(){
            Console.WriteLine("Do Fire Damage");
        }
    }

    public class WaterGoblin : Goblin{
        public override void DoDamage(){
            Console.WriteLine("Do Water Damage");
        }
    }

    public abstract class CharachterFactory{
        public abstract Goblin CreateGoblin();
        public abstract Wizard CreateWizard();
    }

    public class FireCharachterFactory : CharachterFactory{
        public override Goblin CreateGoblin()
        {
            return new FireGoblin();
        }

        public override Wizard CreateWizard()
        {
            return new FireWizard();
        }
}

    public class WaterCharachterFactory : CharachterFactory{
        public override Goblin CreateGoblin()
        {
            return new WaterGoblin();
        }

        public override Wizard CreateWizard()
        {
            return new WaterWizard();
        }
    }

    public class GameManager{
        public void PlayFireLevel(FireCharachterFactory fireCharachterFactory){
            fireCharachterFactory.CreateGoblin();
            fireCharachterFactory.CreateWizard();
        }

        public void PlayWaterLevel(WaterCharachterFactory waterCharachterFactory){
            waterCharachterFactory.CreateGoblin();
            waterCharachterFactory.CreateWizard();
        }
    }

    class ClientCode{
        public static void Run(){
            FireCharachterFactory fireCharachterFactory = new FireCharachterFactory();
            WaterCharachterFactory waterCharachterFactory = new WaterCharachterFactory();
            GameManager gameManager = new GameManager();
            gameManager.PlayFireLevel(fireCharachterFactory);
            gameManager.PlayWaterLevel(waterCharachterFactory);
        }
    }
