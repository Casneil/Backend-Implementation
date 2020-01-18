using System;

namespace Backend_Implementation
{
    class Designer
    {
        public int id;
        public string name;

        public Designer(int _id, string _name)
        {
            id = _id;
            name = _name;

        }


        public string ToString()
        {
            return id + " " + name;
        }

    }
}