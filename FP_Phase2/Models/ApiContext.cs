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
    }
}