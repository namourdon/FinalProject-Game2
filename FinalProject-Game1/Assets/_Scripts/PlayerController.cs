using UnityEngine;
using System.Collections;
public class DRift
    {
        public float minDrift, maxDrift;
    }
public class PlayerController : MonoBehaviour {

    public float mSpeed;
    public DRift drift;
    private bool _facingRight = true;
    private Transform _transform;
    private Vector2 newPosition = new Vector2(0.0f, 0.0f);
    void Start()
    {
        this._transform = gameObject.GetComponent<Transform>();

    }
    void Update()
    {
        this._CheckMove();
    }
    private void _CheckMove()
    {
        newPosition = gameObject.GetComponent<Transform>().position;


        if (Input.GetAxis("Horizontal") > 0)
        {
            newPosition.x += this.mSpeed;
            gameObject.GetComponent<Transform>().position = newPosition;
            this._facingRight = true;
            this._flip();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            newPosition.x -= this.mSpeed;
            gameObject.GetComponent<Transform>().position = newPosition;
            this._facingRight = false;
            this._flip();
        }
        this.BoundaryCheck();
        gameObject.GetComponent<Transform>().position = newPosition;
    }
    private void BoundaryCheck()
    {
        if (this.newPosition.x < this.drift.minDrift)
        {
            this.newPosition.x = this.drift.minDrift;
        }
        if (this.newPosition.x > this.drift.maxDrift)
        {
            this.newPosition.x = this.drift.maxDrift;
        }
    }
    private void _flip() {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            this._transform.localScale = new Vector2(-1f, 1f);
        }
    }

}
