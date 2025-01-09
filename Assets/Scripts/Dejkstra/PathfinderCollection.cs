using System.Collections.Generic;
using System.Linq;
using Dejkstra.Graph;

namespace Dejkstra
{
    public class PathfinderCollection
    {
        private List<NodeRecord> _records = new List<NodeRecord>();

        public int Count => _records.Count;

        public void Add(NodeRecord record)
        {
            _records.Add(record);
        }

        public void Remove(NodeRecord record)
        {
            _records.Remove(record);
        }

        public bool TryGetRecordWithNode(Node node, out NodeRecord record)
        {
            record = _records.FirstOrDefault(r => r.Node == node);
            return _records.Count(r => r.Node == node) > 0;
        }

        public NodeRecord GetRecordWithSmallestCost()
        {
            return _records.OrderBy(n => n.Cost).First();
        }
    }
}