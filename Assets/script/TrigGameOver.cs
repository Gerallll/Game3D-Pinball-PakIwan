using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject GamveOverCanvas;
    private void OnTriggerEnter(Collider other) 
    {
        if (other == bola)
        {
            GamveOverCanvas.SetActive(true);
        }
    }
}
