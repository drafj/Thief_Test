using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float enemyDistance = 10;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject enemyCloser = null;
        enemyDistance = 10;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            Vector3 temporalUbication = enemy.transform.position;
            float temporalDistance = (temporalUbication - transform.position).magnitude;

            if (temporalDistance < enemyDistance)
            {
                enemyDistance = temporalDistance;
                enemyCloser = enemy.gameObject;
            }
        }

        if (enemyCloser != null && enemyCloser.GetComponent<Enemy>().canShowText)
        {
            GameManager.instance.advice.text = "te estan detectando";
        }
        else
            GameManager.instance.advice.text = "";
    }
}
