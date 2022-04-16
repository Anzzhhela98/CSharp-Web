namespace BookStore.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Common.Repositories;
    using BookStore.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class UserQuestionsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<UserQuestion> userQuestionRepository;

        public UserQuestionsController(IDeletableEntityRepository<UserQuestion> userQuestionRepository)
        {
            this.userQuestionRepository = userQuestionRepository;
        }

        // GET: Administration/UserQuestions
        public async Task<IActionResult> Index() => View(await this.userQuestionRepository.AllWithDeleted().ToListAsync());

        // GET: Administration/UserQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userQuestion = await this.userQuestionRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return this.NotFound();
            }

            return this.View(userQuestion);
        }

        // GET: Administration/UserQuestions/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/UserQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Email,Phone,OrderNumber,CreatedOn,ModifiedOn")] UserQuestion userQuestion)
        {
            if (this.ModelState.IsValid)
            {
                await this.userQuestionRepository.AddAsync(userQuestion);
                await this.userQuestionRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(userQuestion);
        }

        // GET: Administration/UserQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userQuestion = await this.userQuestionRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (userQuestion == null)
            {
                return this.NotFound();
            }

            return this.View(userQuestion);
        }

        // POST: Administration/UserQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Email,Phone,OrderNumber,CreatedOn,ModifiedOn")] UserQuestion userQuestion)
        {
            if (id != userQuestion.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.userQuestionRepository.Update(userQuestion);
                    await this.userQuestionRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.UserQuestionExists(userQuestion.Id))
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

            return this.View(userQuestion);
        }

        // GET: Administration/UserQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userQuestion = await this.userQuestionRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return this.NotFound();
            }

            return this.View(userQuestion);
        }

        // POST: Administration/UserQuestions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userQuestion = await this.userQuestionRepository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == id);
            this.userQuestionRepository.Delete(userQuestion);
            await this.userQuestionRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool UserQuestionExists(int id)
        {
            return this.userQuestionRepository.All().Any(e => e.Id == id);
        }
    }
}
