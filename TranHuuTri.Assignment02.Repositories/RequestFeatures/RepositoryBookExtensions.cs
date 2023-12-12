using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.Repositories.RequestFeatures
{
    public static class RepositoryBookExtensions
    {
        public static IQueryable<Book> SearchBook(this IQueryable<Book> books,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return books;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return books.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<User> SearchUser(this IQueryable<User> users,
    string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return users;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return users.Where(e => e.Email.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<Author> SearchAuthor(this IQueryable<Author> authors,
string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return authors;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return authors.Where(e => e.EmailAddress.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Publisher> SearchPublisher(this IQueryable<Publisher> publishers,
string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return publishers;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return publishers.Where(e => e.PublisherName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<BookAuthor> SearchBookAuthor(this IQueryable<BookAuthor> bookAuthors,
string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return bookAuthors;
            var lowerCaseTerm = searchTerm.Trim();
            return bookAuthors
                .Where(e => e.BookId.Equals(lowerCaseTerm))
                .Where(p => p.AuthorId.Equals(lowerCaseTerm));
        }
    }
}
