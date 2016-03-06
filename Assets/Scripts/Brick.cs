using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
  public static int breakableCount = 0;
  public Sprite[] hitSprites;

  private int timesHit = 0;
  private LevelManager levelManager;
  private bool isBreakable;

	// Use this for initialization
	void Start () {
    isBreakable = (this.tag == "Breakable");
    levelManager = GameObject.FindObjectOfType<LevelManager>();
    if (isBreakable) {
      breakableCount++;
    }
  }

  // Update is called once per frame
  void Update () {
  }

  void OnCollisionEnter2D(Collision2D coll) {
    if (isBreakable) {
      HandleHits();
    }
  }

  void HandleHits() {
    timesHit++;
    int maxHits = hitSprites.Length + 1;
    if (timesHit >= maxHits) {
      breakableCount--;
      Destroy(gameObject);
      levelManager.BrickDestroyed();
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
