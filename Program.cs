using System.Linq;
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



            var storage1 = new Storage(1, "FAEX", _Articlesoutgoing);
            var storage2 = new Storage(2, "C&C", _ArticlesIncoming);

            var requestArticleAmountList = new List<ArticleAmount> { new ArticleAmount(900, article1), (new ArticleAmount(500, article2)) };
            var sourceArticleAmountList = new List<ArticleAmount> { new ArticleAmount(90, article2), (new ArticleAmount(50, article1)) };



            var test = storage1.GenerateShipment(storage2, requestArticleAmountList);
            var test2 = storage2.GenerateShipment(storage1, sourceArticleAmountList);





            // var shipment1 = new ShipmentDocument(
            //     storage1, storage2,
            //     ///////////////////////////////
            //     // From Tobi ////////////////
            //     // new Storage(1, "FAEX", _Articles),
            //     // new Storage(2, "C&C", _Articles),
            //     new List<ArticleAmount> { new ArticleAmount(90, article1), new ArticleAmount(30, article2) }, new DateTime(2000, 10, 10));


            // var shipment2 = new ShipmentDocument(
            //     storage2, storage1,
            //     new List<ArticleAmount> { new ArticleAmount(30, article1), new ArticleAmount(40, article2) },
            //     new DateTime(2001, 11, 11));

            // ShipmentDocument shipment = new ShipmentDocument();
            // Storage store = new Storage();

            // var allShipmentDocuments = new List<ShipmentDocument>();
            // allShipmentDocuments.Add(shipment1);
            // // allShipmentDocuments.Add(shipment2);
            // allShipmentDocuments.Add(shipment2);

            // // System.Console.WriteLine(shipment1.ToString());

            // var art = shipment.GetArticleList(allShipmentDocuments);
            // foreach (Article a in art)
            // {
            //     System.Console.WriteLine(a.ToString());
            // }

            // var getinputDocs = shipment.GetInputAndOutputDocs(allShipmentDocuments, 1);
            // foreach (ArticleAmount b in getinputDocs)
            // {
            //     System.Console.WriteLine(b.ToString());
            // }





        }
    }
}
