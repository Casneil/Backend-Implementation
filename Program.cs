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
            var diana = new Designer(2, "Diana Schwarz");
            var article1 = new Article(1, "Pants", "White", "XXL", casneil);
            var article2 = new Article(2, "Skirt", "Green", "XS", diana);

            var _ArticlesIncoming = new List<Article>();
            var _Articlesoutgoing = new List<Article>();
            _ArticlesIncoming.Add(article1);
            _Articlesoutgoing.Add(article2);

            var sourceStorage = new Storage(1, "FAEX", _Articlesoutgoing);
            var targetStorage = new Storage(2, "C&C", _ArticlesIncoming);

            var shipment1 = new ShipmentDocument(
                sourceStorage, targetStorage,
                ///////////////////////////////
                // From Tobi ////////////////
                // new Storage(1, "FAEX", _Articles),
                // new Storage(2, "C&C", _Articles),
                new List<ArticleAmount> { new ArticleAmount(80, article1), new ArticleAmount(90, article2) }, new DateTime(2000, 10, 10));


            var shipment2 = new ShipmentDocument(
                sourceStorage, targetStorage,
                new List<ArticleAmount> { new ArticleAmount(30, article1), new ArticleAmount(10, article2) },
                new DateTime(2001, 11, 11));

            ShipmentDocument shipment = new ShipmentDocument();

            var allShipmentDocuments = new List<ShipmentDocument>();
            allShipmentDocuments.Add(shipment1);
            // allShipmentDocuments.Add(shipment2);
            allShipmentDocuments.Add(shipment2);

            // System.Console.WriteLine(shipment1.ToString());

            var art = shipment.GetArticleList(allShipmentDocuments);
            foreach (Article a in art)
            {
                System.Console.WriteLine(a.ToString());
            }

            var getinputDocs = shipment.GetInputAndOutputDocs(allShipmentDocuments, 2);
            foreach (ArticleAmount b in getinputDocs)
            {
                System.Console.WriteLine(b.ToString());
            }




        }


        /*******Implement method in Shipmentdocument for shipping to check if there is actual articles in storage before articles can be shipped Hence am getting negative value for amount******/

        /*******Implement method in Shipmentdocument for shipping to check if there is actual articles in storage before articles can be shipped Hence am getting negative value for amount******/


    }
}
