using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayfabController : MonoBehaviour
{
    [SerializeField] GameObject signupTab, loginTab, startPanel, HUD;
    public TMPro.TextMeshProUGUI Username, UserEmail, UserPassword, UserEmailLogin, UserPasswordLogin, ErrorSignUp, ErrorLogin;
    private string _encryptedPassword;

    public void SignUpTab()
    {
        signupTab.SetActive(true);
        loginTab.SetActive(false);
    }

    public void LoginTab()
    {
        signupTab.SetActive(false);
        loginTab.SetActive(true);
        ErrorLogin.text = "";
        ErrorSignUp.text = "";
    }
    public void Start()
    {
        Time.timeScale = 0;
        ErrorLogin.text = "";
        ErrorSignUp.text = "";
    }
    string Encrypt(string password)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(password);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    public void SignUpROBBE()
    {
        var registerRequest = new RegisterPlayFabUserRequest
        {
            Email = UserEmail.text.Remove(UserEmail.text.Length - 1),
            Password = Encrypt(UserPassword.text.Remove(UserPassword.text.Length - 1)),
            Username = Username.text.Remove(Username.text.Length - 1)
        };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSucces, RegisterFailure);


    }
    public void LogInROBBE()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = UserEmailLogin.text.Remove(UserEmailLogin.text.Length - 1),
            Password = Encrypt(UserPasswordLogin.text.Remove(UserPasswordLogin.text.Length - 1))
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginFailure);
    }

    public void RegisterSucces(RegisterPlayFabUserResult result)
    {
        ErrorSignUp.text = "";
        StartGame();
    }


    public void RegisterFailure(PlayFabError error)
    {
        ErrorSignUp.text = error.ErrorMessage;

    }

    public void LoginSuccess(LoginResult result)
    {

        ErrorLogin.text = "";
        StartGame();


    }
    public void LoginFailure(PlayFabError error)
    {
        ErrorLogin.text = error.ErrorMessage;
    }



    private void StartGame()
    {
        Time.timeScale = 1;
        HUD.SetActive(true);
        startPanel.SetActive(false);
    }

public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}

