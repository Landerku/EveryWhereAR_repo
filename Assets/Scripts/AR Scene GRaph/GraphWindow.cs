#if (UNITY_EDITOR) 
using System.IO;
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEngine.Assertions;
public class GraphWindow : BaseGraphWindow
{
    protected override void InitializeWindow(BaseGraph graph)
    {
        Assert.IsNotNull(graph);

        var fileName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(graph));
        titleContent = new GUIContent(ObjectNames.NicifyVariableName(fileName));

        if (graphView == null)
        {
            graphView = new BaseGraphView(this);
        }
        rootView.Add(graphView);
    }
}
#endif