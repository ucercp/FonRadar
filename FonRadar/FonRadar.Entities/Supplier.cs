using FonRadar.Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Entities
{
    public class Supplier:IEntity
    {
        public string SupplierTaxId { get; set; } // Tedarikçinin benzersiz vergi numarası
        public string Name { get; set; } 
        public string SurName { get; set; } 
        public string Email { get; set; } 
        public ICollection<Invoice> Invoices { get; set; }
    }
}
