#if UNITY_EDITOR

using GraphProcessor;
using UnityEditor.Callbacks;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor;


[CreateAssetMenu(menuName = "AR Scene Graph")]
public class GameSceneGraph : BaseGraph
{
    // �_�u���N���b�N�ŃE�B���h�E���J�����悤��
    [OnOpenAsset(0)]
    public static bool OnBaseGraphOpened(int instanceID, int line)
    {
        var asset = EditorUtility.InstanceIDToObject(instanceID) as GameSceneGraph;

        if (asset == null) return false;

        var window = EditorWindow.GetWindow<GraphWindow>();
        window.InitializeGraph(asset);
        return true;
    }

    [SerializeField]
    public List<ObjectNode> Nodes => nodes.OfType<ObjectNode>().ToList();
    public List<ObjectNode> GetNodes()
    {
        return Nodes;
    }
}
#endif
