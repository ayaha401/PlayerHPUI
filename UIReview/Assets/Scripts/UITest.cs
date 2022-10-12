using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.PlayerHP;

public class UITest : MonoBehaviour
{
    [SerializeField] PlayerHPUI playerHPUI = null;

    private const int MAX_HP = 100;
    private const int DAMAGE = 10;
    private const int RECOVERY = 10;
    private int currentHP = 100;

    private Vector2 playerPos = Vector2.zero;

    void Start()
    {
        playerHPUI.DrawInitHP(MAX_HP, currentHP);
    }

    void Update()
    {
        // É_ÉÅÅ[ÉW
        if(Input.GetMouseButtonDown(0))
        {
            currentHP -= DAMAGE;
            playerHPUI.DrawDamageHP(MAX_HP, currentHP, playerPos, DAMAGE);
        }

        // âÒïú
        if (Input.GetMouseButtonDown(1))
        {
            currentHP += RECOVERY;
            playerHPUI.DrawRecoveryHP(MAX_HP, currentHP, playerPos, RECOVERY);
        }
    }
}
