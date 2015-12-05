using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float mSpeed;
    public Text score;
    public Text lives;
    public int initialScore = 0;
    public int livesAmount = 5;
    private Transform _transform;
    private Vector2 newPosition = new Vector2(0.0f, 0.0f);
    private AudioSource[] _AudioSources; //collection of the sources
    private AudioSource _EnemyAudio, _GemAudio, _playerSound;
    void Start()
    {
       this._transform = gameObject.GetComponent<Transform>();

    }
    void Update()
    {
        this._AudioSources = this.GetComponents<AudioSource>();
        this._EnemyAudio = this._AudioSources[0]; //reference enemy sound
        this._GemAudio = this._AudioSources[1]; // refers to gem collect sound
        this._CheckMove();
    }
    private void _CheckMove()
    {
        newPosition = gameObject.GetComponent<Transform>().position;


        if (Input.GetAxis("Horizontal") > 0)
        {
            newPosition.x += this.mSpeed;
            gameObject.GetComponent<Transform>().position = newPosition;
            //this._facingRight = true;
            //this._flip();
        }
            //if (Input.GetAxis("Horizontal") < 0)
            //{
            //    newPosition.x -= this.mSpeed;
            //    gameObject.GetComponent<Transform>().position = newPosition;
            //    //this._facingRight = false;
            //    //this._flip();
            //}

    }
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("gem"))
        {
            this._GemAudio.Play();
            this.initialScore += 10;
        }
        if (otherCollider.gameObject.CompareTag("enemy"))
        {
            this._EnemyAudio.Play();
            this.livesAmount--;
            if (this.livesAmount <= 0)
            {
                this._EndGame();
            }


        }
        this.FinalScore();
        /// private void _flip() {
        //     if (this._facingRight)
        //     {
        //         this._transform.localScale = new Vector2(1f, 1f);
        //     }
        //     else
        //     {
        //         this._transform.localScale = new Vector2(-1f, 1f);
        //     }
        // }

    }
    private void FinalScore()
    {
        this.score.text = "Score:" + this.initialScore;
        this.lives.text = "Lives:" + this.livesAmount;
    }
    private void _EndGame()
    {

        Destroy(gameObject);
        this.score.enabled = false;
        this.lives.enabled = false;
        //this.gameOver.enabled = true;
       // this.StartGame.enabled = true;
        //this.StartGame.text = "Score: " + this.initialScore;
    }
}
