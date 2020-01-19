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

            var article1 = new Article(1, "Pants", "White", "XXL", casneil);

            var article2 = new Article(2, "Skirt", "Green", "XS", diana);


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

            System.Console.WriteLine(shipment1.ToString());

            var art = GetArticleList(allShipmentDocuments);
            foreach (Article a in art)
            {
                System.Console.WriteLine(a.ToString());
            }



        }

        /// <summary>
        /// Returns a list of articles in all shipment documents
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
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

        /// <summary>
        /// Returns a filtered amount of articles based on articles and storage id
        /// </summary>
        /// <param name="sdl"> Shipment Document object as params</param>
        /// <param name="art">Article  object as params</param>
        /// <returns>Number of articles</returns>    
        public static int GetAmount(List<ShipmentDocs> sdl, Article art)
        {
            int amnt = 0;
            foreach (ShipmentDocs sd in sdl)
            {
                foreach (ArticleAmount aa in sd.articleAmountList)
                {
                    if (aa.article.id == art.id)
                    {
                        amnt += aa.amount;
                    }
                }
            }
            return amnt;
        }
        /// <summary>
        /// Sorts articles based on source and target
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
        /// <param name="storageId">Storage ID object as params</param>
        /// <returns>Returns article difference</returns>
        public static List<ArticleAmount> GetInputAndOutputDocs(List<ShipmentDocs> sdl, int storageId)
        {
            List<Article> allArticles = GetArticleList(sdl);
            List<ArticleAmount> result = new List<ArticleAmount>();
            List<ShipmentDocs> docsWithStorageAsSource = new List<ShipmentDocs>();
            List<ShipmentDocs> docsWithStorageAsTarget = new List<ShipmentDocs>();

            foreach (ShipmentDocs doc in sdl)
            {
                if (doc.source.id == storageId)
                {
                    docsWithStorageAsSource.Add(doc);
                }
                if (doc.target.id == storageId)
                {
                    docsWithStorageAsTarget.Add(doc);
                }
            }

            int input;
            int output;
            int amount;
            foreach (Article ar in allArticles)
            {
                input = GetAmount(docsWithStorageAsTarget, ar);
                output = GetAmount(docsWithStorageAsSource, ar);
                amount = input - output;
                result.Add(new ArticleAmount(amount, ar));
            }

            return result;

        }

    }
}
