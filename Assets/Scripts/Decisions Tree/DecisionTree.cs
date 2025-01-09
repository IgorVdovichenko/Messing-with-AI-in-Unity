using Decisions_Tree.AnimationEngine;
using Decisions_Tree.Nodes;
using Decisions_Tree.Nodes.Actions;
using Decisions_Tree.Nodes.Decisions;
using UnityEngine;
using UnityEngine.AI;

namespace Decisions_Tree
{
    public class DecisionTree
    {
        private readonly Node _root;

        public DecisionTree(IAnimator animator, NavMeshAgent agent, Transform transform, GameWorldInfo info)
        {
            var idleAction = new IdleAction(animator, agent);
            var runAction = new RunToEnemyAction(animator, agent, info);
            var attackAction = new AttackAction(animator);
            
            var nearEnemyDecision = new NearEnemyDecision(attackAction, runAction, transform, info);
            var spottedDecision = new EnemySpottedDecision(nearEnemyDecision, idleAction, info);
            
            _root = spottedDecision;
        }
        
        public void Run()
        {
            _root.Evaluate();
        }
    }
}