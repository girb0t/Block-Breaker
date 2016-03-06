using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		// print("load level " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

  public void LoadNextLevel() {
    // Level 2 not loading after Level 1 victory. Investigate.
    Application.LoadLevel(Application.loadedLevel + 1);
  }

  public void BrickDestroyed() {
    if (Brick.breakableCount <= 0) {
      LoadNextLevel();
    }
  }
}
