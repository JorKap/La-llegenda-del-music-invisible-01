using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class QuizUI : MonoBehaviour
{
    [SerializeField] private GameObject quiz_out;
    [SerializeField] private GameObject quiz_start;
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctColor, wrongColor, normalColor;

    private Question question;
    private bool answered;
    private float audioLength;

    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideo;
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                questionAudio.clip = question.questionClip;
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;
          
        }
        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalColor;
        }
        answered = false;
    }

    IEnumerator PlayAudio()
    {
        if(question.questionType == QuestionType.AUDIO)
        {
            questionAudio.PlayOneShot(question.questionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }
    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
    }
    private void QuizBeguin()
    {
        quiz_start.SetActive(true);
        this.gameObject.SetActive(false);
        quizManager.questions.Clear();
    }

    private void QuizDone()
    {
        quiz_start.SetActive(false);
        this.gameObject.SetActive(false);
        quizManager.questions.Clear();
        quiz_out.SetActive(true);

    }
    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);
            if (val)
            {
                btn.image.color = correctColor;
                if (quizManager.questions.Count == 0)
                    Invoke("QuizDone", 0.5f);

            }
            else
            {
                btn.image.color = wrongColor;
                Invoke("QuizBeguin", 0.5f);

            }
        }
    }
}
