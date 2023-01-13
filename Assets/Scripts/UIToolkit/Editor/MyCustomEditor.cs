using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [SerializeField]
    private VisualTreeAsset m_UXMLTree;

    [MenuItem("Window/UI Toolkit/MyCustomEditor")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        Button button = new Button
        {
            name = "button3",
            text = "This is button3."
        };
        root.Add(button);

        Toggle toggle = new Toggle
        {
            name = "toggle3",
            label = "Number?"
        };
        root.Add(toggle);

        // Instantiate UXML
        root.Add(m_VisualTreeAsset.Instantiate());
        root.Add(m_UXMLTree.Instantiate());
    }
}
