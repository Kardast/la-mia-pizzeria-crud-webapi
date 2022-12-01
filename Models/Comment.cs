using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo username è obbligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo testo è obbligatorio")]
        [StringLength(500, ErrorMessage = "Il messaggio non può essere più lunga di 500 caratteri")]
        [Column(TypeName = "text")]
        public string Text { get; set; }

        //relazione con pizze 1 a n
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set;}
    }
}
