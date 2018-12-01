using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmiyaGames;
using OmiyaGames.Menus;

[RequireComponent(typeof(BoxCollider))]
public class Npc : MonoBehaviour
{
    [SerializeField]
    string testDialog = "hOi!";
    [SerializeField]
    float testPauseDuration = 2;

    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")) && (triggered == false))
        {
            StartCoroutine(BriefPause());
        }
    }

    IEnumerator BriefPause()
    {
        triggered = true;
        UnityStandardAssets._2D.PlatformerCharacter2D.Instance.IsInControl = false;
        ulong id = Singleton.Get<MenuManager>().PopUps.ShowNewDialog(testDialog);
        yield return new WaitForSeconds(testPauseDuration);
        Singleton.Get<MenuManager>().PopUps.RemoveDialog(id);
        UnityStandardAssets._2D.PlatformerCharacter2D.Instance.IsInControl = true;
        triggered = false;
    }
}
