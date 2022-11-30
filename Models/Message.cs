using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [EmailAddress(ErrorMessage = "La mail deve avere un formato corretto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(500, ErrorMessage = "Il messaggio non può essere più lunga di 500 caratteri")]
        [Column(TypeName = "text")]
        public string Text { get; set; }

        //public Message(string email, string userName, string title, string text)
        //{
        //    Email= email;
        //    UserName= userName;
        //    Title= title;
        //    Text= text;
        //}
    }
}
