﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)] //Transforma em um link de email
        public string Email { get; set; }
        //Customiza o que aparece na página
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)] // Formatação para só aparecer data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]// dia/mes/ano
        public DateTime BirthDate { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) { Sales.Add(sr); }

        public void RemoveSales(SalesRecord sr) { Sales.Remove(sr); }

        public double TotalSales(DateTime initial, DateTime final) 
        {
            //Utilizando LINQ
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
