using System;

namespace Backend_Implementation
{
    class ArticleAmount
    {
        public int amount;

        Article article;

        public ArticleAmount(int _amount, Article _article)
        {
            amount = _amount;
            article = _article;
        }

        public string ToString()
        {
            return $"Amount: {amount} Articles: {article.ToString()}";
        }


    }

}