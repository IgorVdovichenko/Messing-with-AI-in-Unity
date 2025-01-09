using System;
using System.Collections.Generic;
using Decisions_Tree;
using MoonSharp.Interpreter;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptedDT.ActionManagement
{
    public class ActionManager
    {
        private readonly Dictionary<string, string> _scripts = new Dictionary<string, string>();

        private Script _script;

        public ActionManager(TextAsset textAsset, AgentController agent, NavMeshAgent ai, GameWorldInfo info)
        {
            var bindings = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            foreach (var (key, value) in bindings)
            {
                _scripts.Add(key, Resources.Load<TextAsset>(value).text);
            }
            UserData.RegisterType<AgentController>();
            Script.DefaultOptions.DebugPrint = Debug.Log;
            _script = new Script();
            _script.Globals["agent"] = agent;

            UserData.RegisterProxyType<NavMeshAgentProxy, NavMeshAgent>(p => new NavMeshAgentProxy(p));
            _script.Globals["ai"] = ai;

            _script.Globals["MoveToTarget"] = (Action)(() =>
            {
                ai.enabled = true;
                ai.SetDestination(info.GetPosition());
            });
        }
        
        public void ExecuteAction(string id)
        {
            _script.DoString(_scripts[id]);
        }

        private void MoveToTarget(NavMeshAgent ai, GameWorldInfo info)
        {
            ai.isStopped = false;
            ai.SetDestination(info.GetPosition());
        }
    }
}