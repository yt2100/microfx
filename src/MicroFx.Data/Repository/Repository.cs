using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data.Repository
{
    public abstract class Repository<T> : IRepository<T>
    {
        public IDBContext DBContext { get; private set; }

        public Repository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public List<ChangeDescript<T>> _changeDescripts = new List<ChangeDescript<T>>();

        public void AcceptChange()
        {
            foreach (var changeDescript in _changeDescripts)
            {
                DBContext.Execute(changeDescript);
            }
        }

        public void Add(T t)
        {
            _changeDescripts.Add(new ChangeDescript<T>(t, ChangeType.Add));
        }

        public void Delete(T t)
        {
            _changeDescripts.Add(new ChangeDescript<T>(t, ChangeType.Del));
        }

        public void Update(T t)
        {
            _changeDescripts.Add(new ChangeDescript<T>(t, ChangeType.Update));
        }

        public IEnumerable<T> Query()
        {
            throw new NotImplementedException();
        }
    }
}
