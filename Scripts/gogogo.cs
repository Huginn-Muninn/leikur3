using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gogogo : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Hleður upp borðinu (veit ekki áhverju þetta virkar öðruvísi en hinar tvær skripturnar sem gera þetta)
    }
}
