using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int playerMovesHorizontal = 0;
    public int maxMoveHorizontal = 2;
    public int minMoveHorizontal = -2;

    public int playerMovesVertical = 0;
    public int maxMoveVertical = 2;
    public int minMoveVertical = 0;

    private Animator anim;
    private Transform pos;

    private Collider2D enter;
    public float newPos;


    void Start() {
        anim = GetComponent<Animator>();
        pos = GetComponent<Transform>();
        enter = null;
        newPos = transform.position.y;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) && playerMovesHorizontal < maxMoveHorizontal) {
            anim.SetTrigger("Jump");
            pos.Translate(new Vector3(1.7f,0f, 0f));
            ++playerMovesHorizontal;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerMovesHorizontal > minMoveHorizontal){
            anim.SetTrigger("Jump");
            pos.Translate(new Vector3(-1.7f, 0f, 0f));
            --playerMovesHorizontal;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && playerMovesVertical < maxMoveVertical)
        {
            anim.SetTrigger("Jump");
            pos.Translate(new Vector3(0f, 2.6f, 0f));
            ++playerMovesVertical;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && playerMovesVertical > minMoveVertical)
        {
            anim.SetTrigger("Jump");
            pos.Translate(new Vector3(0f, -2.6f, 0f));
            --playerMovesVertical;
        }

        if (Input.GetKeyDown(KeyCode.Space) && enter != null){
            anim.SetTrigger("Fix");
            enter.gameObject.GetComponent<Windows>().FixWindow();

            if (GameManager.instance.fixedWindows == 15){
                GameManager.instance.NewGame();
            }

        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.tag == "Win")
                 enter = other;
        if (other.gameObject.tag == "Stone"){
            anim.SetTrigger("Die");


            Invoke("Destroy", 2f);
        }
        //  GameManager.instance.enabled = false;
        
    }

    public void ChangePlayer() {
        playerMovesHorizontal = 0;
        playerMovesVertical = 0;
        transform.position = new Vector3(0f,newPos ,0f);
    }
    void Destroy() {
        Destroy(gameObject);
        GameManager.instance.enabled = false;
        
    }
}
