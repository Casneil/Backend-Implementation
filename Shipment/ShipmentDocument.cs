using System.Text;
using System;
using System.Collections.Generic;

namespace Backend_Implementation
{
    class ShipmentDocument
    {

        DateTime date;
        public Storage source;
        public Storage target;

        public List<ArticleAmount> articleAmountList;

        // public List<ShipmentDocument> shipdocs;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_source">Source</param>
        /// <param name="_target">Target</param>
        /// <param name="_articleAmountList">Amount of articles</param>
        /// <param name="_date">date shipped</param>



        public ShipmentDocument(Storage _source, Storage _target, List<ArticleAmount> _articleAmountList, DateTime _date)
        {
            source = _source;
            target = _target;
            articleAmountList = _articleAmountList;
            date = _date;

        }


        public ShipmentDocument()
        {


        }


        /// <summary>
        /// Returns a list of articles in all shipment documents
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
        /// <returns>List of Articles from any Shipment Document</returns>
        public List<Article> GetArticleList(List<ShipmentDocument> sdl)
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





        public string articleAmountListToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ArticleAmount a in articleAmountList)
            {
                sb.Append(a.ToString());
            }
            return sb.ToString();
        }



        /*******Method for shipping to check if there is actual articles in storage before articles can be shipped******/
        /*******Method for shipping to check if there is actual articles in storage before articles can be shipped******/

        public string ToString()
        {
            return $"Date: {date} Source: {source.ToString()} Target: {target.ToString()} Article amount: {articleAmountListToString()}";
        }



        /// <summary>
        /// Sorts articles based on source and target
        /// </summary>
        /// <param name="sdl">Shipment Document object as params</param>
        /// <param name="storageId">Storage ID object as params</param>
        /// <returns>Returns article difference</returns>
        public List<ArticleAmount> GetInputAndOutputDocs(List<ShipmentDocument> sd, int storageId)
        {
            ShipmentDocument shipment = new ShipmentDocument();
            List<Article> allArticles = shipment.GetArticleList(sd);
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


        /// <summary>
        /// Returns a filtered amount of articles based on articles and storage id
        /// </summary>
        /// <param name="sdl"> Shipment Document object as params</param>
        /// <param name="art">Article  object as params</param>
        /// <returns>Number of articles</returns>    
        public int GetAmount(List<ShipmentDocument> sdl, Article art)
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



// public ShipmentDocument(List<ArticleAmount> _articleAmountList, DateTime _date)
// {
//     articleAmountList = _articleAmountList;
//     date = _date;

// }

// public ShipmentDocument(Storage _target)
// {

//     target = _target;

// }