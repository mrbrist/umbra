using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animation anim;
    public SpriteRenderer sr;
    public BoxCollider2D col;

    private bool isAttacking;
    private bool attackOnCooldown;
    public float attackCooldownTime;

    public Sprite leftUpAttack;
    public Sprite leftDownAttack;
    public Sprite rightUpAttack;
    public Sprite rightDownAttack;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking && !attackOnCooldown)
        {
            isAttacking = true;

            // Get the player's position in screen space
            Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);

            // Get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Check if the mouse is on the left or right side of the player
            bool isMouseOnLeftSide = mousePosition.x < playerScreenPos.x;
            bool isMouseOnRightSide = mousePosition.x > playerScreenPos.x;

            // Check if the mouse is on the top or bottom half of each side
            bool isMouseOnTopHalf = mousePosition.y > playerScreenPos.y;
            bool isMouseOnBottomHalf = mousePosition.y < playerScreenPos.y;

            // Determine the outcome based on the side and half
            if (isMouseOnLeftSide && isMouseOnTopHalf)
            {
                // Mouse is on the top-left side
                sr.sprite = leftUpAttack;
                sr.sortingOrder = 5;
                OffsetAttackCollider(-0.5f, 0.5f);
            }
            else if (isMouseOnLeftSide && isMouseOnBottomHalf)
            {
                // Mouse is on the bottom-left side
                sr.sprite = leftDownAttack;
                sr.sortingOrder = 50;
                OffsetAttackCollider(-0.5f, -0.5f);
            }
            else if (isMouseOnRightSide && isMouseOnTopHalf)
            {
                // Mouse is on the top-right side
                sr.sprite = rightUpAttack;
                sr.sortingOrder = 5;
                OffsetAttackCollider(0.5f, 0.5f);
            }
            else if (isMouseOnRightSide && isMouseOnBottomHalf)
            {
                // Mouse is on the bottom-right side
                sr.sprite = rightDownAttack;
                sr.sortingOrder = 50;
                OffsetAttackCollider(0.5f, -0.5f);
            }

            StartCoroutine("attackTime");
        }
    }

    IEnumerator attackTime ()
    {
        anim.Play();
        anim.Rewind();
        yield return new WaitForSeconds(0.2f);
        sr.sprite = null;
        col.enabled = false;
        isAttacking = false;
        attackOnCooldown = true;
        StartCoroutine("attackCooldown");
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownTime);
        attackOnCooldown = false;
    }

    private void OffsetAttackCollider(float x, float y)
    {
        col.enabled = true;
        col.offset = new Vector2(x, y);
    }
}
