using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public Camera cam;
	public Text scoreText;
	public Text truckText;
	public Text lifeText;
	public float playerState;
	public float stackHeight;
	public float mouseX;
	public float score;
	public float truck;
	public float life;
	public bool canDrop;
	public bool dead;
	public float deadTime;
	public Sprite idle;
    public Sprite gold1;
    public Sprite IceBox1;
    public Sprite silver1;
    // Use this for initialization


    public float moveSpeed = 5f;
    //public bool isGrounded = false;
    // Start is called before the first frame update
    float lockPos = 0;


    void Start () {
		canDrop = false;
		dead = false;
		score = 0;
		truck = 1;
		life = 3;
	}

    // Update is called once per frame
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }
    }
    void Update () {
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        scoreText.text = "SCORE: " + score;
		truckText.text = "TRUCK: " + truck;
		lifeText.text = "LIFE: " + life;
		Vector3 mouse = cam.ScreenToWorldPoint (Input.mousePosition);
		mouseX = mouse.x;
		if (mouseX < -4.68f) {
			mouseX = -4.68f;
		}
		if (mouseX > 3.75f) {
			mouseX = 3.75f;
		}

		if (stackHeight >= 20) {
			truck += 1f;
			stackHeight = 0;
		}

		if (dead == true) {
			deadTime += Time.deltaTime;
			if (deadTime >= 2f) {
				playerState = 0f;
				life -= 1f;
				deadTime = 0f;
				dead = false;
			}
		}
		if (dead == false) {
			transform.position = new Vector3 (mouseX, transform.position.y, transform.position.z);
		
			if (playerState == 0f) {
				this.GetComponent<SpriteRenderer> ().sprite = idle;
			}
			if (playerState == 1f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
			}
			if (playerState == 2f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
			}
			if (playerState == 3f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
			}
			if (playerState == 4f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
			}
			if (playerState == 5f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
			}
			if (playerState == 6f) {
				this.GetComponent<SpriteRenderer> ().sprite = gold1;
				dead = true;
			}
			if (playerState < 0f) {
				playerState = 0f;
			}
		}
		if (canDrop == true) {
			if (Input.GetMouseButtonDown (0)) {
				if (playerState > 0f) {
					playerState -= 1f;
					score += 3;
					stackHeight += 1;
				}

			}
		}
		if (life <= -1) {
			life = 0;
			SceneManager.LoadScene ("Menu");
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (dead == false) {
			if (other.gameObject.tag == "gold") {
				playerState += 1f;
				score += 2;
			}
			if (other.gameObject.tag == "Ground") {
				canDrop = true;
			}
		}

		if (other.gameObject.tag == "silver") {
			if (dead == false) {
				this.GetComponent<SpriteRenderer> ().sprite = silver1;
				dead = true;
			}
		}
		if (other.gameObject.tag == "ice") {
			if (dead == false) {
				life += 1;
			}
		}

	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Ground") {
			canDrop = false;
		}
	}
}