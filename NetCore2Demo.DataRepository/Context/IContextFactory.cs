namespace NetCore2Demo.DataRepository.Context
{
    public interface IContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        IDbContext DbContext { get; }
    }
}