using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float sightrange = 10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject warning = null;
    [SerializeField] private GameObject detect = null;
    private Transform enemyTransform;

    void Awake()
    {
        enemyTransform = transform;
    }
    void Start()
    {
        
    }

    void Update()
    {
        DetectPlayer(IsLookinThePlayer(playerTransform.position));
    }
    private float timeOnSight;

    private void DetectPlayer(bool isLookinThePlayer)
    {
        if (isLookinThePlayer)
        {
            warning.SetActive(true);
            detect.SetActive(false);
            if (timeOnSight<=3)
            {
                timeOnSight += Time.deltaTime;
            }
            if (!(timeOnSight >= 3)) return;
            warning.SetActive(false);
            detect.SetActive(true);
            EditorSceneManager.LoadScene(0);
        }
        else
        {
            if (timeOnSight > 0)
            {
                timeOnSight -= Time.deltaTime;
            }
            if (!(timeOnSight <= 0)) return;
            warning.SetActive(false);
            detect.SetActive(false);
        }
    }

    private bool IsLookinThePlayer(Vector3 playerPosition)
    {
        var displacement = playerPosition - enemyTransform.position;
        var distanceToPlayer = displacement.magnitude;
        if (distanceToPlayer <= sightrange)
        {
            var dot = Vector3.Dot(enemyTransform.forward,displacement.normalized);
            if (!(dot >= 0.5)) return false;

            var layerMask = 1 << 2;
            layerMask =~ layerMask;
            if (Physics.Raycast(enemyTransform.position,displacement.normalized,out var hit,sightrange,layerMask))
            {
                Debug.DrawRay(enemyTransform.position,displacement.normalized * hit.distance,Color.red);
                if (!hit.collider.GetComponent<Player>()) return false;

                Debug.DrawRay(enemyTransform.position,displacement.normalized * hit.distance, Color.green);
                return true;
            }
        }
        return false;
    }
}
