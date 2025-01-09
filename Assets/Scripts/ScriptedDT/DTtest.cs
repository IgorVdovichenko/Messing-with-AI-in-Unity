using Decisions_Tree;
using Decisions_Tree.AnimationEngine;
using ScriptedDT.ActionManagement;
using ScriptedDT.Parsing;
using UnityEngine;
using UnityEngine.AI;


namespace ScriptedDT
{
    public class DTtest : MonoBehaviour
    {
        private DecisionTree _dt;
        private ActionManager _actionManager;

        [SerializeField] private GameWorldInfo _info;

        [SerializeField] private TextAsset _textAsset;
        [SerializeField] private TextAsset _bindings;
        
        private void Awake()
        {
            var anim = GetComponent<Animator>();
            var reader = new TextAssetReader(_textAsset);
            var parser = new JsonParser(reader);
            _dt = new DecisionTree(parser);
            var animator = new UnityAnimatorStatesCrossFader(anim);
            var agentController = new AgentController(animator, GetComponent<NavMeshAgent>());
            _actionManager = new ActionManager(_bindings, agentController, GetComponent<NavMeshAgent>(), _info);
        }

        private void Update()
        {
            _dt.SetBool("Target_spotted", CanSeeTarget());
            _dt.SetFloat("DistanceToTarget", GetDistanceToTarget());
            _dt.SetFloat("Target_Health", _info.health);
            var node = _dt.Run();
            _actionManager.ExecuteAction(node.Id);
        }

        private bool CanSeeTarget()
        {
            var d = _info.GetPosition() - transform.position;
            return Vector3.Dot(transform.forward, d) >= 0;
        }

        private float GetDistanceToTarget()
        {
            return Vector3.Distance(_info.GetPosition(), transform.position);
        }
    }
}