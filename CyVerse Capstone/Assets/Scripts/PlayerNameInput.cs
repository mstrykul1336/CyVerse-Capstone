using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
namespace CreativeSpore.RPGConversationEditor
{
    public class PlayerNameManager : MonoBehaviour
    {
        public static PlayerNameManager Instance;  // Singleton for easy access

        public GameObject namePanel;  // UI Panel for name input
        public GameObject titlePanel;
        public TMP_InputField nameInput;  // TMP Input field
        public TMP_Text nameLabel;        // TMP Text label above input field
        public string playerName = "Monte";  // Default name if none is entered
        public CanvasGroup canvasGroup;

        private void Awake()
        {
            // Singleton pattern to ensure only one instance exists
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);  // Keep player name across scenes
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            // Hide the input field and label at the start
            namePanel.SetActive(false);
            canvasGroup.alpha = 0f;
            titlePanel.SetActive(false);
        }

        public void ShowNameInput()
        {
            // Show the input field and label
            namePanel.SetActive(true);
        }
        public void ShowTitleScreen()
        {
            // Show the input field and label
            titlePanel.SetActive(true);
            StartCoroutine(FadeInAndChangeScene(2f, 4f));
        }


        public void SavePlayerName()
        {
            // Get the player's input and store it
            if (!string.IsNullOrEmpty(nameInput.text))
            {
                playerName = nameInput.text;
            }
            
            // Hide the input field and label after saving
            namePanel.SetActive(false);

            // Debug log
            Debug.Log("Player name set to: " + playerName);
        }

        // Method to replace "{PLAYER_NAME}" in dialogues
        public void ProcessDialogueText(string dialogue)
        {
            Dialog.DialogAction action = UIDialog.processedDialogAction;
            action.name = action.name.Replace("{PLAYER_NAME}", playerName);
        }
        public void WaitTime()
        {
            WaitAndContinueDialogue();
        }

        public IEnumerator WaitAndContinueDialogue()
        {
            yield return new WaitForSeconds(10f); 
            SceneManager.LoadScene (sceneBuildIndex:2); // Wait 5 seconds
        }

        IEnumerator FadeInAndChangeScene(float fadeDuration, float waitDuration)
        {
            float elapsedTime = 0f;
            float startAlpha = 0f;
            float targetAlpha = 1f;
            canvasGroup.alpha = startAlpha;

            // Fade-in effect
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
                yield return null;
            }
            canvasGroup.alpha = targetAlpha; // Ensure it ends at full opacity

            // Wait for specified duration
            yield return new WaitForSeconds(waitDuration);

            // Change scene
            SceneManager.LoadScene(2);
        }
    }
}
