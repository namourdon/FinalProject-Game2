using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float mSpeed;
    public DRift drift;
    private Vector2 newPosition = new Vector2(0.0f, 0.0f);
    void Start()
    {

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
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            newPosition.x -= this.mSpeed;
            gameObject.GetComponent<Transform>().position = newPosition;
        }
        this.BoundaryCheck();
        gameObject.GetComponent<Transform>().position = newPosition;
    }
    private void BoundaryCheck()
    {
        if (this.newPosition.y < this.drift.minDrift)
        {
            this.newPosition.y = this.drift.minDrift;
        }
        if (this.newPosition.y > this.drift.maxDrift)
        {
            this.newPosition.y = this.drift.maxDrift;
        }
    }
    public class DRift
    {
        public float minDrift, maxDrift;
    }

}
