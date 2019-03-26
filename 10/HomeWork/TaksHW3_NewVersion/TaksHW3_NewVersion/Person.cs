using System;
using System.Collections.Generic;
using System.Text;

namespace TaksHW3_NewVersion
{
    class Person
    {
        private string _name;
        private uint _age;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public uint Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value <= 100)
                    _age = value;
                else
                    throw new Exception("Значение возраста не может быть больше 100!");
            }
        }

        private string PersonInfo
        {
            get
            {
                return $"Name: {_name}, ages in 4 years: {_age + 4}\n";
            }
        }

        public void WritePersonInfoToConsole()
        {
            Console.Write(PersonInfo);
        }
    }
}
