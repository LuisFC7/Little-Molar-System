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
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        return Convert.ToBase64String(hashBytes);
        
    }

}