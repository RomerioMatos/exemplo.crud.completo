using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace exemplo.crud.infra.data;

public class DataContexto: DbContext
{
    public DataContexto(DbContextOptions<DataContexto> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }    
}