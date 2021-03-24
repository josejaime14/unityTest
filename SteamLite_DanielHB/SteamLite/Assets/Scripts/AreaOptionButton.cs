using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class AreaOptionButton : MonoBehaviour
{
    public AreaOption AreaOption { get; set; }

    private Text text;
    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    public void Create(AreaOption areaOption, Action<AreaOptionButton> callback)
    {
        button.onClick.RemoveAllListeners();
        text.text = areaOption.textTitle;
        button.enabled = true;

        AreaOption = areaOption;

        button.onClick.AddListener(() => callback(this));
    }
}
