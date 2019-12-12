using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Toggle))]
public class PanelNavigatable : MonoBehaviour
{
    public PanelNavigatable UpperElement;
    public PanelNavigatable LowerElement;
    public PanelNavigatable LeftElement;
    public PanelNavigatable RightElement;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void ClickButton()
    {
        _button.onClick.Invoke();
    }
}
