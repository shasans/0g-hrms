using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Models
{
    public class Budget
    {

        public int ID { get; set; }

        [Display(Name = "Budget Name")]
        public string Name { get; set; }

        [Display(Name = "Amount [AED]")]
        public decimal Amount { get; set; }

        [Display(Name = "Remaining Amount [AED]")]
        public decimal Remaining { get; set; }

        /* public decimal PayrollBudget { get; set; } / make payroll19budget and payroll20budget. in budgets page, when select payroll budget,
         *                                              ask to select a year (2019 or 2020).

         public decimal ExpensesBudget { get; set; } / make expenses budget, ask in receipt invoices if its expense or contract, subtract amount w all expenses

         public decimal ContractBudget { get; set; } / make contract budget, ask in receipt invoices if its expense or contract

         public decimal ReceivingBudget { get; set; } / doneeee?, add all payment invoices
         */

      //  public Jan19Payroll Jan19Payroll { get; set; }

        public string OwnerID { get; set; }

    }
}
