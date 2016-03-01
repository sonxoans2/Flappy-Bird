using UnityEngine;
using System.Collections;

public class ChimneyController : MonoBehaviour {
    float speed = 2;
    UIController ui;
    // Use this for initialization
    void Start () {
        ui = FindObjectOfType<UIController> ();
    }

    // Update is called once per frame
    void Update () {
        if(ui._state == UIController.STATE.PLAY) {
            transform.Translate (-Vector3.right * Time.deltaTime * speed);
        }
        if(transform.position.x <= -10) {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        switch(coll.gameObject.tag) {
            case "BoxLeft":
                Destroy (gameObject);
                break;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "BoxLeft":
                Destroy (gameObject);
                break;
        }
    }
}
