using System;

namespace Backend_Implementation
{
    class ShipmentDocs
    {

        DateTime date;
        public string source;
        public string target;

        ArticleAmount articleAmount;


        public ShipmentDocs(DateTime _date, string _source, string _target, ArticleAmount _articleAmount)
        {
            date = _date;
            source = _source;
            target = _target;
            articleAmount = _articleAmount;

        }

    }
}