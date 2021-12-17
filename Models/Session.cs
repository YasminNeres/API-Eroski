using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eroski.Models
{
    public class Session
    {
       
         [Key]
       public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public int Valor {get;set;} = 0;
    }
}