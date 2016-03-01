using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    public GameObject _main, _tutorial, _board;
    public Text txt_score;
    public PlayerController player;
    public GenChimney genChimney;

    void startup () {
        genChimney.clearList ();
        player.reset ();
        setScore (0);
    }

    public enum STATE {
        NONE = 0,
        TUTORIAL = 1,
        PLAY = 2,
        GAMEOVER = 3
    }

    public STATE _state;// = STATE.NONE;
    // Use this for initialization
    void Start () {
        UIHome ();
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown (KeyCode.Escape)) {
            back ();
        }
    }

    void back () {
        switch(_state) {
            case STATE.NONE:
                Application.Quit ();
                break;
            case STATE.TUTORIAL:
            case STATE.PLAY:
            case STATE.GAMEOVER:
                UIHome ();
                break;
        }
    }

    public void UIHome () {
        _state = STATE.NONE;

        _main.SetActive (true);
        txt_score.gameObject.SetActive (false);
        _tutorial.SetActive (false);
        _board.SetActive (false);

        startup ();
    }

    public void UITutorial () {
        _state = STATE.TUTORIAL;

        _main.SetActive (false);
        txt_score.gameObject.SetActive (false);
        _tutorial.SetActive (true);
        _board.SetActive (false);

        startup ();
    }

    public void UIPlay () {
        _state = STATE.PLAY;

        _main.SetActive (false);
        txt_score.gameObject.SetActive (true);
        _tutorial.SetActive (false);
        _board.SetActive (false);

        startup ();
    }

    public void UIGameOver (int score) {
        if(_state != STATE.GAMEOVER) {
            _state = STATE.GAMEOVER;

            _main.SetActive (false);
            txt_score.gameObject.SetActive (false);
            _tutorial.SetActive (false);
            _board.SetActive (true);
            _board.GetComponent<BoardScore> ().setInfo (score);
        }
    }

    public void onClick (string name) {
        switch(name) {
            case "Play":
                UITutorial ();
                break;
            case "Home":
                UIHome ();
                break;
        }
    }

    public void setScore (int score) {
        txt_score.text = score + "";
    }
}
