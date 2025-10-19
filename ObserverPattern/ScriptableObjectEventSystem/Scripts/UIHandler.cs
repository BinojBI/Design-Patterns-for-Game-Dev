using System.Collections;
using TMPro;
using UnityEngine;

namespace ScritptbaleObjectEventSystem
{
    public class UIHandler : MonoBehaviour
    {
        public TextMeshProUGUI jumpMessageText; 
        public float messageDuration = 1.5f;

        private Coroutine hideCoroutine;

        public void ShowJumpMessage()
        {
            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            jumpMessageText.text = "Jump!";
            jumpMessageText.enabled = true;

            hideCoroutine = StartCoroutine(HideAfterDelay());
        }

        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(messageDuration);
            jumpMessageText.enabled = false;
        }
    }
}
