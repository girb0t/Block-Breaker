using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
  private int timesHit = 0;
  private LevelManager levelManager;
  public Sprite[] hitSprites;

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
    int maxHits = hitSprites.Length + 1;
    if (timesHit >= maxHits) {
      Destroy(gameObject);
      // SimulateWin();
    } else {
      LoadSprites();
    }
  }

  void LoadSprites () {
    int spriteIndex = timesHit - 1;
    if (hitSprites[spriteIndex]) {
      this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
  }

  // TODO Remove this method when we can actually win.
  void SimulateWin() {
    levelManager.LoadNextLevel();
  }
}
