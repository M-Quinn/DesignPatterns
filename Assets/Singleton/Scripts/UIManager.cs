using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _scoreText, _sceneText;
    Stats_Singleton _statInstance;
    private void Start()
    {
        _statInstance = Stats_Singleton.getInstance;
        UpdateText(_scoreText, _statInstance.GetCoins().ToString());
        UpdateText(_sceneText, SceneManager.GetActiveScene().buildIndex.ToString());
    }
    public void AddCoins() {
        _statInstance.UpdateCoins(1);
        UpdateText(_scoreText, _statInstance.GetCoins().ToString());
    }
    private void UpdateText(Text textbox, string textValue) {
        textbox.text = textValue;
    }
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
