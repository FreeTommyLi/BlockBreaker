using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    [SerializeField] AudioClip crack;
    [SerializeField] AudioClip lowboom;

    private int maxHits;
    private int timesHit;
    private SceneLoader sceneWin;
    private bool isBreakable;
    public static int totalBreakableBrick = 0;

    public Sprite[] hitSprites;


	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            totalBreakableBrick++;
            Debug.Log(totalBreakableBrick);
        }
        timesHit = 0;
        maxHits = hitSprites.Length + 1;
        sceneWin = GameObject.FindObjectOfType<SceneLoader>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            AudioSource.PlayClipAtPoint(crack, transform.position, 3.5f);
            HandleHits();
        } else {
            AudioSource.PlayClipAtPoint(lowboom, transform.position, 3.5f);
        }

    }

    void HandleHits() {
        timesHit++;
        if (maxHits == timesHit) {

            Destroy(gameObject);
            totalBreakableBrick--;
            Debug.Log(totalBreakableBrick);

        }
        else {
            LoadSprites();
        }
        SimulateWin();

    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    void SimulateWin() {


        sceneWin.BrickDestroy();

    }


}
