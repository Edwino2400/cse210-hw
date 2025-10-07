using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessApp
{
    class PromptPool
    {
        private readonly List<string> _original;
        private readonly Random _random = new Random();
        private List<string> _pool;

        public PromptPool(IEnumerable<string> items)
        {
            _original = items.ToList();
            ResetPool();
        }

        private void ResetPool()
        {
            _pool = new List<string>(_original);
        }

        public string Next()
        {
            if (_pool.Count == 0) ResetPool();
            int idx = _random.Next(_pool.Count);
            var item = _pool[idx];
            _pool.RemoveAt(idx);
            return item;
        }
    }
}
