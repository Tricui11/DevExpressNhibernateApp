using System.Collections.Generic;

namespace StoreWPFDXApp.Models {
  public class Products {
    public virtual int ID { get; set; }
    public virtual string Name { get; set; }
    public virtual int BrandID { get; set; }
    public virtual Brands Brands { get; set; }
  }
}
