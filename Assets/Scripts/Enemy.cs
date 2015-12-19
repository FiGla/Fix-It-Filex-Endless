using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public GameObject blocks;
    public Transform target1;
    public Transform target2;
    

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    /*
        IEnumerator MyCoroutine(Transform target){
            if (target.position.x > target1.position.x) target = target1;
            else if (target.position.x < target2.position.x) target = target2;

            while (Mathf.Abs(Vector3.Distance(transform.position, target.position)) >= 0.05f)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
                yield return null;
            }
            transform.position = target.position;
        }
        */
    public void Move(){
        anim.SetTrigger("Move");
        float newPlace = Random.Range(target2.position.x, target1.position.x);
        transform.position = (new Vector3(newPlace, transform.position.y, transform.position.z));
    }

    public void Attack(){
    //    anim.SetTrigger("Attack");
        float numBlocks = Random.Range(2, 6);
        for (float i = 0,j=0.3f; i < numBlocks; ++i,j*=-1){
            Instantiate(blocks,new Vector3(transform.position.x+j,transform.position.y,transform.position.z),Quaternion.identity);

        }

    }
    public void GetUp(float ralph){
        transform.Translate(0f, ralph, 0f);

    }
}