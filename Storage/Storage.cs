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

        // public ShipmentDocs GenerateShipment(Storage target, List<ArticleAmount> articles, List<Article> article)
        // {
        //     int input;
        //     int output;
        //     int results;
        //     List<ShipmentDocs> incomingShipmentDocs = new List<ShipmentDocs>();
        //     List<ShipmentDocs> outgoingShipmentDocs = new List<ShipmentDocs>();
        //     List<ShipmentDocs> totalShipments = new List<ShipmentDocs>();


        //     foreach (ShipmentDocs docs in target)
        //     {
        //         if (docs.articleAmountList == null)
        //         {
        //             throw new System.InvalidOperationException("There aren't enough articles in storage"); ;
        //         }
        //         else
        //         {

        //             foreach (ArticleAmount amnt in articles)
        //             {
        //                 if (amnt.amount <= 0)
        //                 {
        //                     output = outgoingShipmentDocs.Add(article);
        //                 }
        //                 if (amnt.amount >= 1)
        //                 {
        //                     input = incomingShipmentDocs.Add(articles);
        //                 }

        //                 results = input - output;

        //                 totalShipments = new ArticleAmount(results, amnt);

        //             }

        //         }
        //     }

        // }


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
    }
}

// int amount;
// List<Article> outGoing = new List<Article>();
// List<Article> inComing = new List<Article>();

// foreach (ShipmentDocs sd in Storage)
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