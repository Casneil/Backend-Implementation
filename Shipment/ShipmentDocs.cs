using System.Text;
using System;
using System.Collections.Generic;

namespace Backend_Implementation
{
    class ShipmentDocs
    {

        DateTime date;
        public Storage source;
        public Storage target;

        public List<ArticleAmount> articleAmountList;


        public ShipmentDocs(Storage _source, Storage _target, List<ArticleAmount> _articleAmountList, DateTime _date)
        {
            date = _date;
            source = _source;
            target = _target;
            articleAmountList = _articleAmountList;

        }

        // public int checkAmoutOfSpecificArticle()
        // {
        //     if (articleAmount != null)
        //     {
        //         return articleAmountList.amount;

        //     }
        //     else
        //     {
        //         System.Console.WriteLine("You dont have any amount");
        //         return 0;
        //     }

        // }
        public string articleAmountListToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ArticleAmount a in articleAmountList)
            {
                sb.Append(a.ToString());
            }
            return sb.ToString();
        }

        public string ToString()
        {
            return $"Date: {date} Source: {source.ToString()} Target: {target.ToString()} Article amount: {articleAmountListToString()}";
        }

    }
}