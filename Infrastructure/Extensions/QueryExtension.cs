using Infrastructure.Dto.Filters;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class QueryExtension
    {
        public static string ToSql<T>(this IQueryable<T> query)
        {
            var enumerator = query.Provider
                .Execute<IEnumerable<T>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator
                .Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache
                .Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache
                .Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);

            string sql = command.CommandText;
            return sql;
        }

        public static IQueryable<Product> ApplyFilter(this IQueryable<Product> query, Filter filter)
        {
            if (filter.CompanyGuids != null && filter.CompanyGuids.Any())
                query = query.Where(p => filter.CompanyGuids.Contains(p.Company.Guid));
            if (filter.ProviderIds != null && filter.ProviderIds.Any())
                query = query.Where(p => filter.ProviderIds.Contains(p.Company.Provider.Id));
            if (filter.From.HasValue)
                query = query.Where(p => p.LoadTime >= filter.From);
            if (filter.To.HasValue)
                query = query.Where(p => p.LoadTime <= filter.To);
            if (filter.ProductNames != null && filter.ProductNames.Any())
                query = query.Where(p => filter.ProductNames.Contains(p.Name));

            return query;
        }

        public static IQueryable<Company> ApplyFilter(this IQueryable<Company> query, Filter filter)
        {
            if (filter.CompanyGuids != null && filter.CompanyGuids.Any())
                query = query.Where(c => filter.CompanyGuids.Contains(c.Guid));
            if (filter.ProviderIds != null && filter.ProviderIds.Any())
                query = query.Where(c => filter.ProviderIds.Contains(c.Provider.Id));

            return query;
        }

        public static IQueryable<Provider> ApplyFilter(this IQueryable<Provider> query, Filter filter)
        {
            //if (filter.ProviderNames != null && filter.ProviderNames.Any())
            //    query = query.Where(p => filter.ProviderNames.Contains(p.Name));
            //if (filter.CompanyGuids != null && filter.CompanyGuids.Any())
            //{
            //    query = query.Where(p => filter.CompanyGuids.Contains(p.Companies.Guid)));
            //    //if (filter.ProductNames != null && filter.ProductNames.Any())
            //    //    query = temp.ThenInclude(c => c.Products.Where(p => filter.ProductNames.Contains(p.Name))).AsQueryable();
            //    //else
            //        query = temp.AsQueryable();
            //}
            return query;
        }

        private static object Private(this object obj, string privateField) =>
            obj?.GetType()
            .GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(obj);
        private static T Private<T>(this object obj, string privateField) =>
            (T)obj?
            .GetType()
            .GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(obj);
    }
}

