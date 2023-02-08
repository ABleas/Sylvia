using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEditor : EditorWindow
{
  [MenuItem("Window/UI Toolkit/UIEditor")]
  public static void ShowExample()
  {
    UIEditor wnd = GetWindow<UIEditor>();
    wnd.titleContent = new GUIContent("UIEditor");
  }

  [SerializeField]
  private VisualTreeAsset m_UXMLTree;

  public void CreateGUI()
  {
    Debug.Log("please");

    // Each editor window contains a root VisualElement object
    VisualElement root = rootVisualElement;

    // Import UXML
    var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UIEditor.uxml");
    VisualElement labelFromUXML = visualTree.Instantiate();
    root.Add(m_UXMLTree.Instantiate());

    ConnectButtons();
  }

  private void ConnectButtons()
  {
    VisualElement root = rootVisualElement;

    var buttons = root.Query<Button>();
    Debug.Log(buttons);
    buttons.ForEach((Button b) =>
    {
      Debug.Log("Register button " + b.name);
      b.RegisterCallback<ClickEvent>(HandleButtonClick);
    });
  }

  private void HandleButtonClick(ClickEvent e)
  {
    Button b = e.currentTarget as Button;
    switch (b.name)
    {
      case "play_button":
        Debug.Log("Play Button Clicked");
        break;
    }
  }
}