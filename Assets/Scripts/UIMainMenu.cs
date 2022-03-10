using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private GameObject mustEnterNameText;
    
    public void StartButton()
    {
        if (playerNameInput.text == "")
        {
            mustEnterNameText.SetActive(true);
            return;
        }
        MainDataManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(0);
    }
}
