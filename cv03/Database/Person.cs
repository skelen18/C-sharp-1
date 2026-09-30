using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Person
    {
        /*
        private string Name;

        public string GetName()
        {
            return Name.ToUpper();
        }
        public void SetName(string name)
        {
            Name = name;
        }
        */

        //misto pomocne promenne muzeme pouzit field.ToUpper()
        private string _name;
        public string Name {
            get { return _name.ToUpper(); }
            set { _name = value; }
        }

        public GenderEnum Gender { 
            get; 
            set; 
        
        }

        private int? _age;
        public int? Age {
            get { 
                return _age; 
            }
            set {
                if (value >= 0 && value <= 150)
                {
                    _age = value;
                }

                else 
                { 
                    _age = null;
                }
            } 
        }

        public bool IsAdult { 
            get { 
                return _age >= 18; 
            }
        }

        public override string ToString()   
        {
            string str = Name + " je stary " + (Age == null ? "neni vyplnen" : Age.ToString()) + " let a je " + Gender;

            return str;
        }
        
   
    }
}
