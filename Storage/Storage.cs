using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Storage
    {
        ShipmentDocs shipmentdocs;
        Events events;
        DateTime date;

        string[] type = { "id: 1 Event Storage", "id: 2 FAEX Contest", "id: 3 Designer Storage" };


        public string recieveArticle(string name, string color, string size, Designer designer)
        {
            return System.Console.WriteLine($"Article: {name} | Color: {color} | Size: {size} | Designer: {designer} | recived:{date}");
        }


    }
}