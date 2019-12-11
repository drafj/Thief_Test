using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text advice;
    public Transform playerTransform;
    public GameObject winText;

    void Awake()
    {
        instance = this;
        winText.SetActive(false);
    }

    void Update()
    {
        
    }
}
