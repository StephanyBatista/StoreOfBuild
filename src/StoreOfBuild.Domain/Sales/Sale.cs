using System;
using System.Collections.Generic;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain.Sales
{
    public class Sale : Entity
    {
        public string ClientName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public decimal Total { get; private set; }
        public SaleItem Item { get; private set; }

        private Sale() { }

        public Sale(string clientname, Product product, int quantity)
        {
            DomainException.When(string.IsNullOrEmpty(clientname), "Client name is required");
            Item = new SaleItem(product, quantity);
            CreatedOn = DateTime.Now;
            ClientName = clientname;
        }
    }
}