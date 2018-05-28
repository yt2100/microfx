using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data.Repository
{
    public enum ChangeType
    {
        Query,
        Add,
        Update,
        Del
    }

    public interface IRepository
    {
        void AcceptChange();
    }

    public interface IRepository<T>: IRepository
    {
        void Add(T t);

        void Update(T t);

        void Delete(T t);

        IEnumerable<T> Query();
    }
}
