using System.ComponentModel.DataAnnotations.Schema;

namespace DiseasesDemoApp.Models
{
    public class UniqueEntityData
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
