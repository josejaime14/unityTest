using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OptionButton : MonoBehaviour
{
    public Option Option { get; set; }

    private Text text = null;
    private Button button = null;
    private Image image = null;
    private Color originColor = Color.white;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        originColor = image.color;
    }

    public void Create(Option option, Action<OptionButton> callback)
    {
        button.onClick.RemoveAllListeners();
        text.text = option.text;
        button.enabled = true;
        image.color = originColor;
        
        Option = option;

        button.onClick.AddListener(() => callback(this));
    }

    public void SetColor(Color color)
    {
        button.enabled = false;
        image.color = color;
    }
}
