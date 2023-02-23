using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo email è obbligatorio")]
        [EmailAddress(ErrorMessage = "La mail deve avere un formato corretto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo username è obbligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo testo è obbligatorio")]
        [StringLength(500, ErrorMessage = "Il messaggio non può essere più lunga di 500 caratteri")]
        [Column(TypeName = "text")]
        public string Text { get; set; }
    }
}
