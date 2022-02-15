﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class CategoryRepository : ICategoryRepository {
    private readonly ISession _session;

    public CategoryRepository(ISession session) {
      _session = session;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.CreateCriteria<Categories>().ListAsync<Categories>();
        tx.Commit();
        return categories.Where(x => !x.IsDeleted);
      }
    }

    public async Task<Guid> AddAsync(Categories entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.UuId;
      }
    }

    public async Task UpdateAsync(Categories entity) {
      using (var tx = _session.BeginTransaction()) {
        var category = _session.Get<Categories>(entity.UuId);
        if (category.Name != entity.Name) {
          category.Name = entity.Name;
        }
        if (category.Description != entity.Description) {
          category.Description = entity.Description;
        }
        if (category.KeyWords != entity.KeyWords) {
          category.KeyWords = entity.KeyWords;
        }
        await _session.UpdateAsync(category);
        tx.Commit();
      }
    }

    public async Task UpdateParentAsync(Guid entityUuId, Guid parentUuId) {
      using (var tx = _session.BeginTransaction()) {
        var category = _session.Get<Categories>(entityUuId);
        category.ParentUuId = parentUuId;
        await _session.UpdateAsync(category);
        tx.Commit();
      }
    }

    public async Task DeleteAsync(IEnumerable<Guid> uuIds) {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.QueryOver<Categories>()
          .WhereRestrictionOn(val => val.UuId)
          .IsIn(uuIds.ToArray())
          .ListAsync();

        foreach (var category in categories) {
          category.IsDeleted = true;
        }

        await _session.UpdateAsync(categories);
        tx.Commit();
      }
    }

    public Task DeleteAsync(Guid uuId) {
      throw new NotImplementedException();
    }
  }
}
