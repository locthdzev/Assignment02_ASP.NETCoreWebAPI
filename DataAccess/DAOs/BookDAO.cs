using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAOs
{
    public class BookDAO
    {
        private readonly MyDbContext _context;

        public BookDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return await _context.Books
                .Select(b => new BookDTO
                {
                    book_id = b.book_id,
                    title = b.title,
                    type = b.type,
                    pub_name = b.Publisher.publisher_name,
                    price = b.price,
                    advance = b.advance,
                    royalty = b.royalty,
                    ytd_sales = b.ytd_sales,
                    notes = b.notes,
                    published_date = b.published_date
                })
                .ToListAsync();
        }

        public async Task<BookDTO?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Where(b => b.book_id == id)
                .Select(b => new BookDTO
                {
                    book_id = b.book_id,
                    title = b.title,
                    type = b.type,
                    pub_name = b.Publisher.publisher_name,
                    price = b.price,
                    advance = b.advance,
                    royalty = b.royalty,
                    ytd_sales = b.ytd_sales,
                    notes = b.notes,
                    published_date = b.published_date
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddBookAsync(CreateBookDTO createBookDTO)
        {
            var book = new Book
            {
                title = createBookDTO.title,
                type = createBookDTO.type,
                pub_id = createBookDTO.pub_id,
                price = createBookDTO.price,
                advance = createBookDTO.advance,
                royalty = createBookDTO.royalty,
                ytd_sales = createBookDTO.ytd_sales,
                notes = createBookDTO.notes,
                published_date = createBookDTO.published_date
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int id, UpdateBookDTO updateBookDTO)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return;

            book.title = updateBookDTO.title;
            book.type = updateBookDTO.type;
            book.pub_id = updateBookDTO.pub_id;
            book.price = updateBookDTO.price;
            book.advance = updateBookDTO.advance;
            book.royalty = updateBookDTO.royalty;
            book.ytd_sales = updateBookDTO.ytd_sales;
            book.notes = updateBookDTO.notes;
            book.published_date = updateBookDTO.published_date;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
