using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Program
    {
        // {
        //     public static List<Article> _Articles = new List<Article>()
        //     {
        //         new Article(1, "Pants", "White", "XXL", casneil),
        //         new Article(2, "Skirt", "Green", "XS", diana)
        //     };

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

            var allShipmentDocuments = new List<ShipmentDocument>();
            allShipmentDocuments.Add(shipment1);
            // allShipmentDocuments.Add(shipment2);
            allShipmentDocuments.Add(shipment2);

            System.Console.WriteLine(shipment1.ToString());

            var art = GetArticleList(allShipmentDocuments);
            foreach (Article a in art)
            {
                System.Console.WriteLine(a.ToString());
            }

            var getinputDocs = GetInputAndOutputDocs(allShipmentDocuments, 2);
            foreach (ArticleAmount b in getinputDocs)
            {
                System.Console.WriteLine(b.ToString());
            }




        }

        /// <summary>
        /// Returns a list of articles in all shipment documents
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
        /// <returns>List of Articles from any Shipment Document</returns>
        public static List<Article> GetArticleList(List<ShipmentDocument> sdl)
        {
            List<Article> articlesList = new List<Article>();
            foreach (ShipmentDocument sd in sdl)
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
        public static int GetAmount(List<ShipmentDocument> sdl, Article art)
        {
            int amnt = 0;
            foreach (ShipmentDocument sd in sdl)
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
        public static List<ArticleAmount> GetInputAndOutputDocs(List<ShipmentDocument> sd, int storageId)
        {
            List<Article> allArticles = GetArticleList(sd);
            List<ArticleAmount> result = new List<ArticleAmount>();
            List<ShipmentDocument> docsWithStorageAsSource = new List<ShipmentDocument>();
            List<ShipmentDocument> docsWithStorageAsTarget = new List<ShipmentDocument>();

            try
            {
                foreach (ShipmentDocument docs in sd)
                {

                    if (docs.source.id == storageId)
                    {
                        docsWithStorageAsSource.Add(docs);
                    }
                    if (docs.target.id == storageId)
                    {
                        docsWithStorageAsTarget.Add(docs);
                    }
                }

                int input;
                int output;
                int amount;
                foreach (Article art in allArticles)
                {
                    input = GetAmount(docsWithStorageAsTarget, art);
                    output = GetAmount(docsWithStorageAsSource, art);
                    /********** Adding the inout and output alwasy give a psoitive number *********/
                    // amount = input + output; //
                    /******************************************************************************/
                    amount = input - output;
                    result.Add(new ArticleAmount(amount, art));
                }


            }
            catch (Exception exp)
            {
                System.Console.WriteLine("No articles to ship: " + exp.ToString());
            }
            return result;

        }


        /*******Implement method in Shipmentdocument for shipping to check if there is actual articles in storage before articles can be shipped Hence am getting negative value for amount******/

        /*******Implement method in Shipmentdocument for shipping to check if there is actual articles in storage before articles can be shipped Hence am getting negative value for amount******/


    }
}
