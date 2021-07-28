using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField]
    Toggle            Toggle = null;
    [SerializeField]
    Button            Button = null;
    [SerializeField]
    ContentSizeFitter Content = null;

    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (var resolution in resolutions)
        {
            Button button = Instantiate(Button, Content.transform);
            button.gameObject.SetActive(true);

            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText($"{resolution.width} x {resolution.height} {resolution.refreshRate}Hz");

            button.onClick.AddListener(() => OnClick(resolution));
        }
    }

    void OnClick(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Toggle.isOn, resolution.refreshRate);
    }
}
