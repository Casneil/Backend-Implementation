using System.Collections.Generic;
using System;

namespace Backend_Implementation
{
    class Storage
    {
        public int id;
        public string type;

        public List<Article> Articles { get; set; }

        public Storage(int _id, string _type, List<Article> _articles)
        {
            id = _id;
            type = _type;
            // Articles = _articles;
        }


        public string ToString()
        {
            return $"Id: {id } Type:{type}";
        }


        // public ShipmentDocument GenerateIncomingShipment(Storage target, List<ArticleAmount> articles)
        // {
        //     int input;
        //     int output;
        //     int results;

        //     List<ShipmentDocument> outgoingShipmentDocument = new List<ShipmentDocument>();
        //     List<ShipmentDocument> totalShipments = new List<ShipmentDocument>();


        // }

        // public ShipmentDocument GenerateOutgoingShipment(Storage source, List<ArticleAmount> articles)
        // {
        //     int input;
        //     int output;
        //     int results;

        //     List<ShipmentDocument> outgoingShipmentDocument = new List<ShipmentDocument>();
        //     List<ShipmentDocument> totalShipments = new List<ShipmentDocument>();



        // }

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
    }
}

// int amount;
// List<Article> outGoing = new List<Article>();
// List<Article> inComing = new List<Article>();

// foreach (ShipmentDocument sd in Storage)
// {
//     if (target.id && articles.amount > 1)
//     {
//         inComing.Add(new Article(articles));
//     }

//     if (target.id == 2 && articles.amount > 1)
//     {
//         outGoing.Add(new Article(articles));
//     }

// }