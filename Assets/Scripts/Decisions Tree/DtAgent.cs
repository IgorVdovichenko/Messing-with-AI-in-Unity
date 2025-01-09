using System;
using Decisions_Tree.AnimationEngine;
using UnityEngine;
using UnityEngine.AI;

namespace Decisions_Tree
{
    public class DtAgent : MonoBehaviour
    {
        private DecisionTree dt;

        [SerializeField] private GameWorldInfo _info = default;
        
        private void Awake()
        {
            var animator = GetComponent<Animator>();
            var agent = GetComponent<NavMeshAgent>();
            dt = new DecisionTree(new UnityAnimatorStatesCrossFader(animator), agent, transform, _info);
        }

        private void Update()
        {
            dt.Run();
        }
    }
}