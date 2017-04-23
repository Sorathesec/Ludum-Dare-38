using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WormPieceID
{
    Head, Body, Tail
}
public class WormEnemyPiece : ZombieHealth
{
    [SerializeField]
    private WormPieceID piece = WormPieceID.Body;

    public static Sprite headSprite;
    public static Sprite bodySprite;
    public static Sprite tailSprite;
    public static int headDamage;
    public static int bodyDamage;

    void Start()
    {
        ResetComponents();
    }

    protected override void Die()
    {
        ResetComponents();
        gameObject.SetActive(false);
    }

    private void ResetComponents()
    {
        switch (piece)
        {
            case WormPieceID.Head:
                MakeHead();
                break;
            case WormPieceID.Body:
                MakeBody();
                break;
            case WormPieceID.Tail:
                MakeTail();
                break;
        }
    }

    public void MakeHead()
    {
        //GetComponent<SpriteRenderer>().sprite = headSprite;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().offset = new Vector2(-0.19f, 0);
        GetComponent<CircleCollider2D>().radius = 0.18f;
        GetComponent<ZombieAttack>().attackDamage = headDamage;
        GetComponent<WormLook>().enabled = true;
        GetComponent<HingeJoint2D>().enabled = true;
    }

    public void MakeBody()
    {
        //GetComponent<SpriteRenderer>().sprite = bodySprite;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().offset = new Vector2(0.11f, 0);
        GetComponent<CircleCollider2D>().radius = 0.14f;
        GetComponent<ZombieAttack>().attackDamage = bodyDamage;
        GetComponent<WormLook>().enabled = false;
        GetComponent<HingeJoint2D>().enabled = true;
    }

    public void MakeTail()
    {
        //GetComponent<SpriteRenderer>().sprite = tailSprite;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<ZombieAttack>().attackDamage = bodyDamage;
        GetComponent<WormLook>().enabled = false;
        GetComponent<HingeJoint2D>().enabled = false;
    }
}
