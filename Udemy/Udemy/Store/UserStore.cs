using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Udemy.Models;

namespace Udemy.Store
{
    public class UserStore : IUserStore<UserModel>, IUserPasswordStore<UserModel>
    {
        public async Task<IdentityResult> CreateAsync(UserModel user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnecton())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("INSERT INTO ")
                    .Append("Users( ")
                    .Append("[id],")
                    .Append("[UserName],")
                    .Append("[NormalizedUserName],")
                    .Append("[PasswordHash]")
                    .Append(" ) VALUES( ")
                    .Append("@id,")
                    .Append("@userName,")
                    .Append("@normalizedUserName,")
                    .Append("@passwordHash")
                    .Append(" )");

                await connection.ExecuteAsync(sql.ToString(), new
                {
                    id = user.Id,
                    userName = user.UserName,
                    normalizedUserName = user.NormalizedUserName,
                    passwordHash = user.PasswordHash
                });
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserModel user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnecton())
            {
                await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @id", new
                {
                    id = user.Id
                });
            }

            return IdentityResult.Success;
        }

        public void Dispose()
        {
            
        }

        public async Task<UserModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnecton())
            {
                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                    "SELECT * FROM Users WHERE Id = @id",
                    new { id = userId });
            }
        }

        public async Task<UserModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnecton())
            {
                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                    "SELECT * FROM Users WHERE NormalizedUserName = @name",
                    new { name = normalizedUserName });
            }
        }

        public Task<string> GetNormalizedUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public static DbConnection GetOpenConnecton()
        {
            var connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Udemy;Data Source=DESKTOP-3QAH16R\\SQLEXPRESS");

            connection.Open();

            return connection;
        }

        public Task<string> GetUserIdAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(UserModel user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(UserModel user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserModel user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnecton())
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE ")
                    .Append("Users ")
                    .Append("SET ")
                    .Append("[Id] = @id, ")
                    .Append("[UserName] = @userName, ")
                    .Append("[NormalizedUserName] = @normalizedUserName, ")
                    .Append("[PasswordHash] = @passwordHash ")
                    .Append("WHERE ")
                    .Append("[Id] = @id");

                await connection.ExecuteAsync(sql.ToString(), new
                {
                    id = user.Id,
                    userName = user.UserName,
                    normalizedUserName = user.NormalizedUserName,
                    passwordHash = user.PasswordHash
                });
            }

            return IdentityResult.Success;
        }

        public Task SetPasswordHashAsync(UserModel user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}
