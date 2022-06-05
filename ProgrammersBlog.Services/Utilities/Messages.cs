using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFoundMessage(bool isPlural)
            {
                if (isPlural) return "No categories found.";

                return "Couldn't find such a category.";
            }
            public static string AddMessage(string categoryName)
            {
                return $"{categoryName} category is added successfully.";
            }
            public static string UpdateMessage(string categoryName)
            {
                return $"{categoryName} is updated successfully.";
            }
            public static string DeleteMessage(string categoryName)
            {
                return $"{categoryName} is deleted successfully.";
            }
            public static string UndoDeleteMessage(string categoryName)
            {
                return $"{categoryName} is recovered successfully.";
            }
            public static string HardDeleteMessage(string categoryName)
            {
                return $"{categoryName} is deleted successfully from DB.";
            }
        }
        public static class Article
        {
            public static string NotFoundMessage(bool isPlural)
            {
                if (isPlural) return "No articles found.";

                return "Couldn't find such a article.";
            }
            public static string AddMessage(string articleTitle)
            {
                return $"Article with the title of {articleTitle} is added successfully.";
            }
            public static string UpdateMessage(string articleTitle)
            {
                return $"Artile with the title of {articleTitle} is updated successfully.";
            }
            public static string DeleteMessage(string articleTitle)
            {
                return $"Article the title of {articleTitle} is deleted successfully.";
            }
            public static string UndoDeleteMessage(string articleTitle)
            {
                return $"Article the title of {articleTitle} is recovered successfully.";
            }
            public static string HardDeleteMessage(string articleTitle)
            {
                return $"Article with the title of {articleTitle} is deleted successfully from DB.";
            }
            public static string IncreaseViewCountMessage(string articleTitle)
            {
                return $"{articleTitle} başlıqlı məqalənin oxunma sayı uğurla artırıldı.";
            }
        }
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "No comments found.";
                return "Couldn't find such a comment.";
            }

            public static string Add(string createdByName)
            {
                return $"Dear {createdByName}, your comment has been added successfully.";
            }
            public static string ApproveMessage(int commentId)
            {
                return $"No:{commentId} is approved successfully.";
            }

            public static string Update(string createdByName)
            {
                return $"The comment added by {createdByName} has been updated successfully.";
            }
            public static string Delete(string createdByName)
            {
                return $"The comment added by {createdByName} has been deleted successfully.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"The comment added by {createdByName} has been recovered successfully.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"The comment added by {createdByName} has been deleted from DB successfully.";
            }
        }
    }
}
