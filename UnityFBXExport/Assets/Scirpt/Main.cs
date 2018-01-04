using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, 100, 100), "ExportFBX")) {
			MyExport myExport = new MyExport ();
			//myExport.Init ();
			myExport.CreateDocument ();
			myExport.Clear ();
		}
	}
}
