using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemy : MonoBehaviour
{
    private WormEnemyPiece[] pieces;
    [SerializeField]
    private Sprite headSprite;
    [SerializeField]
    private Sprite bodySprite;
    [SerializeField]
    private Sprite tailSprite;
    [SerializeField]
    private int headDamage;
    [SerializeField]
    private int bodyDamage;

    private int head;
    private int tail;

    void Awake()
    {
        WormEnemyPiece.headSprite = headSprite;
        WormEnemyPiece.bodySprite = bodySprite;
        WormEnemyPiece.tailSprite = tailSprite;
        WormEnemyPiece.headDamage = headDamage;
        WormEnemyPiece.bodyDamage = bodyDamage;
    }

    // Use this for initialization
    void Start ()
    {
        pieces = GetComponentsInChildren<WormEnemyPiece>();

        head = 0;
        tail = pieces.Length - 1;
	}

    public void PieceDied(WormEnemyPiece piece)
    {
        if(head == tail - 1)
        {
            Destroy(gameObject);
        }
        if(pieces[head] == piece)
        {
            HeadDied();
        }
        else if(pieces[tail] == piece)
        {
            TailDied();
        }
        /*
        else
        {
            BodyDied(piece);
        }
        */
    }

    private void HeadDied()
    {
        pieces[head].GetComponent<HingeJoint2D>().connectedBody = null;
        head++;
        pieces[head].MakeHead();
        pieces[head].GetComponent<HingeJoint2D>().connectedBody = pieces[head + 1].GetComponent<Rigidbody2D>();
    }

    /*
    private void BodyDied(WormEnemyPiece piece)
    {
        for(int i = 0; i < pieces.Length; i++)
        {
            if(pieces[i] == piece)
            {
                print("foundPiece");
                int count1 = 1;
                int count2 = 1;
                bool beforeDone = false;
                bool afterDone = false;
                bool success = false;
                while (!success)
                {
                    if (!beforeDone && !pieces[i - count1].dead)
                    {
                        print("notdead " + count1);
                        beforeDone = true;
                    }
                    else
                    {
                        print("counting1");
                        count1++;
                    }
                    
                    if (!afterDone && !pieces[i + count2].dead)
                    {
                        print("notdead2" + count2);
                        afterDone = true;
                    }
                    else
                    {
                        print("counting2");
                        count2++;
                    }
                    print(beforeDone + " " + afterDone);
                    if(beforeDone && afterDone)
                    {
                        pieces[i - count1].GetComponent<HingeJoint2D>().connectedBody = pieces[i + count2].GetComponent<Rigidbody2D>();
                        success = true;
                    }
                }
            }
        }
    }
    */

    private void TailDied()
    {
        tail--;
        pieces[tail].MakeTail();
        pieces[tail].GetComponent<HingeJoint2D>().connectedBody = null;
    }
}