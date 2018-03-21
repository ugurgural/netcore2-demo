using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetCore2Demo.Entities.Config;

namespace NetCore2Demo.DataRepository.Context
{
    /// <summary>
    /// Entity Framework context service
    /// </summary>
    /// <seealso cref="IContextFactory"/>
    public class ContextFactory : IContextFactory
    {
        private readonly IOptions<ConnectionSettings> connectionOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextFactory"/> class.
        /// </summary>
        /// <param name="connectionOptions">The connection options.</param>
        /// <param name="dataBaseManager">The data base manager.</param>
        public ContextFactory(IOptions<ConnectionSettings> connectionOptions)
        {
            this.connectionOptions = connectionOptions;
        }

        /// <inheritdoc />
        public IDbContext DbContext => new DataContext(GetDataContext().Options);

        private DbContextOptionsBuilder<DataContext> GetDataContext()
        {
            ValidateDefaultConnection();

            var sqlConnectionBuilder = new SqlConnectionStringBuilder(this.connectionOptions.Value.DefaultConnection);

            var contextOptionsBuilder = new DbContextOptionsBuilder<DataContext>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }

        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(this.connectionOptions.Value.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(this.connectionOptions.Value.DefaultConnection));
            }
        }
    }
}