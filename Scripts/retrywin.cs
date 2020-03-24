using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retrywin : MonoBehaviour
{
    public void Retry2()
    {
        Debug.Log("retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//Hleður upp borðinu
    }
}
