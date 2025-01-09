using System;
using ScriptedDT.Models;
using ScriptedDT.Parsing;
using UnityEngine;


namespace ScriptedDT
{
    public class DecisionTreeComponent : MonoBehaviour
    {
        [SerializeField] private TextAsset _asset;
        private DecisionTree _decisionTree;

        private void Awake()
        {
            _decisionTree = new DecisionTree(new JsonParser(new TextAssetReader(_asset)));
        }

        public Node Run()
        {
            return _decisionTree.Run();
        }
    }
}