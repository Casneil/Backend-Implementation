using System;

namespace Backend_Implementation
{
    class ShipmentDocs
    {

        DateTime date;
        public string source;
        public string target;

        ArticleAmount articleAmount;


        public ShipmentDocs(string _source, string _target, ArticleAmount _articleAmount, DateTime _date)
        {
            date = _date;
            source = _source;
            target = _target;
            articleAmount = _articleAmount;

        }

        public int checkAmoutOfoSpecificArticle()
        {
            if (articleAmount != null)
            {
                return articleAmount.amount;

            }
            else
            {
                System.Console.WriteLine("You dont have any amount");
                return 0;
            }




        }

        public string ToString()
        {
            return $"Date: {date} Source: {source} Target: {target} Article amount: {articleAmount.ToString()}";
        }

    }
}