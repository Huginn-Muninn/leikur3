using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retrylost : MonoBehaviour
{
    public void Retry()
    {
        Debug.Log("retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);//Hleður upp borðinu
    }
}
