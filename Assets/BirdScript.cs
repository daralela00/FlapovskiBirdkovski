using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource majmuneSound;
    private bool isSoundPlayed = true;
    public GameObject blood;

    public Transform rocketSpawnPoint;
    public GameObject rocketPrefab;
    public float rocketSpeed = 10;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public Image circleFill;
    public float currentTime;
    public float maxTime;

    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        majmuneSound = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && birdIsAlive && (Time.time > nextFire)) 
        {
            nextFire = Time.time + fireRate;
            var rocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, rocketSpawnPoint.transform.rotation);
            rocket.GetComponent<Rigidbody2D>().velocity = rocketSpawnPoint.right * rocketSpeed;
            rocket.transform.Rotate(0, 0, -90);
        }


        /*currentTime -= Time.deltaTime;
        circleFill.fillAmount = currentTime / maxTime;
        if (currentTime < 0)
            currentTime = 0;
        */

        /*
        var timerGO : GameObject;
        var timer : GUIText;
        var ready : bool;
        var countDownSeconds : float;
        var startTime : float;

        function Start () 
        {
            ready = true;
            countDownSeconds = 60;
	        timer = timerGO.transform.gameObject.AddComponent(GUIText);
	        timer.name = "Timer";
	        timer.transform.position = Vector.zero;
        }

        function Update ()
        {
            if (Input.GetButton("e") && ready)
            {
                startTime = Time.time;
                timerMode();
                ready = false;
            }
        }

        //Timer Mode
        //60 seconds to achieve your best
        function timerMode ()
        {
	        var guiTime = 0;

            guiTime = Time.time - startTime;
	        restSeconds = countDownSeconds - (guiTime);	

	        if (guiTime >= 60f) {
	                //Do what you want
	        }

	        timer.text = restSeconds.toString();
        }

        */

        if (Input.GetKeyDown(KeyCode.UpArrow) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if(transform.position.y > 4.69 || transform.position.y < -4.52)
        {
            logic.gameOver();
            birdIsAlive = false;

            if (isSoundPlayed)
            {
                majmuneSound.Play();
                isSoundPlayed = false;
            }
        }
    }

    int status = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(status == 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            status++;
        }

        logic.gameOver();
        birdIsAlive = false;

        if(isSoundPlayed)
        {
            majmuneSound.Play();
            isSoundPlayed = false;
        }

    }
}
