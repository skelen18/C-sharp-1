using Database;

namespace cv3


{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenderEnum x = GenderEnum.MALE;
            Person p = new Person();

            p.Name = "Bagha";
            p.Age = 16;
            p.Gender = GenderEnum.MALE;

            /*string str = p.ToString();
            Console.WriteLine(str);*/

            //Console.WriteLine(p);

            PopulationDatabase db = new PopulationDatabase();
            db.Add(new Person() { Name = "Alice", Age = 25, Gender = GenderEnum.FEMALE });
            db.Add(new Person() { Name = "Petr", Age = 12, Gender = GenderEnum.MALE });

            Console.WriteLine("Pocet osob: " + db.Count);
            Console.WriteLine("Pocet dospelych: " + db.AdultCount);

            //Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age + ", Gender: " + p.Gender);
            //Console.WriteLine("Is Adult: " + p.IsAdult);

        }
    }
}
