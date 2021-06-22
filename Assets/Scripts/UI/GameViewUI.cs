using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameViewUI : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _container;
    
    [SerializeField] private EndGameViewUI _gameViewUI;
    
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
