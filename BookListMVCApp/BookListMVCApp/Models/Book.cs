﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookListMVCApp.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		[Required]

		public string Name { get; set; }
		[DisplayName("Number of pages")]
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Numer of book pages must be greater than 0!")]
		public int NumberOfPages { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
