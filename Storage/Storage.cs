using System.Linq;
using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Storage
    {
        public int id;
        public string type;

        public List<Article> Articles { get; set; }

        public List<ShipmentDocument> incomingShipmentDocs;
        public List<ShipmentDocument> outgoingShipmentDocs;



        public Storage()
        {

        }



        public Storage(int _id, string _type, List<Article> _articles)
        {
            id = _id;
            type = _type;
            Articles = _articles;
        }




        public string ToString()
        {
            return $"Id: {id } Type:{type}";
        }

        public ShipmentDocument GenerateShipment(Storage target, List<ArticleAmount> articleAmount)
        {
            if (CheckAvailabilityOfItems(articleAmount))
            {
                ShipmentDocument shipDoc = new ShipmentDocument(this, target, articleAmount, new DateTime());
                outgoingShipmentDocs.Add(shipDoc);
                return shipDoc;
            }
            return null;
        }

        public bool CheckAvailabilityOfItems(List<ArticleAmount> articleAmount)
        {
            ShipmentDocument shipment = new ShipmentDocument();
            List<Article> allArticles = GetArticleList(articleAmount);
            List<ArticleAmount> result = new List<ArticleAmount>();


            int input;
            int output;
            int amount;
            foreach (Article art in allArticles)
            {
                input = GetAmount(incomingShipmentDocs, art);
                output = GetAmount(outgoingShipmentDocs, art);

                amount = input - output;
                if (amount < 0)
                {
                    throw new Exception("No available items for article" + art);
                }
                return false;
            }

            return true;

        }

        public int GetAmount(List<ShipmentDocument> sdl, Article art)
        {
            try
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
            catch (NullReferenceException ex)
            {
                System.Console.WriteLine("No articles in storage " + art.ToString());
                return 0;
            }
        }


        /// <summary>
        /// Returns a list of articles in all shipment documents
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
        /// <returns>List of Articles from any Shipment Document</returns>
        public List<Article> GetArticleList(List<ArticleAmount> sdl)
        {
            List<Article> articlesList = new List<Article>();


            foreach (ArticleAmount aa in sdl)
            {
                if (!articlesList.Contains(aa.article))
                {
                    articlesList.Add(aa.article);
                }
            }

            return articlesList;
        }

        // public bool GenerateIncomingShipment(List<ArticleAmount> articles)
        // {
        //     if (articles.Count > 0)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         throw new Exception("Not enough items in inventory");
        //     }

        // }

        // public List<ShipmentDocument> GenerateOutgoingShipment(Storage source, List<ArticleAmount> articles)
        // {
        //     int input;
        //     int output;
        //     int results;

        //     List<ShipmentDocument> incomingShipmentDocument = new List<ShipmentDocument>();

        //     List<ShipmentDocument> totalShipments = new List<ShipmentDocument>();

        //     return incomingShipmentDocument;



        // }

        // public static int GetAmount(List<ShipmentDocument> sdl, Article art)
        // {
        //     int amnt = 0;
        //     foreach (ShipmentDocument sd in sdl)
        //     {
        //         foreach (ArticleAmount aa in sd.articleAmountList)

        //         {
        //             if (aa.article.id == art.id)
        //             {
        //                 amnt += aa.amount;
        //             }
        //         }
        //     }
        //     return amnt;
        // }
    }
}
