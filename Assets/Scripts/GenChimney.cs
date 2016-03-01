using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenChimney : MonoBehaviour {
    public UIController ui;
    public GameObject chimbeyPrefabs;
    float time = 0;
    float timeMax = 1.8f;

    public float chimney_force = 100;

    float ymin = -1.5f, ymax = 3.5f;

    List<GameObject> chimneysList;

    // Use this for initialization
    void Awake () {
        chimneysList = new List<GameObject> ();
    }

    // Update is called once per frame
    void Update () {
        if(ui._state == UIController.STATE.PLAY) {
            time += Time.deltaTime;
            if(time >= timeMax) {
                time = 0;
                Vector3 vt = transform.position;
                vt.y = Random.Range (ymin, ymax);
                GameObject obj = (GameObject) Instantiate (chimbeyPrefabs, vt, transform.rotation);
                chimneysList.Add (obj);
            }
            //obj.GetComponent<Rigidbody2D> ().AddForce (-Vector3.right * chimney_force);
        }
    }

    public void clearList () {
        foreach(GameObject o in chimneysList)
            Destroy (o);

        chimneysList.Clear ();
    }
}
