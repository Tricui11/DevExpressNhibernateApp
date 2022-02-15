namespace StoreWPFDXApp.Models {
  public class Products {
    public virtual int ID { get; set; }
    public virtual string Name { get; set; }
    public virtual string Article { get; set; }
    public virtual string Description { get; set; }
    public virtual decimal? Price { get; set; }
    public virtual int BrandID { get; set; }
    public virtual Brands Brands { get; set; }
    public virtual int CategoryID { get; set; }
    public virtual Categories Categories { get; set; }
  }
}
