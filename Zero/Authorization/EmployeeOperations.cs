using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Authorization
{
    public class EmployeeOperations
    {
        public static OperationAuthorizationRequirement Create =
               new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
    }

    public class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";

        public static readonly string EmployeeAdministratorsRole =
                                                              "EmployeeAdministrators";
        public static readonly string EmployeeManagersRole = "EmployeeManagers";

        public static readonly string Jan19PayrollAdministratorsRole =
                                                              "Jan19PayrollAdministrators";
        public static readonly string Jan19PayrollManagersRole = "Jan19PayrollManagers";
        public static readonly string Feb19PayrollAdministratorsRole =
                                                              "Feb19PayrollAdministrators";
        public static readonly string Feb19PayrollManagersRole = "Feb19PayrollManagers";
        public static readonly string Mar19PayrollAdministratorsRole =
                                                              "Mar19PayrollAdministrators";
        public static readonly string Mar19PayrollManagersRole = "Mar19PayrollManagers";
        public static readonly string Apr19PayrollAdministratorsRole =
                                                              "Apr19PayrollAdministrators";
        public static readonly string Apr19PayrollManagersRole = "Apr19PayrollManagers";
        public static readonly string May19PayrollAdministratorsRole =
                                                              "May19PayrollAdministrators";
        public static readonly string May19PayrollManagersRole = "May19PayrollManagers";
        public static readonly string Jun19PayrollAdministratorsRole =
                                                              "Jun19PayrollAdministrators";
        public static readonly string Jun19PayrollManagersRole = "Jun19PayrollManagers";
        public static readonly string Jul19PayrollAdministratorsRole =
                                                              "Jul19PayrollAdministrators";
        public static readonly string Jul19PayrollManagersRole = "Jul19PayrollManagers";
        public static readonly string Aug19PayrollAdministratorsRole =
                                                              "Aug19PayrollAdministrators";
        public static readonly string Aug19PayrollManagersRole = "Aug19PayrollManagers";
        public static readonly string Sep19PayrollAdministratorsRole =
                                                              "Sep19PayrollAdministrators";
        public static readonly string Sep19PayrollManagersRole = "Sep19PayrollManagers";
        public static readonly string Oct19PayrollAdministratorsRole =
                                                              "Oct19PayrollAdministrators";
        public static readonly string Oct19PayrollManagersRole = "Oct19PayrollManagers";
        public static readonly string Nov19PayrollAdministratorsRole =
                                                              "Nov19PayrollAdministrators";
        public static readonly string Nov19PayrollManagersRole = "Nov19PayrollManagers";
        public static readonly string Dec19PayrollAdministratorsRole =
                                                              "Dec19PayrollAdministrators";
        public static readonly string Dec19PayrollManagersRole = "Dec19PayrollManagers";

        public static readonly string Jan20PayrollAdministratorsRole =
                                                              "Jan20PayrollAdministrators";
        public static readonly string Jan20PayrollManagersRole = "Jan20PayrollManagers";
        public static readonly string Feb20PayrollAdministratorsRole =
                                                              "Feb20PayrollAdministrators";
        public static readonly string Feb20PayrollManagersRole = "Feb20PayrollManagers";
        public static readonly string Mar20PayrollAdministratorsRole =
                                                              "Mar20PayrollAdministrators";
        public static readonly string Mar20PayrollManagersRole = "Mar20PayrollManagers";
        public static readonly string Apr20PayrollAdministratorsRole =
                                                              "Apr20PayrollAdministrators";
        public static readonly string Apr20PayrollManagersRole = "Apr20PayrollManagers";
        public static readonly string May20PayrollAdministratorsRole =
                                                              "May20PayrollAdministrators";
        public static readonly string May20PayrollManagersRole = "May20PayrollManagers";
        public static readonly string Jun20PayrollAdministratorsRole =
                                                              "Jun20PayrollAdministrators";
        public static readonly string Jun20PayrollManagersRole = "Jun20PayrollManagers";
        public static readonly string Jul20PayrollAdministratorsRole =
                                                              "Jul20PayrollAdministrators";
        public static readonly string Jul20PayrollManagersRole = "Jul20PayrollManagers";
        public static readonly string Aug20PayrollAdministratorsRole =
                                                              "Aug20PayrollAdministrators";
        public static readonly string Aug20PayrollManagersRole = "Aug20PayrollManagers";
        public static readonly string Sep20PayrollAdministratorsRole =
                                                              "Sep20PayrollAdministrators";
        public static readonly string Sep20PayrollManagersRole = "Sep20PayrollManagers";
        public static readonly string Oct20PayrollAdministratorsRole =
                                                              "Oct20PayrollAdministrators";
        public static readonly string Oct20PayrollManagersRole = "Oct20PayrollManagers";
        public static readonly string Nov20PayrollAdministratorsRole =
                                                              "Nov20PayrollAdministrators";
        public static readonly string Nov20PayrollManagersRole = "Nov20PayrollManagers";
        public static readonly string Dec20PayrollAdministratorsRole =
                                                              "Dec20PayrollAdministrators";
        public static readonly string Dec20PayrollManagersRole = "Dec20PayrollManagers";



        public static readonly string PaymentInvoiceAdministratorsRole =
                                                              "PaymentInvoiceAdministrators";
        public static readonly string PaymentInvoiceManagersRole = "PaymentInvoiceManagers";

        public static readonly string ReceiptInvoiceAdministratorsRole =
                                                              "ReceiptInvoiceAdministrators";
        public static readonly string ReceiptInvoiceManagersRole = "ReceiptInvoiceManagers";


        public static readonly string BudgetAdministratorsRole =
                                                              "BudgetAdministrators";
        public static readonly string BudgetManagersRole = "BudgetManagers";

        public static readonly string ExpenseBudgetAdministratorsRole =
                                                              "ExpenseBudgetAdministrators";
        public static readonly string ExpenseBudgetManagersRole = "ExpenseBudgetManagers";

        public static readonly string ContractBudgetAdministratorsRole =
                                                              "ContractBudgetAdministrators";
        public static readonly string ContractBudgetManagersRole = "ContractBudgetManagers";

        public static readonly string Payroll19BudgetAdministratorsRole =
                                                              "Payroll19BudgetAdministrators";
        public static readonly string Payroll19BudgetManagersRole = "Payroll19BudgetManagers";

        public static readonly string Payroll20BudgetAdministratorsRole =
                                                             "Payroll20BudgetAdministrators";
        public static readonly string Payroll20BudgetManagersRole = "Payroll20BudgetManagers";

        public static readonly string ReceivingBudgetAdministratorsRole =
                                                             "ReceivingBudgetAdministrators";
        public static readonly string ReceivingBudgetManagersRole = "ReceivingBudgetManagers";

    }
}