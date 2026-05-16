using TMPro;
using UnityEngine;

public class DialogueLinesController : MonoBehaviour
{
[SerializeField] TMP_Text dialogueLine;
[SerializeField] string[] timeLineTextLines;
int currentDialogueLine = 0;

public void NextDialogueLine()
{
    dialogueLine.text = timeLineTextLines[currentDialogueLine];
    currentDialogueLine++;
}

}
