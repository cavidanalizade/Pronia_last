﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProniaAdmin.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, StringLength(25, ErrorMessage = "Uzunluq maxsimum 25 olmalidir")]
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        [StringLength(maximumLength: 100)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
