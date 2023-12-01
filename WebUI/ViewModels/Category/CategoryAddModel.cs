using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Category
{
    public class CategoryAddModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategori adı zorunlu!")]
        [MinLength(3,ErrorMessage ="En az 3 karakter olmalı!")]
        [MaxLength(50,ErrorMessage ="En fazla 50 karakter olmalı!")]
        public string CategoryName { get; set; }
        public bool Status { get; set; } = true;
    }
}
