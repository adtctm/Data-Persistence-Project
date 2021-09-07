using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Name").GetComponentInChildren<TMP_InputField>().text = MenuManager.Instance.username;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MenuManager.Instance.Save();
    }

    public void NameChange(string text)
    {
        MenuManager.Instance.username = text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
