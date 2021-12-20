using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eroski.Models
{
    public class Session
    {
       
         [Key]
    
        public string nSeccion { get; set; }
        public int Ticket  {get;set;} = 0;
    }
}