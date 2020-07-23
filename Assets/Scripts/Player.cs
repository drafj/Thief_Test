using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float enemyDistance = 10;
    public float catchRange = 4;

    void Start()
    {
        
    }

    void Update()
    {
        TakeThings();
        ShowText();
    }

    public void ShowText()
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

    public void TakeThings()
    {
        int layerMask = 1 << 9;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, Camera.main.transform.forward, out RaycastHit hit, catchRange, layerMask))
        {
            GameObject gameHitted = hit.collider.gameObject;
            if (hit.collider.GetComponent<CatchableObject>() != null)
                gameHitted.transform.parent = transform;
        }
    }
}
