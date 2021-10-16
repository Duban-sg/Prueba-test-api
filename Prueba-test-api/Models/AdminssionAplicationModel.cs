using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using System.ComponentModel.DataAnnotations;
using Prueba_test_api.Validators;

namespace Prueba_test_api.Models
{
    public class AdminssionAplicationInpuntModel
    {
        [Required(ErrorMessage = "Proporcione un nombre")]
        [StringLength(20, ErrorMessage = "El nombre es muy largo")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "identificacion invalida.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Proporcione un apellido")]
        [StringLength(20, ErrorMessage = "El apellido es muy largo")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "identificacion invalida.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Proporcione una identificacion")]
        [StringLength(10, ErrorMessage = "El identificacion es muy largo")]
        [RegularExpression(@"^([0-9])*$", ErrorMessage = "identificacion invalida.")]
        public string identification { get; set; }

        [Required(ErrorMessage = "Proporcione una casa")]
        [HouseValidator(ErrorMessage = "Debe proporcionar una casa valida")]
        public string house { get; set; }
        [Required(ErrorMessage = "Proporcione una edad")]
        [StringLength(2, ErrorMessage = "Rango de la edad no permitido")]
        [RegularExpression(@"^([0-9])*$", ErrorMessage = "edad invalida.")]
        public string age { get; set; }

        public AdminssionAplication mapToAdminssionAplication()
        {
            AdminssionAplication newAdminssionAplication = new AdminssionAplication();
            newAdminssionAplication.Name = name;
            newAdminssionAplication.LastName = lastName;
            newAdminssionAplication.Identification = identification;
            newAdminssionAplication.House = house;
            newAdminssionAplication.Age = age;
            return newAdminssionAplication;
        }

    }
    public class AdminssionAplicationViewModel: AdminssionAplicationInpuntModel
    {

        public AdminssionAplicationViewModel() { }

        public AdminssionAplicationViewModel(AdminssionAplication _adminssionAplication) {
            name = _adminssionAplication.Name;
            lastName = _adminssionAplication.LastName;
            identification = _adminssionAplication.Identification;
            house = _adminssionAplication.House;
            age = _adminssionAplication.Age;
        }
    }
}
