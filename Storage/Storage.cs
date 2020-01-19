using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Storage
    {
        int id;
        string type;


        public Storage(int _id, string _type)
        {
            id = _id;
            type = _type;
        }


        public string ToString()
        {
            return $"Id: {id } Type:{type}";
        }
    }
}