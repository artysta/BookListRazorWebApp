using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using BookListMVCApp.Data;
using BookListMVCApp.Models;
using BookListMVCApp.Models.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookListMVCApp.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext _db;

		public BookController(ApplicationDbContext db)
		{
			_db = db;
		}
		
		public IActionResult Index()
		{
			IQueryable<Book> books = _db.Book;

			books = books.Include("Category");

			return View(books);
		}

		// GET for Create
		public IActionResult Create()
		{
			BookViewModel bookViewModel = new BookViewModel()
			{
				Book = new Book(),
				CategoryList = _db.Category.Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				}),
			};

			return View(bookViewModel);
		}

		// Post for Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(BookViewModel obj)
		{
			if (ModelState.IsValid)
			{
				_db.Book.Add(obj.Book);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		// GET for Edit
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		// POST for Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db.Book.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		// POST for Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			_db.Book.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
