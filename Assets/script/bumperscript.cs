using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperscript : MonoBehaviour
{
    public Collider bola;
    public Color color;
    public float multiplier;
    public float score;
    public AudioManager audioManager;
    public VFXMannager vfxManager;
    public ScoreManager scoreManager;

    private Renderer renderer;
    private Animator animator;

    private void Start() 
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasi
            animator.SetTrigger("hit");

            //playsfx
            audioManager.PlaySFX(collision.transform.position);
            
            vfxManager.PlayVFX(collision.transform.position);

            scoreManager.AddScore(score);
        }
    }
}
