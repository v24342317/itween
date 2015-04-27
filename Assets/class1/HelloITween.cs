using UnityEngine;
using System.Collections;

public class HelloITween : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //当前的物体5秒移动到3.3.3的坐标
        iTween.MoveTo(this.gameObject,new Vector3(3,3,3),5f);
	}
}
