﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();//slekkur á leiknum
    }
}