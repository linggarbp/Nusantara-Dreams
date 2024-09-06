using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;

    [SerializeField] AudioSource gibberishSound;
    //[SerializeField] private Animator portraitAnimator;
    //private Animator layoutAnimator;

    [Header("Choices UI")]
    private Button choiceBtn;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [HideInInspector] public int npcDialog;
    private Story currentStory;

    private bool canContinueToNextLine = false;
    public bool dialogueIsPlaying { get; private set; }

    private Coroutine displayLineCoroutine;

    private bool canSkip = false;
    private bool submitSkip;

    private const string SPEAKER_TAG = "speaker";
    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //layoutAnimator = dialoguePanel.GetComponent<Animator>();
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            submitSkip = true;

        if (!dialogueIsPlaying)
            return;

        //if (InputManager.GetInstance().GetSubmitPressed())
        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.Space))
            ContinueStory();
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        npcDialog++;

        ContinueStory();
    }

    private IEnumerator CanSkip()
    {
        canSkip = false;
        yield return new WaitForSeconds(0.05f);
        canSkip = true;
    }

    private IEnumerator ExitDialogueMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        gibberishSound.Play();
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given:" + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoices());

    }

    //private IEnumerator SelectFirstChoices()
    //{
    //    EventSystem.current.SetSelectedGameObject(null);
    //    yield return new WaitForEndOfFrame();
    //    EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    //}

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        Input.GetButtonDown("Attack");
        ContinueStory();
    }


    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";

        continueIcon.SetActive(false);
        canContinueToNextLine = false;

        submitSkip = false;
        canContinueToNextLine = false;

        StartCoroutine(CanSkip());

        foreach (char letter in line.ToCharArray())
        {
            if (canSkip && submitSkip)
            {
                submitSkip = false;
                dialogueText.text = line;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueIcon.SetActive(true);
        canContinueToNextLine = true;
        canSkip = false;
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
                Debug.LogError("Tag could not be appropriately parsed:" + tag);
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                default:
                    break;
            }
        }
    }
}
