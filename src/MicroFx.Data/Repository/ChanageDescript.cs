using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data.Repository
{
    public class ChangeDescript
    {
    }

    public class ChangeDescript<T> : ChangeDescript
    {
        public T Entity { get; private set; }

        public ChangeType ChangeType { get; private set; }

        public ChangeDescript(T t,ChangeType changeType)
        {
            Entity = t;
            ChangeType = changeType;
        }
    }
}
