//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System;

//public class GameController {
//    private static GameController _instance = null;
//    public static GameController instance {
//        get {
//            if(_instance == null) {
//                _instance = new GameController ();
//            }

//            return _instance;
//        }
//    }
//    int state = 0;//0 = ko lam gi, 1 = tutorial, 2 = play, 3 = game over

//    public void setState (int stateNew) {
//        state = stateNew;
//    }
//    public int getState () {
//        return state;
//    }
//}
