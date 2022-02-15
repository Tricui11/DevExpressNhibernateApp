using System.Collections.Generic;

namespace StoreWPFDXApp.Models {
  public class Brands {
    public virtual int ID { get; set; }
    public virtual string Name { get; set; }
    public virtual bool IsDeleted { get; set; }

    private IList<Products> _products;
    public virtual IList<Products> Products {
      get => _products ?? (_products = new List<Products>());
      set => _products = value;
    }
  }
}