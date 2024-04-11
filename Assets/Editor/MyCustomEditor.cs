using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/MyCustomEditor")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

    public void CreateGUI()
    {
        for (int i = 0; i < 2; i++)
        {
            var temp = new VisualElement();
            temp.style.width = 70;
            temp.style.height = 70;
            temp.style.marginBottom = 2;
            temp.style.backgroundColor = Color.grey;
            this.rootVisualElement.Add(temp);
        }

        var relative = new Label("Relative\nPos\n25, 0");
        relative.style.width = 70;
        relative.style.height = 70;
        relative.style.left = 25;
        relative.style.marginBottom = 2;
        relative.style.backgroundColor = new Color(0.21f, 0, 0.25f);
        this.rootVisualElement.Add(relative);

        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        Button button = new Button();
        button.name = "StartGameButton";
        button.text = "Start Game";
        root.Add(button);

        // Instantiate UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/MyCustomEditor.uxml");
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        // Setup the button handler
        SetupButtonHandler();
    }

    private void SetupButtonHandler()
    {
        var buttons = rootVisualElement.Query<Button>();
        buttons.ForEach(RegisterHandler);
    }

    private void RegisterHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(ev => Debug.Log("Button clicked"));
    }
}
