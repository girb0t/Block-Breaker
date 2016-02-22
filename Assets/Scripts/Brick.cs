using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
  public int maxHits;
  private int timesHit = 0;
  private LevelManager levelManager;
	// Use this for initialization
	void Start () {
    levelManager = GameObject.FindObjectOfType<LevelManager>();
  }

  // Update is called once per frame
  void Update () {
  }

  void OnCollisionEnter2D(Collision2D coll) {
    // Destroy(gameObject);
    timesHit++;
    if (timesHit == maxHits) {
      Destroy(gameObject);
      SimulateWin();
    }
  }

  // TODO Remove this method when we can actually win.
  void SimulateWin() {
    levelManager.LoadNextLevel();
  }
}
