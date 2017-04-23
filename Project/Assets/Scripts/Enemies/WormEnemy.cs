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

    // Use this for initialization
    void Start ()
    {
        WormEnemyPiece.headSprite = headSprite;
        WormEnemyPiece.bodySprite = bodySprite;
        WormEnemyPiece.tailSprite = tailSprite;
        WormEnemyPiece.headDamage = headDamage;
        WormEnemyPiece.bodyDamage = bodyDamage;

        pieces = GetComponentsInChildren<WormEnemyPiece>();
	}
}