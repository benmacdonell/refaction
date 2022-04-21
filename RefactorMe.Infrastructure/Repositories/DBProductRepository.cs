using RefactorMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RefactorMe.Infrastructure.Repositories
{
    // NB. a better alternative here might be to use Entity Framework, but
    // I've decided to use the existing SQL commands (with some additional
    // protection against injection, and separation of concerns) for time
    // reasons.
    //
    // This might also be the better approach if we have an existing prod
    // database that we're coding against, and want to have confidence we're
    // running the same SQL queries as before. The approaches chosen would
    // depend on factors like available time, etc.
    public class DBProductRepository : IProductRepository
    {
        string _connectionString;

        public DBProductRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string must be specified.");
            }

            _connectionString = connectionString;
        }

        public IEnumerable<Guid> GetProducts()
        {
            var productIds = new List<Guid>();
            string query = "select id from product;";
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(query, connection);

                try
                {
                    var rdr = cmd.ExecuteReader();
                    if (!rdr.Read())
                    {
                        var id = Guid.Parse(rdr["id"].ToString());
                        productIds.Add(id);
                    }
                }
                catch (Exception)
                {
                    // This may not ideal because it swallows the exception.
                    // We probably want to log/alert in this case, depending on requirements.
                    return productIds;
                }

                return productIds;
            }
        }

        public IEnumerable<Guid> GetProducts(string name)
        {
            var matchingProductIds = new List<Guid>();

            if (string.IsNullOrEmpty(name))
            {
                return matchingProductIds;
            }

            string query = "select id from product where lower(name) like @Name;";
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@Name", SqlDbType.Text);
                cmd.Parameters["@Name"].Value = name;

                try
                {
                    var rdr = cmd.ExecuteReader();
                    if (!rdr.Read())
                    {
                        var id = Guid.Parse(rdr["id"].ToString());
                        matchingProductIds.Add(id);
                    }
                }
                catch (Exception)
                {
                    return matchingProductIds;
                }
            }

            return matchingProductIds;
        }

        public Product GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Guid id, Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            throw new NotImplementedException();
        }

        public ProductOption GetOption(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertOption(Guid productId, ProductOption option)
        {
            throw new NotImplementedException();
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            throw new NotImplementedException();
        }

        public void DeleteOption(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
