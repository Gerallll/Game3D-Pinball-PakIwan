using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscript : MonoBehaviour
{
    private enum switchstate
    {
        Off,
        On,
        Blink
    }
    public Collider bola;
    public Material switchon;
    public Material switchoff;
    public float score;
    public ScoreManager scoreManager;

    private switchstate state;
    private Renderer renderer;

    private void Start() 
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine (BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other == bola)
        {
            Toggle();
        }
        scoreManager.AddScore(score);
    }

    private void Set(bool active)
    {
         if (active == true)
        {
            state = switchstate.On;
            renderer.material = switchon;
            StopAllCoroutines();
        }
        else 
        {
            state = switchstate.Off;
            renderer.material = switchoff;
            StartCoroutine (BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == switchstate.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = switchstate.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = switchon;
            yield return new WaitForSeconds(0.5f);
            renderer.material = switchoff;
            yield return new WaitForSeconds(0.5f);
        }

        state = switchstate.Off;

        StartCoroutine (BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
