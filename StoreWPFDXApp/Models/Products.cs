using System;

namespace StoreWPFDXApp.Models {
  public class Products {
    public virtual Guid UuId { get; set; }
    public virtual string Name { get; set; }
    public virtual string Article { get; set; }
    public virtual string Description { get; set; }
    public virtual decimal? Price { get; set; }
    public virtual Guid BrandUuId { get; set; }
    public virtual Brands Brands { get; set; }
    public virtual Guid CategoryUuId { get; set; }
    public virtual Categories Categories { get; set; }
  }
}
