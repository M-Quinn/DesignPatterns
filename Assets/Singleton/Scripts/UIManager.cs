using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _scoreText, _sceneText;
    [SerializeField] Coins _coinScript;
    private void Start()
    {
        UpdateText(_scoreText, _coinScript.GetCoins().ToString());
        UpdateText(_sceneText, SceneManager.GetActiveScene().buildIndex.ToString());
    }
    public void AddCoins() {
        _coinScript.UpdateCoins(1);
        UpdateText(_scoreText, _coinScript.GetCoins().ToString());
    }
    private void UpdateText(Text textbox, string textValue) {
        textbox.text = textValue;
    }
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
