using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float enemyDistance = 10;
    public float catchRange = 4;
    public bool objectTaked;
    public GameObject objectHitted;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        TakeThings();
        ShowText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
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
            switch (objectTaked)
            {
                case false:
                    objectHitted = hit.collider.gameObject;
                    if (objectHitted.GetComponent<CatchableObject>() != null)
                    {
                        objectTaked = true;
                        objectHitted.transform.parent = Camera.main.transform;
                        objectHitted.GetComponent<CatchableObject>().Take(true);
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    break;
                case true:
                    objectTaked = false;
                    objectHitted.transform.parent = null;
                    objectHitted.GetComponent<CatchableObject>().Take(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                default:
                    break;
            }

        }
    }
}
