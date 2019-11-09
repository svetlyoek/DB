namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {

        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //int input = int.Parse(Console.ReadLine());

                Console.WriteLine(CountCopiesByAuthor(db));
            }
        }

        //problem 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var age = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == age)
                .Select(b => new
                {
                    BookTitle = b.Title,
                })
                .OrderBy(b => b.BookTitle)
                .ToList();

            foreach (var t in bookTitles)
            {
                sb
                    .AppendLine(t.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var type = Enum.Parse<EditionType>("Gold");

            var booksTitles = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == type)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title
                })
                .ToList();

            foreach (var t in booksTitles)
            {
                sb
                    .AppendLine(t.BookTitle);
            }

            return sb.ToString().TrimEnd();

        }

        //problem 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToList();

            foreach (var b in books)
            {
                sb
                    .AppendLine($"{b.BookTitle} - ${b.BookPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => new
                {
                    BookTitle = t.Title
                })
                .ToList();

            foreach (var t in bookTitles)
            {
                sb
                    .AppendLine(t.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var bookTitles = new List<string>();

            foreach (var category in categories)
            {
                var books = context.Books
                    .Where(b => b.BookCategories
                    .Any(bc => bc.Category.Name.ToLower() == category.ToLower()))
                    .Select(b => new
                    {
                        b.Title
                    })
                    .ToList();

                foreach (var book in books)
                {
                    bookTitles.Add(book.Title);
                }
            }

            foreach (var title in bookTitles.OrderBy(t => t))
            {
                sb
                    .AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                 .Where(b => b.ReleaseDate < inputDate)
                 .OrderByDescending(b => b.ReleaseDate)
                 .Select(b => new
                 {
                     Title = b.Title,
                     Type = b.EditionType,
                     Price = b.Price
                 })
                 .ToList();

            foreach (var book in books)
            {
                sb
                    .AppendLine($"{book.Title} - {book.Type} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb
                    .AppendLine(author.FullName);

            }

            return sb.ToString().TrimEnd();

        }

        //problem 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.Title.ToLower()
                .Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(t => new
                {
                    BookTitle = t.Title
                })
                .ToList();

            foreach (var title in titles)
            {
                sb
                    .AppendLine(title.BookTitle);
            }

            return sb.ToString().TrimEnd();

        }

        //problem 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titlesAndAuthors = context.Books
                .Where(b => b.Author.LastName
                .StartsWith(input, StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.BookId)
                .Select(t => new
                {
                    BookTitle = t.Title,
                    AuthorName = t.Author.FirstName + " " + t.Author.LastName
                })
                .ToList();

            foreach (var title in titlesAndAuthors)
            {
                sb
                    .AppendLine($"{title.BookTitle} ({title.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;

        }

        //problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                  .Select(a => new
                  {
                      AuthorName = a.FirstName + " " + a.LastName,
                      BooksCount = a.Books.Sum(c => c.Copies)
                  })
                  .OrderByDescending(c => c.BooksCount)
                  .ToList();

            foreach (var author in authors)
            {
                sb
                    .AppendLine($"{author.AuthorName} - {author.BooksCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }

}
