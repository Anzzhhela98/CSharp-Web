namespace BookStore.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using BookStore.Data;
    using BookStore.Data.Common.Repositories;
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Contact;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class UserQuestionsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<UserQuestion> userQuestionRepository;
        private readonly ApplicationDbContext applicationDbContext;

        public UserQuestionsController(IDeletableEntityRepository<UserQuestion> userQuestionRepository, ApplicationDbContext applicationDbContext)
        {
            this.userQuestionRepository = userQuestionRepository;
            this.applicationDbContext = applicationDbContext;
        }

        // GET: Administration/UserQuestions
        public async Task<IActionResult> Index()
        {
            var userQuestions = this.userQuestionRepository.AllWithDeleted().OrderBy(x => x.IsAnswer).ToListAsync();
            return View(await userQuestions);
        }

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

        public async Task<IActionResult> Answer(int id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Answer(AdminAnswer adminAnswer)
        {
            var question = this.applicationDbContext.UserQuestions.FirstOrDefault(x => x.Id == adminAnswer.Id);
            question.IsAnswer = true;
            this.applicationDbContext.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
