using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LittleMolarApi.Utilities;
public class UtilitiesServices{

    private readonly ApplicationDbContext _context;

    public UtilitiesServices(ApplicationDbContext context){
        _context = context;
    }

    public bool fieldExist(string table, string column, string toCheck){
        
        var entityType = _context.Model.GetEntityTypes()
        .FirstOrDefault(e => e.GetTableName() == table)?.ClrType;

        if (entityType != null)
        {
            // Construir la expresión para consultar el campo
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, column);
            var constant = Expression.Constant(toCheck);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda(equals, parameter);

            // Obtener el DbSet y ejecutar la consulta
            var dbSetType = typeof(DbContext).GetMethod("Set", new Type[] { }).MakeGenericMethod(entityType).Invoke(_context, null);
            var dbSet = dbSetType as IQueryable;
            return (bool)dbSet.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Any", new[] { entityType },
                    dbSet.Expression, lambda
                )
            );
        }
        else
            throw new ArgumentException("Table name not found in the entity model.", nameof(table));
        
    }

    public string hashPassword(string password){
        using(var sha256 = SHA256.Create()){
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach(byte b in hash)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }

}