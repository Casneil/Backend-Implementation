using System;

namespace Backend_Implementation
{
    class Article
    {
        public int id;
        public string name;
        public string color;
        public string size;

        Designer designer;

        public Article(int _id, string _name, string _color, string _size, Designer _designer)
        {
            id = _id;
            name = _name;
            color = _color;
            size = _size;
            designer = _designer;
        }


        public string ToString()
        {
            return $"Article ID: {id} Name: {name} | Color: {color} | Size: {size} | Designer: {designer.ToString()}";
        }

    }
}