using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainViewUI : MonoBehaviour
{
    [SerializeField] private GameObject _beam;
    [SerializeField] private GameObject _container;
    [SerializeField] private GameViewUI _gameViewUI;

    private void Awake()
    {
        Show();
    }

    public void Show()
    {
        _container.SetActive(true);
    }

    public void Hide()
    {
        _container.SetActive(false);
    }
    
    
    public void StartGame()
    {
        _beam.GetComponent<TowerBuilder>().ReBuild();
        Hide();
        FindObjectOfType<EndGameViewUI>().Hide();
        GameScoreState.instance.Reset();
        _gameViewUI.Show();
        StartGameState.instance.SetStartGame();
    }
}
