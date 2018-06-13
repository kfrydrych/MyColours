using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Domain.Products
{
    public class TransactionType
    {
        private TransactionType()
        {
        }

        private TransactionType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public static TransactionType Intake => new TransactionType(1, "Intake");
        public static TransactionType Disposal => new TransactionType(2, "Disposal");
        public static TransactionType CreditNote => new TransactionType(3, "Credit Note");
    }
}