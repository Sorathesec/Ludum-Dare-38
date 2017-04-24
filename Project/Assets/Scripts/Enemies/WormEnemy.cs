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
    void Start()
    {
        pieces = GetComponentsInChildren<WormEnemyPiece>();

        head = 0;
        tail = pieces.Length - 1;
    }

    public void PieceDied(WormEnemyPiece piece)
    {
        if (piece.currentPiece == WormPieceID.Body)
        {
            print(piece.currentPiece);
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] == piece)
                {
                    if (i == 1)
                    {
                        pieces[i - 1].KillMe();
                    }
                    else
                    {
                        pieces[i - 1].MakeTail();
                        pieces[i - 1].currentPiece = WormPieceID.Tail;
                    }

                    if (i == pieces.Length - 2)
                    {
                        pieces[i + 1].KillMe();
                    }
                    else
                    {
                        pieces[i + 1].MakeHead();
                        pieces[i + 1].currentPiece = WormPieceID.Head;
                    }
                }
            }
        }
        else if (piece.currentPiece == WormPieceID.Head)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] == piece)
                {
                    if(i + 2 >= pieces.Length || pieces[i + 2].dead)
                    {
                        if (i > 0)
                        {
                            pieces[i - 1].KillMe();
                        }
                    }
                    else
                    {
                        pieces[i + 1].MakeHead();
                        pieces[i + 1].currentPiece = WormPieceID.Head;
                    }
                }
            }
        }
        else if (piece.currentPiece == WormPieceID.Tail)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] == piece)
                {
                    if (i - 2 < 0 || pieces[i - 2].dead)
                    {
                        print("Tail ");
                        pieces[i - 1].KillMe();
                    }
                    else
                    {
                        pieces[i - 1].MakeTail();
                        pieces[i - 1].currentPiece = WormPieceID.Tail;
                    }
                }
            }
        }

        bool success = true;
        for(int i = 0; i < pieces.Length; i++)
        {
            if(!pieces[i].dead)
            {
                success = false;
            }
        }

        if (success == true)
        {
            Destroy(gameObject);
            ZombieSpawner.wormAlive = false;
        }
    }
}