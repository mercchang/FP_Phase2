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
        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        public int AddHousehold(string name, string greeting)
        {
            return Database.ExecuteSqlCommand("AddHousehold @name, @greeting",
                new SqlParameter("name", name),
                new SqlParameter("greeting", greeting));
        }

        //SQL Get Accounts==========================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<BankAccount>> GetBankAccounts(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountsByHousehold @hhId",
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

        //SQL get transactions====================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactions").ToListAsync();
            //return await Database.SqlQuery<Transaction>("GetAllTransactions @id, @hhId",
            //    new SqlParameter("id", id),
            //    new SqlParameter("hhId", hhId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int id, float amount, string memo)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id, @amount, @memo",
                new SqlParameter("transactionId", id),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo)).FirstOrDefaultAsync();
        }

        //SQL get budgets==========================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgets(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetsByHousehold(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsByHousehold @hhId",
                new SqlParameter("householdId", hhId)).ToListAsync();
        }

    }
}