using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScene1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    //public bool isGrounded = false;
    // Start is called before the first frame update
    float lockPos = 0;
    public int score = 0;
    public Text scoretext;
    public Text chancetext;
    public Text guidetext;
    public bool faceright = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setscoretext();
        guidetext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }
    }
    public void SetNextScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("gold"))
        {
            score += 1;
            col.gameObject.SetActive(false);
            setscoretext();
        }

        if (col.gameObject.tag == "door" && score == 6)
        {
            SceneManager.LoadScene(2);
        }
        if(col.gameObject.tag == "door" && score < 6)
        {
            setGuide();
        }
    }
    void setGuide()
    {
        guidetext.text = "Collect all gifts first!";
    }

    void setscoretext()
    {
        scoretext.text = "Score: " + score.ToString() + " / 6";
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}

