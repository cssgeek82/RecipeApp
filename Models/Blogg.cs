using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Models
{
    public class Blogg
    {
        public int BloggId { get; set; }


        [Required(ErrorMessage = "Du måste ange vem som skrivit blogginlägget")]
        [DisplayName("Författare")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Du måste fylla i rubrik")]
        [DisplayName("Rubrik")]
        [StringLength(75, MinimumLength = 5, ErrorMessage = "Du måste ange mellan 5 och 75 tecken. ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Du måste skriva något i inlägget.")]
        [DisplayName("Blogg-inlägg")]
        public string BloggPost { get; set; }

        [Required(ErrorMessage = "Du måste ange kategori.")]
        [DisplayName("Kategori")]
        public Categories Category { get; set; }

        [DisplayName("Skapad")]
        public DateTime CreatedDate { get; set; }

        public Blogg()
        {
        }

    }


    public enum Categories
    {
        Kosttillskott,
        Träning,
        Träningsprodukter,
        Mental_hälsa, 
        Nyheter,
        Övrigt
    }
}
