using System;
using System.Collections.Generic;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models {
  public class Category : IUniqueIdentifier {
    public virtual Guid UuId { get; set; }
    public virtual Guid ParentUuId { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual string KeyWords { get; set; }
    public virtual bool IsDeleted { get; set; }

    private IList<Product> _products;
    public virtual IList<Product> Products {
      get => _products ?? (_products = new List<Product>());
      set => _products = value;
    }
  }
}