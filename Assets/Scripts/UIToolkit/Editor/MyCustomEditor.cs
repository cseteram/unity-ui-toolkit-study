using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [SerializeField]
    private VisualTreeAsset m_UXMLTree;

    private int m_ClickCount;
    
    private const string m_ButtonPrefix = "button";
    
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
        
        SetupButtonHandler();
    }

    private void SetupButtonHandler()
    {
        var buttons = rootVisualElement.Query<Button>();
        buttons.ForEach(RegisterHandler);
    }

    private void RegisterHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(PrintClickMessage);
    }
    
    private void PrintClickMessage(ClickEvent evt)
    {
        ++m_ClickCount;

        Button button = evt.currentTarget as Button;
        string buttonNumber = button.name[m_ButtonPrefix.Length..];
        string toggleName = "toggle" + buttonNumber;
        Toggle toggle = rootVisualElement.Query<Toggle>(toggleName);

        Debug.Log("Button was clicked!" + (toggle.value ? "Count: " + m_ClickCount : ""));
    }
}
