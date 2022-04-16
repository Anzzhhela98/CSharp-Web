namespace BookStore.Web.Areas.Administration
{
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data;
    using BookStore.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class UserQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/UserQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserQuestions.ToListAsync());
        }

        // GET: Administration/UserQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return NotFound();
            }

            return View(userQuestion);
        }

        // GET: Administration/UserQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/UserQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Question,Email,Phone,OrderNumber,CreatedOn,ModifiedOn,IsDeleted,DeletedOn,Id")] UserQuestion userQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userQuestion);
        }

        // GET: Administration/UserQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions.FindAsync(id);
            if (userQuestion == null)
            {
                return NotFound();
            }
            return View(userQuestion);
        }

        // POST: Administration/UserQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Question,Email,Phone,OrderNumber,CreatedOn,ModifiedOn,IsDeleted,DeletedOn,Id")] UserQuestion userQuestion)
        {
            if (id != userQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserQuestionExists(userQuestion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userQuestion);
        }

        // GET: Administration/UserQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return NotFound();
            }

            return View(userQuestion);
        }

        // POST: Administration/UserQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userQuestion = await _context.UserQuestions.FindAsync(id);
            _context.UserQuestions.Remove(userQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserQuestionExists(int id)
        {
            return _context.UserQuestions.Any(e => e.Id == id);
        }
    }
}
