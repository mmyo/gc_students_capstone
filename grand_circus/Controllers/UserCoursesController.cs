using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using grand_circus.Models;
using Microsoft.AspNetCore.Http;

namespace grand_circus.Controllers
{
    public class UserCoursesController : Controller
    {
        private readonly ISession _session;
        private readonly GrandCircusContext _context;

        public UserCoursesController(GrandCircusContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;

        }

        // GET: UserCourses
        public async Task<IActionResult> Index()
        {
            var grandCircusContext = _context.UserCourses.Include(u => u.Course).Include(u => u.User);
            return View(await grandCircusContext.ToListAsync());
        }

        // GET: UserCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses
                .Include(u => u.Course)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserCoursesId == id);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // GET: UserCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: UserCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserCoursesId,UserId,CourseId,Semester,Grade")] UserCourses userCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", userCourses.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userCourses.UserId);
            return View(userCourses);
        }

        // GET: UserCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses.FindAsync(id);
            if (userCourses == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", userCourses.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userCourses.UserId);
            return View(userCourses);
        }

        // POST: UserCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserCoursesId,UserId,CourseId,Semester,Grade")] UserCourses userCourses)
        {
            if (id != userCourses.UserCoursesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCoursesExists(userCourses.UserCoursesId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", userCourses.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userCourses.UserId);
            return View(userCourses);
        }

        // GET: UserCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses
                .Include(u => u.Course)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserCoursesId == id);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // POST: UserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCourses = await _context.UserCourses.FindAsync(id);
            _context.UserCourses.Remove(userCourses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCoursesExists(int id)
        {
            return _context.UserCourses.Any(e => e.UserCoursesId == id);
        }

        public IActionResult SearchCoursesByUserId(int arg)
        {
            _session.SetInt32("currentUserId", arg);

            var userId = _session.GetInt32("currentUserId");
            var grandCircusContext = _context.UserCourses.Include(u => u.Course).Where(x => x.UserId == _session.GetInt32("userId"));

            var viewCourseList = new List<ViewCourses>();
            foreach (var course in grandCircusContext)
            {
                string courseName = course.Course.Name;
                string semester = course.Semester;
                double grade = course.Grade;
                double max = 0;
                double min = 4;
                double total = 0;
                double average;

                var coursesToQuery = _context.UserCourses.Where(u => u.Course.Name == courseName);
                foreach (var c in coursesToQuery)
                {
                    if (max < c.Grade)
                    {
                        max = c.Grade;
                    }
                    if (min > c.Grade)
                    {
                        min = c.Grade;
                    }
                    total += c.Grade;
                }

                average = total / coursesToQuery.Count();

                viewCourseList.Add(new ViewCourses(courseName, semester, grade, max, min, average));
            }

            var viewCourseContext = viewCourseList.AsQueryable();

            var user = _context.User.FirstOrDefault(x => x.UserId == arg) as User;
            ViewData["userFirstName"] = user.FirstName;

            return View("DisplayCoursesByUserId", viewCourseContext);
        }

        public IActionResult DisplayCoursesByUserId(List<UserCourses> courseList)
        {
            return View(courseList);
        }

        public async Task<IActionResult> AddCourse()
        {
            var userId = _session.GetInt32("currentUserId");
            return View(await _context.Course.ToListAsync());
        }

        public IActionResult Enroll(int? id)
        {
            var userId = _session.GetInt32("currentUserId");
            var userCourses = new UserCourses();
            var course = _context.Course.Where(x => x.CourseId == id).FirstOrDefault();
            userCourses.CourseId = course.CourseId;
            userCourses.UserId = (int)userId;
            userCourses.Semester = "Summer";
            _context.UserCourses.Add(userCourses);
            _context.SaveChanges();
            return RedirectToAction("SearchCoursesByUserId", new { arg = userId });
        }
    }
}
