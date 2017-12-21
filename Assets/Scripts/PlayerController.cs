using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	public float speed; // can make changes in editor
	public Text countText;
	private Rigidbody rb;
	private int count;
	public Text winText;
	public Text loseText;
	public Text coolText;
    [SerializeField]
    private DelishMeter meter;
	public Rigidbody tacoRigidBody;

    //Our desired pickUps for each level.
    int maxPickUps;

    //initialized to first level.
    private int activeSceneIndex;



    private float speedOfObject;
	public GameController controller;

	public GameObject PlatformOneBottomLeft;
	public Animator animatorPlatformOneBottomLeft;

	public GameObject PlatformOneBottomRight;
	public Animator animatorPlatformOneBottomRight;

	public GameObject PlatformOneTopLeft;
	public Animator animatorPlatformOneTopLeft;

	public GameObject PlatformOneTopRight;
	public Animator animatorPlatformOneTopRight;

	public GameObject PlatformTwo;
	public Animator animatorPlatformTwo;

	public GameObject PlatformThree;
	public Animator animatorPlatformThree;

	public GameObject PlatformFour;
	public Animator animatorPlatformFour;

	public GameObject PlatformFive;
	public Animator animatorPlatformFive;

	public GameObject startPlatform;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>(); // grab the rigidbody attached to the ball
		count = 0;
		winText.text = "";
		loseText.text = "";
		coolText.text = "";

        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
       
        //maxPickUps will be our desired pickups per level
        //once we have more scenes we can have an if check for which level we are on.
        if (activeSceneIndex == 1)
        {
            maxPickUps = 20;
        }
        else if (activeSceneIndex == 2) {
            maxPickUps = 25;
        }
        else if (activeSceneIndex == 3)
        {
            maxPickUps = 30;
        }

        meter.Initialize(0, maxPickUps - 1);

    }
	
	// Update is called once per frame before render
	void Update() {
		if (transform.position.y < -1790) {
			transform.position = new Vector3 (transform.position.x, -1788, transform.position.z);
			if (winText.text.Equals ("")) {
				loseText.text = "You Lose.";
				StartCoroutine ("restartGame");
			}
		}
	}
	
	// called before any physics calc
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal"); // gets input from keys and moves it since the ball has a rigid body which uses the physics engine
		float moveVertical = Input.GetAxis("Vertical");
		speedOfObject = rb.velocity.magnitude;

		Vector3 movement = new Vector3 ( moveHorizontal, 0, moveVertical); // determines direction of force 
		transform.Rotate(Vector3.up * moveVertical * -15);
		transform.Rotate(Vector3.right * moveHorizontal * -15);

		// vector 3 holds 3 decimal valex (x,y,z)
		rb.AddForce(movement * speed); // leave force mode

        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * 40);

		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
			if (Input.GetKeyDown (KeyCode.RightArrow))
					StartCoroutine("coolMoves");
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("StartPlatform")) {
			Debug.Log ("left");
			Destroy (startPlatform);
		}
	}

	// when you touch another trigger collider itll destroy it
	void OnTriggerEnter(Collider other) {
		//This is the standard pick up for the game
		if(other.gameObject.CompareTag("Pick Up - Chicken")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            // collider with rigid body tells unity its a dynamic collider so it wont recalculate its volume every frame and cache it
            // kinematic makes rigid body not react to physics forces but you can still transform it

            //increments the delishMeter
            meter.MyCurrentValue += 1;
            PlayClip("Chips");
        }

		if(other.gameObject.CompareTag("Pick Up - Chicken - PlatformOneBL - Color")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformOneBottomLeft.SetTrigger("colorRedTrigger");
			StartCoroutine("changeColorAndDropPlatformBottomLeft");

			//Destroy(PlatformTwo, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - PlatformOneBR - Color")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformOneBottomRight.SetTrigger("colorRedTrigger");
			StartCoroutine("changeColorAndDropPlatformBottomRight");

			//Destroy(PlatformTwo, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - PlatformOneTL - Color")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformOneTopLeft.SetTrigger("colorRedTrigger");
			StartCoroutine("changeColorAndDropPlatformTopLeft");

			//Destroy(PlatformTwo, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - PlatformOneTR - Color")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformOneTopRight.SetTrigger("colorRedTrigger");
			StartCoroutine("changeColorAndDropPlatformTopRight");

			//Destroy(PlatformTwo, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - Trap")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformTwo.SetTrigger("shrinkTrigger");
			animatorPlatformThree.SetTrigger("appearTrigger");


			//Destroy(PlatformThree, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - Trap - 1")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformThree.SetTrigger("shrinkTrigger");

			//Destroy(PlatformThree, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - Trap - 2")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformFour.SetTrigger("shrinkTrigger");

			//Destroy(PlatformFour, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Pick Up - Chicken - Trap - 3")){
			other.gameObject.SetActive(false); // deactives pickup obj
			count++;
			setCountText();
			controller.incrementChickenCounter ();
            PlayClip("Chips");
            Debug.Log ("Hit");
			animatorPlatformFive.SetTrigger("shrinkTrigger");

			//Destroy(PlatformFive, Random.Range (1.0f, 5.0f)); // deactives pickup obj

		}

		if(other.gameObject.CompareTag("Death") && winText.text.Equals("")){
			
			loseText.text = "You  Lose.";
            count = 0;
			StartCoroutine("restartGame");
			tacoRigidBody.useGravity = false;

		}

        if (other.gameObject.CompareTag("Asteroid"))
        {
            if (count >= 1)
            {
                count--;
                meter.MyCurrentValue -= 1;
                controller.decrementChickenCounter();
                
                setCountText();
                PlayClip("asteroid");
            }
        }
    }

	IEnumerator restartGame()
	{
		yield return new WaitForSeconds(4);

        if (winText.text == "")
        {
            Application.LoadLevel(activeSceneIndex);
        }
        else 
        {
            activeSceneIndex++;
            Application.LoadLevel(activeSceneIndex);
        }
		
	}

	IEnumerator coolMoves()
	{
		coolText.text = "Go Taco Go!";
		yield return new WaitForSeconds(4);
		coolText.text = "";
	}

	IEnumerator changeColorAndDropPlatformBottomLeft()
	{
		animatorPlatformOneBottomLeft.SetTrigger("colorRedTrigger");
		yield return new WaitForSeconds(2);
		animatorPlatformOneBottomLeft.SetTrigger("disappearTrigger");
        PlayClip("warper");

    }

    IEnumerator changeColorAndDropPlatformBottomRight()
	{
		animatorPlatformOneBottomRight.SetTrigger("colorRedTrigger");
		yield return new WaitForSeconds(2);
		animatorPlatformOneBottomRight.SetTrigger("disappearTrigger");
        PlayClip("warper");
    }

	IEnumerator changeColorAndDropPlatformTopLeft()
	{
		animatorPlatformOneTopLeft.SetTrigger("colorRedTrigger");
		yield return new WaitForSeconds(2);
		animatorPlatformOneTopLeft.SetTrigger("disappearTrigger");
        PlayClip("warper");
    }

	IEnumerator changeColorAndDropPlatformTopRight()
	{
		animatorPlatformOneTopRight.SetTrigger("colorRedTrigger");
		yield return new WaitForSeconds(2);
		animatorPlatformOneTopRight.SetTrigger("disappearTrigger");
        PlayClip("warper");
    }

	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= maxPickUps){
			winText.text = "You  Win!";

			StartCoroutine("restartGame");

		}
	}

    public void PlayClip(string clipName)
    {
        Debug.Log("hi");
        AudioSource playerCollisionAudio = gameObject.AddComponent<AudioSource>();

        playerCollisionAudio.clip = Resources.Load<AudioClip>("Audio/" + clipName);

        playerCollisionAudio.Play();

        Destroy(playerCollisionAudio, playerCollisionAudio.clip.length);
    }

}
