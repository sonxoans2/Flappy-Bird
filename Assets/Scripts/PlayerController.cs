using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float tap_force = 200;
    int score=0;
    public UIController ui;
    SoundController sound;
    // Use this for initialization
    void Start () {
        sound = GetComponent<SoundController> ();
        posPlayer = transform.position;
    }
    float goc =0;
    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown (0)) {
            if(ui._state == UIController.STATE.TUTORIAL) {
                ui.UIPlay ();
            }
            if(ui._state == UIController.STATE.PLAY) {
                goc = 0;
                sound.SoundWing ();
                GetComponent<Rigidbody2D> ().isKinematic = true;
                GetComponent<Rigidbody2D> ().isKinematic = false;
                GetComponent<Rigidbody2D> ().AddForce (Vector3.up * tap_force);
                StopAllCoroutines ();
                StartCoroutine (rotate (22));
                StartCoroutine (defaultRotate ());
            }
        }
        if(GetComponent<Rigidbody2D> ().velocity.y < 0) {
            goc -= Time.deltaTime * 100;
            if(goc <= -90) goc = -90;
            StartCoroutine (rotate (goc));
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        switch(coll.gameObject.tag) {
            case "Score":
                score++;
                Debug.Log ("Score: " + score);
                ui.setScore (score);
                sound.SoundPoint ();
                break;
            case "Chimney":
                Debug.Log ("Die");
                if(ui._state == UIController.STATE.PLAY) {
                    sound.SoundHit ();
                    ui.UIGameOver (score);
                }
                break;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "Score":
                score++;
                Debug.Log ("Score: " + score);
                ui.setScore (score);
                sound.SoundPoint ();
                break;
            case "Chimney":
                Debug.Log ("Die");
                if(ui._state == UIController.STATE.PLAY) {
                    sound.SoundHit ();
                    ui.UIGameOver (score);
                }
                break;
        }
    }

    Vector3 posPlayer;
    public void reset () {
        score = 0;
        transform.position = posPlayer;
        transform.localRotation = new Quaternion (0, 0, 0, 0);
        GetComponent<Rigidbody2D> ().isKinematic = true;
    }

    IEnumerator rotate (float angel) {
        transform.localRotation = new Quaternion (0, 0, 0, 0);
        yield return new WaitForSeconds (0.01f);
        transform.Rotate (new Vector3 (0, 0, angel));
    }

    IEnumerator defaultRotate () {
        yield return new WaitForSeconds (0.2f);
        transform.localRotation = new Quaternion (0, 0, 0, 0);
    }
}
