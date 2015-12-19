using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager boardScript;
    public int fixedWindows=0;
    public float turnDelay = 7f;
    public GameObject cam;

    private bool level = false;
  //  private bool playerTurn = true;
    private bool enemiesMoving = false;
    private float levelUp = 2f;
    private Enemy ralph;
    private Player player;


    void Awake() {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        ralph = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        InitGame();
        cam = GameObject.Find("Camera");
    }

    void InitGame() {
        boardScript.SetupScence(level, levelUp);
        level = true;
        levelUp += 10.2f;
    }

    public void NewGame(){
        boardScript.SetupScence(level, levelUp);
        levelUp += 10.2f;
        //slide camera up words 
        float add = 8f,ralphAdd=8f;
        fixedWindows = 0;
        player.newPos += 7.8f;
        if (level) {
            add = 7.6f;
            ralphAdd = 7.6f;
        }
        ralph.GetUp(ralphAdd);
        cam.transform.Translate(0f, add, 0f);
        player.ChangePlayer();
        
    }

    void Update() {
        if ( enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());

    }

    IEnumerator MoveEnemies(){
        enemiesMoving = true;
        ralph.Move();
        yield return new WaitForSeconds(turnDelay);
        ralph.Attack();
        enemiesMoving = false;
    }


}
