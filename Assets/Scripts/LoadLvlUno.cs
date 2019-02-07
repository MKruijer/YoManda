using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvlUno : MonoBehaviour {
	public string LevelUno;

	public void LoadSceneUno() {
		SceneManager.LoadScene(LevelUno);
	}
}
