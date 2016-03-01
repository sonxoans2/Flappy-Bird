using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardScore : MonoBehaviour {

    public Sprite[] medals;
    public Image medal;
    public Text textScore, textBestScore;
    public GameObject textnew;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setInfo (int score) {
        int med = 0;
        medal.gameObject.SetActive (true);
        if(score < 10) {
            medal.gameObject.SetActive (false);
        } else if(score < 20) {
            med = 0;
        } else if(score < 30) {
            med = 1;
        } else if(score < 40) {
            med = 2;
        } else {
            med = 3;
        }

        medal.sprite = medals[med];
        textScore.text = score + "";
        textnew.SetActive (false);
        int bs = PlayerPrefs.GetInt ("BestScore");
        if(score >= bs) {
            textnew.SetActive (true);
            bs = score;
            PlayerPrefs.SetInt ("BestScore", bs);
            PlayerPrefs.Save ();
        }

        textBestScore.text = bs + "";
    }
}
