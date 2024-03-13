using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] int _coins = 0, _coinsMax = 4;
    public static GameManager _instance;
    public UIController _uiController;

    public void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void LoadScene(string Levelteste)
    {
        SceneManager.LoadScene(Levelteste);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CollectCoin()
    {
        _coins++;
        _uiController.UpdateCoin(_coins);
        if (_coins >= _coinsMax)
        {
            LoadScene("End");
        }
    }
}
