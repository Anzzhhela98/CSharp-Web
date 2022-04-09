namespace BookStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data;
    using BookStore.Data.Common.Repositories;
    using BookStore.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class BooksController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public BooksController(IDeletableEntityRepository<Book> bookRepository, IDeletableEntityRepository<Category> categoryRepository, IDeletableEntityRepository<Image> imageRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
            this.userRepository = userRepository;
        }

        // GET: Administration/Books
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.bookRepository.AllWithDeleted().Include(b => b.Category).Include(b => b.CreatedByUser).Include(b => b.Image);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = await this.bookRepository.AllWithDeleted()
                .Include(b => b.Category)
                .Include(b => b.CreatedByUser)
                .Include(b => b.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            return this.View(book);
        }

        // GET: Administration/Books/Create
        public IActionResult Create()
        {
            this.ViewData["CategoryId"] = new SelectList(this.categoryRepository.AllWithDeleted(), "Id", "Type");
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.AllWithDeleted(), "Id", "Id");
            this.ViewData["ImageId"] = new SelectList(this.imageRepository.AllWithDeleted(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Description,Quantity,Price,Pages,Cover,Language,Year,DateOfPublication,UniqueIdBook,ISBN,IsOnPromotional,ImageId,CategoryId,CreatedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Book book)
        {
            if (this.ModelState.IsValid)
            {
                await this.bookRepository.AddAsync(book);
                await this.bookRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoryRepository.All(), "Id", "Type", book.CategoryId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id", book.CreatedByUserId);
            this.ViewData["ImageId"] = new SelectList(this.imageRepository.All(), "Id", "Id", book.ImageId);
            return this.View(book);
        }

        // GET: Administration/Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = this.bookRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoryRepository.AllWithDeleted(), "Id", "Type", book.CategoryId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.AllWithDeleted(), "Id", "Id", book.CreatedByUserId);
            this.ViewData["ImageId"] = new SelectList(this.imageRepository.AllWithDeleted(), "Id", "Id", book.ImageId);
            return this.View(book);
        }

        //// POST: Administration/Books/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Author,Description,Quantity,Price,Pages,Cover,Language,Year,DateOfPublication,UniqueIdBook,ISBN,IsOnPromotional,ImageId,CategoryId,CreatedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Book book)
        {
            if (id != book.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.bookRepository.Update(book);
                    await this.bookRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BookExists(book.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoryRepository.AllWithDeleted(), "Id", "Type", book.CategoryId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.AllWithDeleted(), "Id", "Id", book.CreatedByUserId);
            this.ViewData["ImageId"] = new SelectList(this.imageRepository.AllWithDeleted(), "Id", "Id", book.ImageId);
            return this.View(book);
        }

        //// GET: Administration/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = await this.bookRepository.All()
                .Include(b => b.Category)
                .Include(b => b.CreatedByUser)
                .Include(b => b.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            return this.View(book);
        }

        //// POST: Administration/Books/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = this.bookRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.bookRepository.Delete(book);
            await this.bookRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BookExists(int id)
        {
            return this.bookRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
