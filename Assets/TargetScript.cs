using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public Animator anim;
    public GameObject specialPipe;
    // Start is called before the first frame update
    void Start()
    {
        anim = specialPipe.GetComponentInChildren<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.enabled = true;
        Destroy(gameObject);
    }
}