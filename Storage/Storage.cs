using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;

namespace Backend_Implementation
{
    class Storage
    {
        public int id;
        public string type;

        public List<Article> Articles { get; set; }

        public List<ShipmentDocument> incomingShipmentDocs = new List<ShipmentDocument>();
        public List<ShipmentDocument> outgoingShipmentDocs = new List<ShipmentDocument>();



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


        public void FillStorage(List<ShipmentDocument> newShipmentDocuments)
        {
            incomingShipmentDocs.AddRange(newShipmentDocuments);
        }
        public ShipmentDocument GenerateShipment(Storage target, List<ArticleAmount> articleAmount)
        {
            if (CheckAvailabilityOfItems(articleAmount))
            {
                ShipmentDocument shipDoc = new ShipmentDocument(this, target, articleAmount, new DateTime());
                outgoingShipmentDocs.Add(shipDoc);
                target.incomingShipmentDocs.Add(shipDoc);
                return shipDoc;
            }
            return null;
        }

        public bool CheckAvailabilityOfItems(List<ArticleAmount> articleAmount)
        {
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

        public void ShowStock()
        {
            List<Article> articlesListIn = new List<Article>();
            List<Article> articlesListOut = new List<Article>();
            List<ArticleAmount> articleAmountListIn = new List<ArticleAmount>();
            List<ArticleAmount> articleAmountListOut = new List<ArticleAmount>();
            // All Incoming shipments
            foreach (ShipmentDocument i in incomingShipmentDocs)
            {
                articlesListIn.AddRange(GetArticleList(i.articleAmountList));
                foreach (ArticleAmount a in i.articleAmountList)
                {
                    articleAmountListIn.Add(a);
                }
            }
            Dictionary<Article, int> incomingArticleAmounts = new Dictionary<Article, int>();
            foreach (ArticleAmount aa in articleAmountListIn)
            {

                foreach (Article a in articlesListIn)
                {
                    if (a.Equals(aa.article))
                    {
                        incomingArticleAmounts.Add(a, aa.amount);
                    }
                }
            }

            // All Outgoing shipments
            foreach (ShipmentDocument i in outgoingShipmentDocs)
            {
                articlesListOut.AddRange(GetArticleList(i.articleAmountList));
                foreach (ArticleAmount a in i.articleAmountList)
                {
                    articleAmountListOut.Add(a);
                }
            }
            Dictionary<Article, int> outgoingArticleAmounts = new Dictionary<Article, int>();
            foreach (ArticleAmount aa in articleAmountListOut)
            {

                foreach (Article a in articlesListOut)
                {
                    if (a.Equals(aa.article))
                    {
                        outgoingArticleAmounts.Add(a, aa.amount);
                    }
                }
            }
            // Results
            Dictionary<Article, int> result = new Dictionary<Article, int>();
            foreach (var i in incomingArticleAmounts)
            {
                foreach (var j in outgoingArticleAmounts)
                {
                    if (i.Key == j.Key)
                    {
                        result.Add(i.Key, i.Value - j.Value);
                    }
                }
            }

            foreach (var item in result)
            {
                System.Console.WriteLine(item.Key.ToString() + " " + item.Value.ToString());
            }

            // return result;



            // Call GetArticleList method

            // Iterate over all shipment docs

            // All articles



        }



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


    }
}
