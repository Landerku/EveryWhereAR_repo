#if (UNITY_EDITOR) 
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;

namespace GraphProcessor
{
    public class GraphProcessor : BaseGraphProcessor
    {
        private List<BaseNode> _processList;
        public float Result { get; private set; }

        public GraphProcessor(BaseGraph graph) : base(graph)
        {
        }

        public override void UpdateComputeOrder()
        {
            _processList = graph.nodes.OrderBy(n => n.computeOrder).ToList();
        }

        public override void Run()
        {
            var count = _processList.Count;

            // ���ׂẴm�[�h�����Ԃɏ�������
            for (var i = 0; i < count; i++)
            {
                _processList[i].OnProcess();
            }

            JobHandle.ScheduleBatchedJobs();

            // Result�m�[�h���擾����
        }
    }
}
#endif