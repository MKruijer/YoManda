 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class LoadLvlUno : MonoBehaviour {
 
     public void LoadSceneOnClick(int sceneNo)
     {
         SceneManager.LoadScene(sceneNo);
     }
 
 }