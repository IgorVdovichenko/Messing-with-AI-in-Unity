using System;
using Decisions_Tree;
using Decisions_Tree.AnimationEngine;
using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptedDT.Lua
{
    public class LuaManager: MonoBehaviour
    {
        [SerializeField] private TextAsset _scriptCode;
        [SerializeField] private GameWorldInfo _info;

        private Script script;
        
        private void Awake()
        {
            var animator = new UnityAnimatorStatesCrossFader(GetComponent<Animator>());
            var controller = new Controller(animator, GetComponent<NavMeshAgent>(), _info);
            
            Script.DefaultOptions.DebugPrint = Debug.LogError;
            
            script = new Script();

            UserData.RegisterType<Controller>();
            UserData.RegisterType<Target>();

            script.Globals["agent"] = controller;
            script.Globals["target"] = new Target(_info, transform);
        }

        private void Update()
        {
            script.DoString(_scriptCode.text);
        }
    }
}