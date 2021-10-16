using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class AdminssionAplication
    {
        [Key]
        public int AdminssionAplicationId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Identification { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string Age { get; set; }

        [Column(TypeName = "varchar(10)")]

        public string House { get; set; }


        public void CompareOrUpdate(AdminssionAplication _newAdminssionAplication){
            this.Name = (_newAdminssionAplication.Name == this.Name)?this.Name:_newAdminssionAplication.Name;
            this.LastName = (_newAdminssionAplication.LastName == this.LastName)?this.LastName:_newAdminssionAplication.LastName;
            this.Age = (_newAdminssionAplication.Age == this.Age)?this.Age:_newAdminssionAplication.Age;
            this.House = (_newAdminssionAplication.House == this.House)?this.House:_newAdminssionAplication.House;
        }
      
    }
}
