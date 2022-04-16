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
    public class ImagesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;


        public ImagesController(IDeletableEntityRepository<Image> imageRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.imageRepository = imageRepository;
            this.userRepository = userRepository;
        }

        // GET: Administration/Images
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.imageRepository.AllWithDeleted().Include(i => i.CreatedByUser);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Images/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var image = await this.imageRepository.AllWithDeleted()
                .Include(i => i.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return this.NotFound();
            }

            return this.View(image);
        }

        // GET: Administration/Images/Create
        public IActionResult Create()
        {
            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageUrl,Extension,CreatedByUserId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Image image)
        {
                image.Id = Guid.NewGuid().ToString();
            if (this.ModelState.IsValid)
            {
                await this.imageRepository.AddAsync(image);
                await this.imageRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.All(), "Id", "Id", image.CreatedByUserId);
            return this.View(image);
        }

        // GET: Administration/Images/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var image = this.imageRepository.All().FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                return this.NotFound();
            }

            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.AllWithDeleted(), "Id", "Id", image.CreatedByUserId);
            return this.View(image);
        }

        // POST: Administration/Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ImageUrl,Extension,CreatedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Image image)
        {
            if (id != image.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.imageRepository.Update(image);
                    await this.imageRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ImageExists(image.Id))
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

            this.ViewData["CreatedByUserId"] = new SelectList(this.userRepository.AllWithDeleted(), "Id", "Id", image.CreatedByUserId);
            return this.View(image);
        }

        // GET: Administration/Images/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var image = await this.imageRepository.All()
                .Include(i => i.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return this.NotFound();
            }

            return this.View(image);
        }

        // POST: Administration/Images/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var image = this.imageRepository.All().FirstOrDefault(x => x.Id == id);
            this.imageRepository.Delete(image);
            await this.imageRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ImageExists(string id)
        {
            return this.imageRepository.All().Any(e => e.Id == id);
        }
    }
}
