namespace StoreWPFDXApp.Data {
  public class Categories {
    public virtual int ID { get; set; }
    public virtual int ParentID { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual string KeyWords { get; set; }
  }
}