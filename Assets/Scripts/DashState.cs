using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class DashState : PlayerState
{
    public float dashDuration = 0.5f;
    public Vector2 dashDirection;
    float horizontalInput = Input.GetAxis("Horizontal");
        
    public override void EnterState(PlayerController player)
    {
       // TryPlayAnimation(player, "Jump");
       /* Debug.Log("▶️ Entered Dashing State");
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            dashDirection = new Vector2(Mathf.Sin(horizontalInput), 0f);
        }
        else
        {
            dashDirection = new Vector2(player.spriteRenderer.flipX ? -1f : 1f, 0);
        }
        Vector2 velocity = dashDirection * player.dashForce;
        player.rb.linearVelocity = new Vector2(velocity.x, 0f);
        //player.rb.gravityScale = 0f;
        EventManager.TriggerEvent("OnPlayerDashed");*/


        //Debug.Log($"applying dashForce:{dashForce}");

        // Debug.Log($"velocity before dash:{velocity}");
        // velocity.x = player.horizontal * player.dashForce;
        //Debug.Log($"velocity after dash:{velocity}");
        // player.rb.linearVelocity = velocity;
        //  player.moveDirection = ;
       // player.rb.linearVelocity = new Vector3( player.moveDirection.x*Time.deltaTime,0,0);
        player.transform.position = new Vector3( player.moveDirection.x, 0,0);
        // player.

        // dashWait();

    }
    private IEnumerator dashWait()
    {
        yield return new WaitForSeconds(dashDuration);

    }

    public override void UpdateState(PlayerController player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = player.rb.linearVelocity;
        velocity.x = horizontal * player.moveSpeed;
        player.rb.linearVelocity = velocity;

        if (horizontal < 0)
            player.spriteRenderer.flipX = true;
        else if (horizontal > 0)
            player.spriteRenderer.flipX = false;

         if (player.IsGrounded() && player.rb.linearVelocity.y <= 0)
         {
             Debug.Log("🏁 Landed!");
             if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
             {
                 player.ChangeState(new MovingState());
             }
             else
             {
                 player.ChangeState(new IdleState());
             }
         } 

        if (Input.GetKeyDown(KeyCode.F))
        {
            player.Fire();
        }

    }

    public override void ExitState(PlayerController player)
    {
        Debug.Log("⏹️ Exited Dashing State");
    }

    public override string GetStateName() => "Dashing";

    private void TryPlayAnimation(PlayerController player, string animName)
    {
        if (player.animator != null &&
            player.animator.runtimeAnimatorController != null &&
            player.animator.isActiveAndEnabled)
        {
            try
            {
                player.animator.Play(animName);
            }
            catch
            {
                // Animation doesn't exist - continue without it
            }
        }
    }
}