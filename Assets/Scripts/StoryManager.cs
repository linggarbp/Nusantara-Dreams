using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.07f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;

    [HideInInspector] public int npcDialog;
    private Story currentStory;

    private bool canContinueToNextLine = false;
    public bool dialogueIsPlaying { get; private set; }

    private Coroutine displayLineCoroutine;

    private bool canSkip = false;
    private bool submitSkip;

    private const string SPEAKER_TAG = "speaker";
    private const string SCORE_CHECK_TAG = "scoreCheck"; // New tag for score checking
    private static StoryManager instance;

    [SerializeField]
    List<GameObject> gameObjects = new List<GameObject>();
    public DebriefingCount debriefingCount;
    private int scoreValue; // Variable to store the score value

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static StoryManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        storyPanel.SetActive(false);
    }

    private void Update()
    {
        scoreValue = debriefingCount.swapGateCount;
        if (Input.GetKeyDown(KeyCode.Space))
            submitSkip = true;

        if (!dialogueIsPlaying)
            return;

        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.Space))
            ContinueStory();
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        storyPanel.SetActive(true);
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
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        storyPanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
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
                case SCORE_CHECK_TAG:
                    if (gameObjects[0].activeSelf &&
                        gameObjects[1].activeSelf &&
                        gameObjects[2].activeSelf &&
                        gameObjects[3].activeSelf &&
                        gameObjects[4].activeSelf)
                    {
                        if (scoreValue <= 190)
                        {
                            dialogueText.text += "Anda sudah sangat baik dalam memahami dasar-dasar gerbang logika. Agar lebih menguasai konsep ini, cobalah untuk lebih sering berlatih dan memahami fungsi masing-masing gerbang logika.";
                        }
                        else if (scoreValue > 195 && scoreValue <= 200)
                        {
                            dialogueText.text += "Anda menunjukkan pemahaman yang baik tentang gerbang logika. Untuk meningkatkan keterampilan Anda, disarankan untuk mempelajari lebih dalam tentang kombinasi gerbang logika dan bagaimana mereka bekerja.";
                        }
                        else if (scoreValue > 205 && scoreValue <= 210)
                        {
                            dialogueText.text += "Anda memiliki pemahaman yang cukup baik tentang gerbang logika. Untuk lebih meningkatkan kemampuan Anda, cobalah untuk memecahkan lebih banyak soal latihan dan eksperimen dengan berbagai kombinasi gerbang logika.";
                        }
                        else if (scoreValue > 215 && scoreValue <= 220)
                        {
                            dialogueText.text += "Anda kurang memahami dasar-dasar gerbang logika. Untuk lebih menguasai materi ini, anda disarankan untuk mempelajari aplikasi praktis dari gerbang logika dalam rangkaian digital yang lebih kompleks";
                        }
                        else
                        {
                            dialogueText.text += "Anda sangat kurang memahami gerbang logika sehingga perlu lebih banyak berlatih dengan lebih baik. Cobalah untuk mempelajari kembali konsep dasar dan fungsi masing-masing gerbang logika, serta bagaimana mereka dapat dikombinasikan untuk membentuk rangkaian yang lebih kompleks";
                        }
                    }
                    else if (gameObjects[0].activeSelf)
                    {
                        if (scoreValue <= 25)
                        {
                            dialogueText.text += "Anda sudah sangat baik dalam memahami dasar-dasar gerbang logika. Agar lebih menguasai konsep ini, cobalah untuk lebih sering berlatih dan memahami fungsi masing-masing gerbang logika.";
                        }
                        else if (scoreValue > 25 && scoreValue <= 30)
                        {
                            dialogueText.text += "Anda menunjukkan pemahaman yang baik tentang gerbang logika. Untuk meningkatkan keterampilan Anda, disarankan untuk mempelajari lebih dalam tentang kombinasi gerbang logika dan bagaimana mereka bekerja.";
                        }
                        else if (scoreValue > 30 && scoreValue <= 35)
                        {
                            dialogueText.text += "Anda memiliki pemahaman yang cukup baik tentang gerbang logika. Untuk lebih meningkatkan kemampuan Anda, cobalah untuk memecahkan lebih banyak soal latihan dan eksperimen dengan berbagai kombinasi gerbang logika.";
                        }
                        else if (scoreValue > 35 && scoreValue <= 40)
                        {
                            dialogueText.text += "Anda kurang memahami dasar-dasar gerbang logika. Untuk lebih menguasai materi ini, anda disarankan untuk mempelajari aplikasi praktis dari gerbang logika dalam rangkaian digital yang lebih kompleks";
                        }
                        else
                        {
                            dialogueText.text += "Anda sangat kurang memahami gerbang logika sehingga perlu lebih banyak berlatih dengan lebih baik. Cobalah untuk mempelajari kembali konsep dasar dan fungsi masing-masing gerbang logika, serta bagaimana mereka dapat dikombinasikan untuk membentuk rangkaian yang lebih kompleks";
                        }
                    }
                    else if (gameObjects[1].activeSelf)
                    {
                        if (scoreValue <= 53)
                        {
                            dialogueText.text += "Anda sudah sangat baik dalam memahami dasar-dasar gerbang logika. Agar lebih menguasai konsep ini, cobalah untuk lebih sering berlatih dan memahami fungsi masing-masing gerbang logika.";
                        }
                        else if (scoreValue > 53 && scoreValue <= 58)
                        {
                            dialogueText.text += "Anda menunjukkan pemahaman yang baik tentang gerbang logika. Untuk meningkatkan keterampilan Anda, disarankan untuk mempelajari lebih dalam tentang kombinasi gerbang logika dan bagaimana mereka bekerja.";
                        }
                        else if (scoreValue > 63 && scoreValue <= 68)
                        {
                            dialogueText.text += "Anda memiliki pemahaman yang cukup baik tentang gerbang logika. Untuk lebih meningkatkan kemampuan Anda, cobalah untuk memecahkan lebih banyak soal latihan dan eksperimen dengan berbagai kombinasi gerbang logika.";
                        }
                        else if (scoreValue > 73 && scoreValue <= 78)
                        {
                            dialogueText.text += "Anda kurang memahami dasar-dasar gerbang logika. Untuk lebih menguasai materi ini, anda disarankan untuk mempelajari aplikasi praktis dari gerbang logika dalam rangkaian digital yang lebih kompleks";
                        }
                        else
                        {
                            dialogueText.text += "Anda sangat kurang memahami gerbang logika sehingga perlu lebih banyak berlatih dengan lebih baik. Cobalah untuk mempelajari kembali konsep dasar dan fungsi masing-masing gerbang logika, serta bagaimana mereka dapat dikombinasikan untuk membentuk rangkaian yang lebih kompleks";
                        }
                    }
                    else if (gameObjects[2].activeSelf)
                    {
                        if (scoreValue <= 57)
                        {
                            dialogueText.text += "Anda sudah sangat baik dalam memahami dasar-dasar gerbang logika. Agar lebih menguasai konsep ini, cobalah untuk lebih sering berlatih dan memahami fungsi masing-masing gerbang logika.";
                        }
                        else if (scoreValue > 57 && scoreValue <= 62)
                        {
                            dialogueText.text += "Anda menunjukkan pemahaman yang baik tentang gerbang logika. Untuk meningkatkan keterampilan Anda, disarankan untuk mempelajari lebih dalam tentang kombinasi gerbang logika dan bagaimana mereka bekerja.";
                        }
                        else if (scoreValue > 67 && scoreValue <= 72)
                        {
                            dialogueText.text += "Anda memiliki pemahaman yang cukup baik tentang gerbang logika. Untuk lebih meningkatkan kemampuan Anda, cobalah untuk memecahkan lebih banyak soal latihan dan eksperimen dengan berbagai kombinasi gerbang logika.";
                        }
                        else if (scoreValue > 77 && scoreValue <= 85)
                        {
                            dialogueText.text += "Anda kurang memahami dasar-dasar gerbang logika. Untuk lebih menguasai materi ini, anda disarankan untuk mempelajari aplikasi praktis dari gerbang logika dalam rangkaian digital yang lebih kompleks";
                        }
                        else
                        {
                            dialogueText.text += "Anda sangat kurang memahami gerbang logika sehingga perlu lebih banyak berlatih dengan lebih baik. Cobalah untuk mempelajari kembali konsep dasar dan fungsi masing-masing gerbang logika, serta bagaimana mereka dapat dikombinasikan untuk membentuk rangkaian yang lebih kompleks";
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
