using UnityEngine;
using System.Collections;

public class RepeateForever : MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    //Renderer r;
    void Start () {
        startPosition = transform.position;
        //r = GetComponent<Renderer> ();
    }

    void Update () {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition - Vector3.right * newPosition;
        //r.material.mainTextureOffset = new Vector2 (Time.deltaTime * scrollSpeed, 0);
    }
}
