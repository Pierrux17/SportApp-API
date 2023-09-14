using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PersonProgramDAL
    {
        //[Column("id_person")]
        public int Id_person { get; set; }
        //[Column("id_program")]
        public int Id_program { get; set; }
    }
}
