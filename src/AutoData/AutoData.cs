using System;
using System.Collections.Generic;

namespace AutoData
{
    public class AutoData : IAutoData
    {
        private TreeBlock _tree;
        private readonly ISeparatable _separatable;
        private readonly IFillable _fillable;
        public AutoData(ISeparatable separatable, IFillable fillable)
        {
            _separatable = separatable;
            _fillable = fillable;
            _tree = new TreeBlock(_separatable, _fillable);
        }

        public IEnumerable<T> Create<T>(int number)
        {
            List<T> objs = new List<T>();

            for (int i = 0; i < number; i++)
            {
                objs.Add(Fill<T>());
            }

            return objs;
        }

        public void Fill(object data)
        {
            _tree.Fill(data);
        }

        public T Fill<T>()
        {
            var data = Activator.CreateInstance(typeof(T));
            Fill(data);
            return (T)data;
        }
    }
}
