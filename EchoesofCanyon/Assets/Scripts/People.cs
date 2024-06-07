using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class People : MonoBehaviour
{
    public GameObject dialogueBox;
    private float typingSpeed = 0.05f; 
    private string[] allTexts = 
    {
        "The key to your escpae lies somewhere within that village there", 
        "Beware of the quick sand! You'll sink in there", 
        "These tents are not only a refugee but a source of food and health",
        "Hello there, I hear you're stuck in this canyon. Worry not! My friends and I will help you find the right key and get you out of here",
        "Here's how it works; find the key before time runs out or accept defeat",
        "Let me fill you in on a secret. There are five keys in the canyon; finding one is the answer to your escape",
        "Remember you don't know how to swim; you'll have to risk your health"
    };

    private string currentText = " ";
    private Text textBox;
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        textBox = dialogueBox.GetComponentInChildren<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            
            typingCoroutine = StartCoroutine(TypeText(allTexts[int.Parse(gameObject.name)]));
            FindObjectOfType<GameManager>().pauseTimer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            FindObjectOfType<GameManager>().pauseTimer = false;
            textBox.text = " ";
            currentText = " ";
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
            }
        }
    }

    IEnumerator TypeText(string fullText)
    {
        currentText = "";  
        foreach (char letter in fullText)
        {
            currentText += letter;
            textBox.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
