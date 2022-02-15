using System.Collections.Generic;

namespace StoreWPFDXApp.Models {
  public class Categories {
    public virtual int ID { get; set; }
    public virtual int ParentID { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual string KeyWords { get; set; }
    public virtual bool IsDeleted { get; set; }

    private IList<Products> _products;
    public virtual IList<Products> Products {
      get => _products ?? (_products = new List<Products>());
      set => _products = value;
    }
  }
}