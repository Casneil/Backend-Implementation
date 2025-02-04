using System;

namespace Backend_Implementation
{
    class ArticleAmount
    {
        public int amount;

        public Article article;

        public ArticleAmount(int _amount, Article _article)
        // public ArticleAmount(int _amount, Article _article)
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