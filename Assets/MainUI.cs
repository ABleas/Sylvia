using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
  [SerializeField]
  private UIDocument m_mainUI;

  void Start()
  {
    ConnectButtons();
  }

  void Update()
  {

  }

  private void ConnectButtons()
  {
    VisualElement root = m_mainUI.rootVisualElement;

    var buttons = root.Query<Button>();
    buttons.ForEach((Button b) =>
    {
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
        Globals.Instance.game_start = true;
        break;
    }
  }
}
