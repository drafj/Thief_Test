﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text advice;
    public Transform playerTransform;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
