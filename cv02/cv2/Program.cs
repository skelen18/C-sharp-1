namespace cv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Colors color = Colors.Blue | Colors.Red;
            //if (color == Colors.Blue)
            if ((color & Colors.Blue) != 0) //kontorla jestli je barva modra
            {
                Console.WriteLine("Barva je modrá barva");
            }
            else
            {
                Console.WriteLine("Nezama barva");
            }
            Console.WriteLine((int)color);
            */



            //Nullable<int> x = new Nullable<int>();
            int? x = null;

            //if (x.HasValue)
            if(x != null)
            {
                Console.WriteLine(x.Value);
            }
            else
            {
                Console.WriteLine("Nema hodnotu");
            }


            string txt = Console.ReadLine();
            //int num = ParseInt(txt);
            //int? num = ParseIntOrNull(txt);

            //Console.WriteLine(num);

            /*if (num.HasValue)
              {
                  Console.WriteLine(num.Value);
              }
              else
              {
                  Console.WriteLine("null");
              }
              */

            /*
            1.
            do parseint naimplementovat
            R= 0 (R je result)
            R = R *10 + N (n bude zadane cislo)
            R = R * 10 + N ,atak dale

            2.
            pridat kontroli ze to je jen cislo a ne pismeno

            3. pridat vypsani jestli je to cislo nebo ne, kdyz ne tak napsat null

            4.  pridat metodu TryParseInt, které předáte textový řetězec a 
            která vrátí true nebo false podle toho, zda se parsování čísla podařilo. 
            Výsledek parsování vraťte pomocí výstupního parametru této metody.

            5. druha vlastni metoda TryParseInt, ktere se preda string a nastavi vlastni vyctovy typ ParseIntOption
            true or false podle toho , zda se parsování čísla podařilo.
            v ParseIntOption budou 4:

            NONE
            ALLOW_WHITESPACES
            ALLOW_NEGATIVE_NUMBERS
            IGNORE_INVALID_CHARACTERS

            ALLOW_WHITESPACES povolí mezery a bílé znaky mezi číslicemi,
            ALLOW_NEGATIVE_NUMBERS povolí znaménko mínus,
            IGNORE_INVALID_CHARACTERS umožní přeskočení všech znaků, které nejsou číslicemi.

            */
            int num = 0;
            ParseIntOption option = ParseIntOption.ALLOW_WHITESPACES | ParseIntOption.ALLOW_NEGATIVE_NUMBERS | ParseIntOption.IGNORE_INVALID_CHARACTERS;

            if (TryParseInt(txt, ref num, option))
            {
                
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine("chybny vstup");
            }

        }






        private static bool TryParseInt(string txt, ref int result, ParseIntOption option)
        {
            result = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] < '0' || txt[i] > '9')
                {
                    if ((option & ParseIntOption.IGNORE_INVALID_CHARACTERS) != 0)
                    {
                        continue;
                    }
                    return false;
                }
                result = result * 10 + (txt[i] - '0');
                if ((option & ParseIntOption.ALLOW_WHITESPACES) != 0)
                {
                    while (i + 1 < txt.Length && char.IsWhiteSpace(txt[i + 1]))
                    {
                        i++;
                    }
                }
                if ((option & ParseIntOption.ALLOW_NEGATIVE_NUMBERS) != 0)
                {
                    if (i + 1 < txt.Length && txt[i + 1] == '-')
                    {
                        result = -result;
                        i++;
                    }
                }
            }

            return true;
        }

        /*
        private static int? ParseIntOrNull(string txt)
        {

            int? result = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] < '0' || txt[i] > '9')
                {
                    return null;
                }
                result = result * 10 + (txt[i] - '0');
            }

            return result;
        }
        */

        /*
        private static int ParseInt(string txt)
        {
            int result = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] < '0' || txt[i] > '9')
                {
                    return -1;
                }
                result = result * 10 + (txt[i] - '0');
            }

            return result;
        }
        */

    }
}
