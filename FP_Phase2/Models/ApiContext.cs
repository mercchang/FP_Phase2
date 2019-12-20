using FP_Phase2.Enums;
using FP_Phase2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FP_Phase2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiContext()
            : base("APIConnection")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ApiContext Create()
        {
            return new ApiContext();
        }

        //SQL Get Household======================================================
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Household> GetHousehold(int id)
        {
            return await Database.SqlQuery<Household>("GetHousehold @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new Household
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        public async Task<int> AddHousehold(string name, string greeting)
        {
            return Database.ExecuteSqlCommand("AddHousehold @name, @greeting",
                new SqlParameter("name", name),
                new SqlParameter("greeting", greeting));
        }

        /// <summary>
        /// Edit details for a household.
        /// </summary>
        /// <param name="id">Household ID</param>
        /// <param name="name">Household Name</param>
        /// <param name="greeting">Household Greeting</param>
        /// <returns></returns>
        public int EditHousehold(int id, string name, string greeting)
        {
            return Database.ExecuteSqlCommand("EditHousehold @id, @name, @greeting",
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("greeting", greeting));
        }

        /// <summary>
        /// Deletes a household from the database
        /// </summary>
        /// <param name="id">Household ID</param>
        /// <returns></returns>
        public int DeleteHousehold(int id)
        {
            return Database.ExecuteSqlCommand("DeleteHousehold @id",
                new SqlParameter("id", id));
        }

        //SQL Get Accounts==========================================================
        /// <summary>
        /// Gets Details for all Bank Accounts of Specific Household
        /// </summary>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        public async Task<List<BankAccount>> GetBankAccounts(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccounts @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetBankAccountDetails(int bankAccountId, int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @acctId, @hhId",
                new SqlParameter("acctId", bankAccountId),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new bank account to a household
        /// </summary>
        /// <param name="householdId">Household Id</param>
        /// <param name="ownerId">Owner Id</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="name">Name of Account</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="lowBalance">Low Balance Warning</param>
        /// <returns></returns>
        public int AddBankAccount(int householdId, string ownerId, AccountType accountType, string name, float startingBalance, float lowBalance)
        {
            var accountTypeValue = (int)accountType;

            return Database.ExecuteSqlCommand("AddBankAccount @householdId, @ownerId, @accountType, @name, @startingBalance, @lowBalance",
                new SqlParameter("householdId", householdId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("accountType", accountType),
                new SqlParameter("name", name),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("lowBalance", lowBalance));
        }

        /// <summary>
        /// Edit details for a bank account
        /// </summary>
        /// <param name="bankId">Bank Account ID</param>
        /// <param name="householdId">Household ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="name">Name of Account</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="currentBalance">Current Balance</param>
        /// <param name="lowBalance">Low Balance Warning</param>
        /// <returns></returns>
        public int EditBankAccount(int bankId, int householdId, string ownerId, AccountType accountType, string name, float startingBalance, float currentBalance, float lowBalance)
        {
            var accountTypeValue = (int)accountType;

            return Database.ExecuteSqlCommand("EditBankAccount @bankId, @householdId, @ownerId, @accountType, @name, @startingBalance, @currentBalance, @lowBalance",
                new SqlParameter("bankId", bankId),
                new SqlParameter("householdId", householdId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("accountType", accountType),
                new SqlParameter("name", name),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("currentBalance", currentBalance),
                new SqlParameter("lowBalance", lowBalance));
        }

        /// <summary>
        /// Delete a Bank Account from the database
        /// </summary>
        /// <param name="bankId">Bank Account ID</param>
        /// <param name="hhId">Household ID</param>
        /// <returns></returns>
        public int DeleteBankAccount(int bankId, int hhId)
        {
            return Database.ExecuteSqlCommand("DeleteBankAccount @bankId, @hhId",
                new SqlParameter("bankId", bankId),
                new SqlParameter("hhId", hhId));
        }

        //SQL get transactions====================================================
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactions").ToListAsync();
        }

        /// <summary>
        /// Get transactions for a specific bank account
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByBankAccount(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsByBankAccount @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bId"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int id, int bId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id, @bId",
                new SqlParameter("id", id),
                new SqlParameter("bId", bId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new Transaction
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="memo"></param>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<int> AddTransaction(int bankId, int budgetItemId, string ownerId, string memo, TransactionType transactionType, float amount)
        {
            var transactionTypeValue = (int)transactionType;

            return Database.ExecuteSqlCommand("AddTransaction @bankId, @budgetItemId, @ownerId, @memo, @transactionType, @amount",
                new SqlParameter("bankId", bankId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("memo", memo),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="memo"></param>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int EditTransaction(int bankId, int budgetItemId, string ownerId, string memo, TransactionType transactionType, float amount)
        {
            var transactionTypeValue = (int)transactionType;

            return Database.ExecuteSqlCommand("EditTransaction @bankId, @budgetItemId, @ownerId, @memo, @transactionType, @amount",
                new SqlParameter("bankId", bankId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("memo", memo),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public int DeleteTransaction(int bankId, int budgetItemId, string ownerId)
        {
            return Database.ExecuteSqlCommand("DeleteTransaction @bankId, @budgetItemId, @ownerId",
                new SqlParameter("bankId", bankId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId));
        }

        //SQL get budgets==========================================================
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Budget>> GetAllBudgets()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgets").ToListAsync();
        }

        /// <summary>
        /// Gets details for a specific budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetDetails(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetsByHousehold(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsByHousehold @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId">Household Id</param>
        /// <param name="ownerId">Owner Id</param>
        /// <param name="name">Name of Budget</param>
        /// <param name="targetAmount">Target Amount</param>
        /// <returns></returns>
        public async Task<int> AddBudget(int hhId, string ownerId, string name, float targetAmount)
        {
            return Database.ExecuteSqlCommand("AddBudget @hhId, @ownerId, @name, @targetAmount",
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("targetAmount", targetAmount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="hhId"></param>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="targetAmount"></param>
        /// <returns></returns>
        public int EditBudget(int budgetId, int hhId, string ownerId, string name, float targetAmount)
        {
            return Database.ExecuteSqlCommand("EditBudget @budgetId, @hhId, @ownerId, @name, @targetAmount",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("targetAmount", targetAmount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public int DeleteBudget(int budgetId, int hhId)
        {
            return Database.ExecuteSqlCommand("DeleteBudget @budgetId, @hhId",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("hhId", hhId));
        }


        //SQL Get budget items=====================================================
        /// <summary>
        /// Gets Details for all Budget Items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Budget>> GetAllBudgetItems()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetItems").ToListAsync();
        }

        /// <summary>
        /// Gets Details for BudgetItems for a specific Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetItemsByBudget(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetItemsByBudget @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// Gets details for a specific budget item
        /// </summary>
        /// <param name="id">Budget Item Id</param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetItemDetails(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetItemDetails @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="name"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <returns></returns>
        public int AddBudgetItem(int budgetId, string name, float targetAmount, float currentAmount)
        {
            return Database.ExecuteSqlCommand("AddBudgetItem @budgetId, @name, @targetAmount, @currentAmount",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("name", name),
                new SqlParameter("targetAmount", targetAmount),
                new SqlParameter("currentAmount", currentAmount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="name"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <returns></returns>
        public int EditBudgetItem(int budgetId, int budgetItemId, string name, float targetAmount, float currentAmount)
        {
            return Database.ExecuteSqlCommand("EditBudgetItem @budgetId, @budgetItemId, @name, @targetAmount, @currentAmount",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("name", name),
                new SqlParameter("targetAmount", targetAmount),
                new SqlParameter("currentAmount", currentAmount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="budgetItemId"></param>
        /// <returns></returns>
        public int DeleteBudgetItem(int budgetId, int budgetItemId)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItem @budgetId, @budgetItemId",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("budgetItemId", budgetItemId));
        }

    }
}