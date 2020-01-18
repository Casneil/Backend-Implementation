using System;

namespace Backend_Implementation
{
    class Articles
    {
        public int id;
        public string name;
        public string color;
        public string size;

        Designer designer;


        public string sendArticle(string name, string color, string size, Designer designer)
        {
            return System.Console.WriteLine($"Article: {name} | Color: {color} | Size: {size} | Designer: {designer} was shipped!");
        }

    }
}