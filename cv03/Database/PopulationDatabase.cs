using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class PopulationDatabase
    {
        private int idx = 0;
        private Person[] pop = new Person[2];
        public void Add(Person person)
        {
            if (idx == pop.Length)
            {
                Person[] tmp = new Person[pop.Length * 2];
                Array.Copy(pop, tmp, pop.Length);
                pop = tmp;
            }

            pop[idx] = person;
            idx++;
        }

        public int Count
        {
            get { 
                return idx; 
            }
        }

        public int AdultCount
        {
            get {
                int count = 0;
                for (int i = 0; i < idx; i++)
                {
                    if (pop[i].IsAdult)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public double? GetAverageAge()
        {
            int count = 0;
            int sum = 0;
            for (int i = 0; i < idx; i++)
            {
                if (pop[i].Age.HasValue)
                {
                    sum += pop[i].Age.Value;
                    count++;
                }
            }
            return count == 0 ? null : (double)sum / count;
        }
    }
}
