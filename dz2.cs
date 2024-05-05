PREIMENOVANJE

zad2

class Product
    {
        public string Name { get; private set; } 
        public string Price { get; private set; } 
        public bool IsInStock { get; set; } 

        public Product(string name, string price)
        {
            this.Name = name;
            this.Price = price;
            this.IsInStock = false;
        }
    }

    class Handler
    {
        List<Product> products;

        public Handler(List<Product> inventory) 
        {
            products = inventory;
        }

        public void Restock(Product Product)
        {
            foreach (Product p in products)
            { 
                if (Product == p)
                    p.IsInStock = true;
            }
        }
        public void RemoveUnavailableProducts()
        { 
            products.RemoveAll(Product => Product.IsInStock == false);
        }
    }



    zad4

    public class Note
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Creation { get; private set; }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
            Creation = DateTime.Now;
        }
    }

    public class Notes
    {
        public string Author { get; private set; }
        public List<Note> notes;

        public Notes(string author)
        {
            Author = author;
            notes = new List<Note>();
        }

        public void Add(Note note)
        {
            notes.Add(note);
        }
    }



    zad5

    public class Location
    {
        public DateTime Creation { get; private set; } 
        public double Latitude { get; private set; } 
        public double Longitude { get; private set; } 

        public Location(double latitude, double longitude)
        {
            // Constructor implementation
        }
    }

    public class PathManager
    {
        private List<Location> locations; 

        public PathManager()
        {
            locations = new List<Location>();
        }

        public void Add(Location location)
        {
            locations.Add(location);
        }

        public void Remove(Location location)
        {
            locations.Remove(location);
        }
    }



    REFAKTORIRANJE

    zad2

    class Average
    {
        void CalculateAverage(List<double[]> averages){
            double sum;
            foreach (double[] average in averages)
            {
                sum = 0;
                for (int i = 0; i < average.Length; i++) 
                    sum += average[i];
            }
            return sum / average.Length;
        }

        List<double> ManageResults(List<double[]> averages)
        {
            List<double> results = new List<double>();            
            results.Add(CalculateAverage(averages));
            return results;
        }
    }



    zad4

    class DrugiZadatak
    {
        int CountOccurrence(int i, string text){
            int counter = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (text[i] == text[j])
                {
                    counter++;
                }
            }
            return counter;
        }

        void Add(string text, List<char> chars){
            for (int i = 0; i < text.Length; i++)
            {
                if (CountOccurrence(i, text) == 1)
                {
                    chars.Add(text[i]);
                }
            }
        }

        public static List<char> ReturnUniqueChars(string text)
        {
            List<char> chars = new List<char>();
            Add(text, chars);
            return chars;
        }
    }



    zad5

    class DrugiZadatak
    {
        void Add(List<string> strings, string temp1, string temp2){
            if (temp1.Equals(temp2))
            {
                results.Add(s);
            }
        }
        
        void Check(List<string> strings){
            foreach (string s in strings)
            {
                string temp1 = s.Replace(" ", "").ToLower();
                string temp2 = new string(temp1.Reverse().ToArray());
                Add(strings, temp1, temp2);
            }
            return results;
        }

        public List<string> ReturnPalindromes(List<string> strings)
        {
            List<string> results = new List<string>();
            if (strings == null) 
                return results;

            Check(strings);
            return results;
        }
    }