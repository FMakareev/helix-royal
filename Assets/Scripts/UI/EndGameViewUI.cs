using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameViewUI : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _container;
    
    private void Awake()
    {
        Hide();
    }
    

    public void Show()
    {
        _container.SetActive(true);
        SetCount(0);
    }

    public void Hide()
    {
        _container.SetActive(false);
    }
    public void SetCount(int score)
    {
        _text.GetComponent<Text>().text = score.ToString();
    }
}
