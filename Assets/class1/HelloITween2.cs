using UnityEngine;
using System.Collections;

public class HelloITween2 : MonoBehaviour {

	// Use this for initialization
    Hashtable htl = new Hashtable();
	void Start () {
        htl.Add("x",3);
        htl.Add("time",2);
        //延时：停留多久
        htl.Add("delay",1);
        //循环模式
        htl.Add("looptype",iTween.LoopType.pingPong);

        iTween.MoveTo(this.gameObject,htl);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
