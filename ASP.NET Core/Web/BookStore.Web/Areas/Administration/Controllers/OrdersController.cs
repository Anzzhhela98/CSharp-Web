namespace BookStore.Web.Areas.Administration
{
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data;
    using BookStore.Data.Common.Repositories;
    using BookStore.Data.Models;
    using BookStore.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class OrdersController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public OrdersController(IDeletableEntityRepository<Order> orderRepository, IDeletableEntityRepository<Book> bookRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.orderRepository = orderRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        // GET: Administration/Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.orderRepository.All().Include(o => o.Book).Include(o => o.CreatedByUser).OrderBy(x => x.Status);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var order = await this.orderRepository.All()
                .Include(o => o.Book)
                .Include(o => o.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        // GET: Administration/Orders/Create
        public IActionResult Create()
        {
            this.ViewData["BookId"] = new SelectList(this.bookRepository.All(), "Id", "Author");
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,Count,Price,City,Address,Number,FullName,Email,StatusPayment,Status,CreatedByUserId,BookId,CreatedOn,ModifiedOn")] Order order)
        {
            if (this.ModelState.IsValid)
            {
                await this.orderRepository.AddAsync(order);
                await this.orderRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["BookId"] = new SelectList(this.bookRepository.All(), "Id", "Author", order.BookId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id", order.CreatedByUserId);
            return this.View(order);
        }

        // GET: Administration/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var order = this.orderRepository.All().FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return this.NotFound();
            }

            this.ViewData["BookId"] = new SelectList(this.bookRepository.All(), "Id", "Author", order.BookId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id", order.CreatedByUserId);
            return this.View(order);
        }

        // POST: Administration/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,Count,Price,City,Address,Number,FullName,Email,StatusPayment,Status,CreatedByUserId,BookId,CreatedOn,ModifiedOn")] Order order)
        {
            if (id != order.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.orderRepository.Update(order);
                    await this.orderRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.OrderExists(order.Id))
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

            this.ViewData["BookId"] = new SelectList(this.bookRepository.All(), "Id", "Author", order.BookId);
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id", order.CreatedByUserId);
            return this.View(order);
        }

        // GET: Administration/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var order = await this.orderRepository.All()
                .Include(o => o.Book)
                .Include(o => o.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        // POST: Administration/Orders/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = this.orderRepository.All().FirstOrDefault(x => x.Id == id);
            this.orderRepository.Delete(order);
            await this.orderRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool OrderExists(int id)
        {
            return this.orderRepository.All().Any(e => e.Id == id);
        }
    }
}
