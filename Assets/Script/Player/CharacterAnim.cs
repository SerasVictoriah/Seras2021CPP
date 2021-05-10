using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour {

    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }
    void Update() {
        // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
        //     anim.SetBool("isRunning", true);
        // }
        //  else
        //  {
        //      anim.SetBool("isRunning", false);
        // }

        //if (Input.GetKeyDown(KeyCode.Space)){
        //anim.SetTrigger("jump");
        // }
         if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.E)) {
             anim.SetBool("isAttacking", true);
         }
          else
          {
              anim.SetBool("isAttacking", false);
        }
    }
}
