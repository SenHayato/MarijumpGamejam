using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string[] levelScenes;
    public Button[] buttons;
    Animator animator => GetComponent<Animator>();
    public void MainMenu()
    {
        animator.SetTrigger("MainMenu");
    }
    void Awake()
    {
        Time.timeScale = 1;
        
    }
    private void Start() {
        for (int i = 0; i < levelScenes.Length; i++)
        {
            string level = levelScenes[i];
            Debug.Log($"{buttons[i].gameObject.name} load {level}");
            buttons[i].onClick.AddListener(() => SceneManager.LoadScene(level));
        }
    }
    public void LevelSelect()
    {
        animator.SetTrigger("Level");
    }
    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(levelScenes[Level]);
    }
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
        #endif
    }
}
