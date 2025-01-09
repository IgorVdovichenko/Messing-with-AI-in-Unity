using Decisions_Tree.GUI;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Decisions_Tree.Editor
{
    public class OpenAssetExample
    {
        [OnOpenAsset]
        public static bool OnOpenAssetAction(int instanceId, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceId);
            
            if(name is DecisionTreeAsset)
                Debug.Log(name);
            
            return false;
        }
    }
}
