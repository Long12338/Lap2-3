using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ChiemHoangLong.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;


        public Book()
        {

        }

      

        public Book(int id, string title, string author, string image_cover)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Image_cover = image_cover;
        }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề không được vượt quá 250 kí tự")]
        [Display(Name = "Tiêu đề")]
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Image_cover { get => image_cover; set => image_cover = value; }
    }
}
    