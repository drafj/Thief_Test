using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            GameManager.instance.winText.SetActive(true);
        }
    }
}
