using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.NameTranslation;

namespace HotFi.App.Extensions
{
    public static class DbContextExtension
    {
        public static void MapForPostgreSql(this DbContext context, string schemaName, ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = MapName(entity.GetTableName());
                entity.SetTableName(tableName);
                entity.SetSchema(schemaName);
                foreach (var property in entity.GetProperties())
                {
                    var columnName = MapName(property.GetColumnName(StoreObjectIdentifier.Table(tableName, schemaName)));
                    property.SetColumnName(columnName);
                }
            }
        }

        private static string MapName(string nonMappedName)
        {
            var mapper = new NpgsqlSnakeCaseNameTranslator();
            return mapper.TranslateMemberName(nonMappedName);
        }
    }
}