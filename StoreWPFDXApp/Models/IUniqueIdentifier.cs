using System;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface IUniqueIdentifier {
    Guid UuId { get; set; }
  }
}
