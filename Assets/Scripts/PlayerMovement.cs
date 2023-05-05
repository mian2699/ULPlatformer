using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed =5f;

    [SerializeField]
    private float jumSpeed =10f;
    private Vector2 mMoveInput;
    private Rigidbody2D mRb;

    private Animator mAnimator;

    private CapsuleCollider2D mCollider;

    private bool IsJumping ;



    private void Start(){

        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mCollider = GetComponent<CapsuleCollider2D>();



    }

    private void Update()
    {
        mRb.velocity = new Vector2(
            runSpeed*mMoveInput.x,
            mRb.velocity.y);
      if (Mathf.Abs(mRb.velocity.x) > Mathf.Epsilon){

             transform.localScale=new Vector3(
            Mathf.Sign(mRb.velocity.x),
            transform.localScale.y,
            transform.localScale.z
              //cambiar la animacion
       
            );
        mAnimator.SetBool("IsRunning",true);

        }else{

        mAnimator.SetBool("IsRunning",false);
        }

        if (mRb.velocity.y < 0f){
            //comienza a cer
             mAnimator.SetBool("IsJumping",false);
             mAnimator.SetBool("IsFalling",true);

        }

         if ( mCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
         {
                    // tococ suelo
                 mAnimator.SetBool("IsFalling",false);
               //  mAnimator.SetBool("IsJumping",false);
         }    
         
         /*if (IsJumping){

             mAnimator.SetBool("IsJumping",true);
         }*/
         


    }

    private void OnMove(InputValue value)
    {
         mMoveInput = value.Get<Vector2>();
       // Debug.Log(movInput);
    }

     private void OnJump(InputValue value)
    {
        //verificar si estamos en pleno salto o no

     if ( mCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))

     {
        if ( value.isPressed)
        {
        //SALTAR
        mRb.velocity = new Vector2(
            mRb.velocity.x,
                jumSpeed
        );
               mAnimator.SetBool("IsJumping",true);
          //  IsJumping = true;

            
        }

     }




      

  
       // Debug.Log(movInput);
    }


}
