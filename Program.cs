using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*************** Instanciating Test Objects ****************/

            var casneil = new Designer(1, "Casneil Simpson");
            var diana = new Designer(1, "Diana Schwarz");
            // var article = new List<Article>();
            // var article = new List<Article>();
            var article1 = new Article(1, "Pants", "White", "XXL", casneil);
            // System.Console.WriteLine(article.ToString());
            var article2 = new Article(2, "Skirt", "Green", "XS", diana);
            // System.Console.WriteLine(article1.ToString());

            var shipment1 = new ShipmentDocs(
                new Storage(1, "FAEX"),
                new Storage(2, "C&C"),
                new List<ArticleAmount> { new ArticleAmount(15, article1), new ArticleAmount(20, article2) },
                new DateTime(2000, 10, 10));
            var shipment2 = new ShipmentDocs(
                new Storage(3, "FX"),
                new Storage(4, "D&D"),
                new List<ArticleAmount> { new ArticleAmount(30, article1), new ArticleAmount(10, article2) },
                new DateTime(2001, 11, 11));

            var allShipmentDocuments = new List<ShipmentDocs>();
            allShipmentDocuments.Add(shipment1);
            allShipmentDocuments.Add(shipment2);
            // var shipment2 = new ShipmentDocs(new Storage(2, "C&C"), new Storage(4, "FAEX"), new ArticleAmount(2, article1), new DateTime(2005, 4, 20));
            // System.Console.WriteLine("Shipment: " + shipment1.checkAmoutOfSpecificArticle());
            System.Console.WriteLine(shipment1.ToString());
            // System.Console.WriteLine("Shipment: " + shipment1.checkAmoutOfSpecificArticle());
            // System.Console.WriteLine(shipment2.ToString());
            var art = GetArticleList(allShipmentDocuments);
            foreach (Article a in art)
            {
                System.Console.WriteLine(a.ToString());
            }



        }

        /// <summary>
        /// Returns a list of articles in all shipment documents
        /// </summary>
        /// <param name="sdl"></param>
        /// <returns>List of Articles from any Shipment Document</returns>
        public static List<Article> GetArticleList(List<ShipmentDocs> sdl)
        {
            List<Article> articlesList = new List<Article>();
            foreach (ShipmentDocs sd in sdl)
            {

                foreach (ArticleAmount aa in sd.articleAmountList)
                {
                    if (!articlesList.Contains(aa.article))
                    {
                        articlesList.Add(aa.article);
                    }
                }
            }
            return articlesList;
        }
    }
}
