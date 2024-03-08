#pragma warning disable IDE0005 // Using directive is unnecessary.
using System.Globalization;
#pragma warning restore IDE0005 // Using directive is unnecessary.

[assembly: CLSCompliant(true)]

namespace BookStoreItem
{
    /// <summary>
    /// Represents an item in a book store.
    /// </summary>
    // DONE Declare a class.
    public class BookStoreItem
    {
        // DONE Add fields.
        private readonly string authorName;
        private readonly string? isni;
        private readonly bool hasIsni;
        private decimal price;
        private string currency;
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // DONE Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string isbn)
            : this(authorName, null, title, publisher, isbn)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // DONE Add a constructor.
        public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn)
           : this(authorName, isni, title, publisher, isbn: isbn, null, bookBinding: string.Empty, 0, "USD", 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // DONE Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
            : this(authorName, isni: null, title, publisher, isbn, published, bookBinding, price, currency, amount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // DONE Add a constructor.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable CA1307 // Specify StringComparison for clarity
            if (authorName.Trim().Replace(" ", string.Empty).Length == 0)
            {
                throw new ArgumentException(authorName, nameof(authorName));
            }

            if (title.Trim().Replace(" ", string.Empty).Length == 0)
            {
                throw new ArgumentException(title, nameof(title));
            }

            if (publisher.Trim().Replace(" ", string.Empty).Length == 0)
            {
                throw new ArgumentException(publisher, nameof(publisher));
            }

            if (isni != null && !ValidateIsni(isni))
            {
                throw new ArgumentException(isni, nameof(isni));
            }

            if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn))
            {
                throw new ArgumentException(isbn, nameof(isbn));
            }

            if (currency.Length != 3 || !currency.All(char.IsLetter))
            {
                ThrowExceptionIfCurrencyIsNotValid(currency, nameof(currency));
            }

            this.authorName = authorName;
            this.Title = title;
            this.Publisher = publisher;

            if (isni != null)
            {
                this.isni = isni;
                this.hasIsni = true;
            }
            else
            {
                this.isni = null;
                this.hasIsni = false;
            }

            this.Isbn = isbn;
            this.Published = published;
            this.BookBinding = bookBinding;
            this.Price = price;
            this.Currency = currency;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        // DONE Add a property.
        public string AuthorName
        {
            get { return this.authorName; }
        }

        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        // DONE Add a property.
        public string? Isni
        {
            get { return this.isni; }
        }

        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        // DONE Add a property.
        public bool HasIsni
        {
            get { return this.hasIsni; }
        }

        /// <summary>
        /// Gets a book title.
        /// </summary>
        // DONE Add a property.
        public string Title { get; private set; }

        /// <summary>
        /// Gets a book publisher.
        /// </summary>
        // DONE Add a property.
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        // DONE Add a property.
        public string Isbn { get; private set; }

        /// <summary>
        /// Gets or sets a book publishing date.
        /// </summary>
        // DONE Add a property.
        public DateTime? Published { get; set; }

        /// <summary>
        /// Gets or sets a book binding type.
        /// </summary>
        // DONE Add a property.
        public string BookBinding { get; set; }

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        // DONE Add a property.
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Gets or sets a price currency.
        /// </summary>
        // DONE Add a property.
        public string Currency
        {
            get
            {
                return this.currency;
            }

            set
            {
                if (value.Length != 3 || !value.All(char.IsLetter))
                {
                    ThrowExceptionIfCurrencyIsNotValid(value, nameof(value));
                }

                this.currency = value;
            }
        }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        // DONE Add a property.
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        // DONE Add an instance method.
#pragma warning disable CA1024 // Use properties where appropriate
        public Uri GetIsniUri()
        {
            if (this.isni == null)
            {
                throw new InvalidOperationException(nameof(this.isni));
            }

            return new Uri($"https://isni.org/isni/{this.isni}");
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        // DONE Add an instance method.
        public Uri GetIsbnSearchUri()
        {
            return new Uri($"https://isbnsearch.org/isbn/{this.Isbn}");
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        // DONE Add an instance method.
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual string ToString()
        {
            string priceStr;
            if (this.Price < 1000)
            {
                priceStr = $"{this.Price:N2}".ToString().Replace(',', '.') + $" {this.Currency}";
            }
            else
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                priceStr = $"\"{this.Price.ToString("###_###_###.##").Replace(',', '.').Replace('_', ',')} {this.Currency}\"";
            }

            if (this.hasIsni)
            {
                return $"{this.Title}, {this.AuthorName}, {this.Isni}, {priceStr}, {this.Amount}".ToString();
            }
            else
            {
                return $"{this.Title}, {this.AuthorName}, ISNI IS NOT SET, {priceStr}, {this.Amount}".ToString();
            }
        }

        // DONE Add a static method.
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool ValidateIsni(string _isni)
        {
            if (_isni.Length == 16 && (_isni.All(char.IsDigit) || _isni.All(x => x == 'X')))
            {
                return true;
            }

            return false;
        }

        // DONE Add a static method.
        private static bool ValidateIsbnFormat(string _isbn)
        {
            if (_isbn.Length == 10 && (_isbn.All(char.IsDigit) || _isbn.All(x => x == 'X')))
            {
                return true;
            }

            return false;
        }

        // DONE Add a static method.
        private static bool ValidateIsbnChecksum(string _isbn)
        {
            int i = _isbn.Length;
            int checkSum = 0;
            foreach (char c in _isbn)
            {
                if (c == 'X')
                {
                    checkSum += 10 * i;
                }
                else
                {
                    checkSum += c * i;
                }

                i--;
            }

            if (checkSum % 11 == 0)
            {
                return true;
            }

            return false;
        }

        // DONE Add a static method.
        private static void ThrowExceptionIfCurrencyIsNotValid(string _currency, string _parameterName)
        {
            throw new ArgumentException(_currency, _parameterName);
        }
    }
}
