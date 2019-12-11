using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float sightRange = 10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject warning = null;
    [SerializeField] private GameObject detect = null;

    private Transform enemiTransform;

    void Awake()
    {
        enemiTransform = transform;
    }

    void Update()
    {
        DetectPlayer(IsLookinThePlayer(playerTransform.position));
        playerTransform = GameManager.instance.playerTransform;
    }

    private float timeOnSight;

    private void DetectPlayer(bool isLookinThePlayer)
    {
        if (isLookinThePlayer)
        {
            warning.SetActive(true);
            detect.SetActive(false);
            GameManager.instance.advice.text = "te estan detectando";
            if (timeOnSight <= 3)
            {
                timeOnSight += Time.deltaTime;
            }
            if (!(timeOnSight >= 3)) return;
            warning.SetActive(false);
            detect.SetActive(true);
            SceneManager.LoadScene(0);
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
            GameManager.instance.advice.text = "";
        }
    }

    private bool IsLookinThePlayer(Vector3 playerPosition)
    {
        var displacement = playerPosition - enemiTransform.position;
        var distanceToPlayer = displacement.magnitude;

        if (distanceToPlayer <= sightRange)
        {
            var dot = Vector3.Dot(enemiTransform.forward, displacement.normalized);

            if (!(dot >= 0.5)) return false;

            var layerMask = 1 << 2;
            layerMask = ~layerMask;

            if (Physics.Raycast(enemiTransform.position, displacement.normalized, out var hit, sightRange, layerMask))
            {
                Debug.DrawLine(enemiTransform.position, displacement.normalized * hit.distance, Color.red);
                if (!hit.collider.GetComponent<Player>()) return false;
                Debug.DrawRay(enemiTransform.position, displacement.normalized * hit.distance, Color.green);
                return true;
            }
        }
        return false;
    }
}