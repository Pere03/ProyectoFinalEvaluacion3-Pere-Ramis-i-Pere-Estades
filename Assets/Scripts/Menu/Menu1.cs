using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu1 : MonoBehaviour
{
    //public TextMeshProUGUI loadingText;
    public Text loadingText;
    public Slider slider;
    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    private void Start()
    {
        Increment(1f);
    }

    private void Update()
    {
        loadingText.text = slider.value * 100 + "".ToString();
        if (slider.value < targetProgress)
            slider.value += FillSpeed * Time.deltaTime;

        if (slider.value == 1)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void Increment(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
