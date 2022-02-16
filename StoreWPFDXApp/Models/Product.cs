using System;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models {
  public class Product : IUniqueIdentifier {
    public virtual Guid UuId { get; set; }
    public virtual string Name { get; set; }
    public virtual byte[] ImageData { get; set; }
    public virtual string Article { get; set; }
    public virtual string Description { get; set; }
    public virtual decimal? Price { get; set; }
    public virtual Guid? BrandUuId { get; set; }
    public virtual Brand Brands { get; set; }
    public virtual Guid? CategoryUuId { get; set; }
    public virtual Category Categories { get; set; }
  }
}
