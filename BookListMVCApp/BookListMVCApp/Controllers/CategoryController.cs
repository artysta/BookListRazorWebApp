using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookListMVCApp.Data;
using BookListMVCApp.Models;

namespace BookListMVCApp.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		
		public IActionResult Index()
		{
			IEnumerable<Category> objList = _db.Category;
			return View(objList);
		}

		// GET for Create
		public IActionResult Create()
		{	
			return View();
		}

		// Post for Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
			_db.Category.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
