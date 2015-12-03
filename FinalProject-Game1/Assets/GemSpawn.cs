using UnityEngine;
using System.Collections;

public class GemSpawn : MonoBehaviour {

    public float speed;
    // Use this for initialization
    void Start()
    {
        this.Reset();
    }

    // Update only once per frame
    void Update()
    {
        Vector2 currentPositon = new Vector2(0.0f, 0.0f);
        currentPositon = gameObject.GetComponent<Transform>().position;
        currentPositon.x -= speed;
        gameObject.GetComponent<Transform>().position = currentPositon;

        if (currentPositon.x <= -990)
        {
            this.Reset();
        }

    }
    private void Reset()
    {
        Vector2 resetBackground = new Vector2(990f, Random.Range(-490f, 490f));
        gameObject.GetComponent<Transform>().position = resetBackground;
    }
}
