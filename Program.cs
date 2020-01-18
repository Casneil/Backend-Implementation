using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var casneil = new Designer(1, "Casneil Simpson");
            var diana = new Designer(1, "Diana Schilling");
            var article = new Article(1, "Pants", "White", "XXL", casneil);
            System.Console.WriteLine(article.ToString());
            var article1 = new Article(2, "Skirt", "Green", "XS", diana);
            System.Console.WriteLine(article1.ToString());

            var shipment = new ShipmentDocs("FAEX", "C&C", new ArticleAmount(3, article), new DateTime(2000, 10, 10));
            System.Console.WriteLine("Shipment: " + shipment.checkAmoutOfoSpecificArticle());
            System.Console.WriteLine(shipment.ToString());



        }
    }
}
