using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

namespace SupremumStudio
{
    public class Quiz : MonoBehaviour
    {
        public bool CanPlay = true;
        public float TimeForPlay = 0;
        public float TimeForWrongAnswer = 200;
        public List<QuestionModel> questions;
        public string currentAnswer;
        public int currentWeight;
        private List<QuestionModel> allQuestions;
        public float Coefficient = 5;
        // Простые вопросы
        public List<QuestionModel> simpleQuestions;
        // Средней сложности вопросы
        public List<QuestionModel> averageQuestions;
        // Сложные вопросы
        public List<QuestionModel> hardQuestions;
        public int currentQuestion = -1;
        public string FromGet;
        public int countQuestionFile;
        public bool IsCorrectAnswer { get; private set; }
        public event Action QuestionChanged;
        //public event Action OutOfQuestion;
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        IEnumerator GetRequest(string uri, Action<string> CallBack)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    //Debug.Log(pages[page] + ": Error: " + webRequest.error);
                }
                else
                {
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    FromGet = webRequest.downloadHandler.text;
                    CallBack(FromGet);
                }
            }
        }
        private void Update()
        {
            if(!CanPlay)
            {
                TimeForPlay -= Time.deltaTime;
                if(TimeForPlay<=0)
                {
                    CanPlay = true;
                }
            }
        }

        private void Start()
        {

        }
        public int CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
            }
            //{  if (value == questions.Count)
            //    {
            //        currentQuesion = 0;
            //    }
            //else
            //    {
            //        currentQuesion = value;
            //    }

        }
        //UI Element
        //private void SetQuestion()
        //{
        //    //TextAsset JsonQuestion = Resources.Load<TextAsset>("Questions/Question");
        //    //List<QuestionModel> questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionModel>>(JsonQuestion.ToString());
        //    //SetQuiz(questions[CurrentQuestion].TextQuestion, questions[CurrentQuestion].Answer);
        //    currentAnswer = questions[CurrentQuestion].Answer[0];
        //    currentWeight = questions[CurrentQuestion].Weight;
        //}
        public (string, string[]) GetQuestionData()
        {

            List<QuestionModel> questions = GetCurrentQuestionsCollection();
            //Debug.Log(CurrentQuestion);
            if (CurrentQuestion == questions.Count)
            {
                currentAnswer = string.Empty;
                currentWeight = 0;
                return ("Поздравляю, вы ответили на все вопросы", new string[] { "Ты ответил на все вопросы", "Ты ответил на все вопросы", "Ты ответил на все вопросы" });
            }
            else
            {
                currentAnswer = questions[CurrentQuestion].Answer[0];
                currentWeight = questions[CurrentQuestion].Weight;
                return (questions[CurrentQuestion].TextQuestion, questions[CurrentQuestion].Answer);
            }


        }
        public void ResetQuiz()
        {

            Coefficient = 5f;
            CurrentQuestion = -1;
            ShuffleAllQuestions();
        }
        public void ShuffleAllQuestions()
        {
            Shuffle(simpleQuestions); // перемешать вопросы
            Shuffle(averageQuestions); // перемешать вопросы
            Shuffle(hardQuestions);
            questions = new List<QuestionModel>(simpleQuestions);
            questions.AddRange(averageQuestions);
            questions.AddRange(hardQuestions);
        }
        private List<QuestionModel> GetCurrentQuestionsCollection()
        {
            //if (currentQuesion < 10)
            //{
            //    return simpleQuestions;
            //}
            //else if (currentQuesion < 20)
            //{
            //    return averageQuestions;
            //}
            //else
            //{
            //    return hardQuestions;
            //}
            return questions;
        }

        public void ReadQuestions()
        {
            var JsonQuestion = Resources.Load<TextAsset>("Questions/Questions");
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var text2 = DecryptString(key, JsonQuestion.ToString());
            List<QuestionModel> allQuestions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionModel>>(text2);
            OrderByWeight(allQuestions);
        }

        private void OrderByWeight(List<QuestionModel> allQuestions)
        {
            simpleQuestions = new List<QuestionModel>(allQuestions.Where(x => x.Weight == 0));
            averageQuestions = new List<QuestionModel>(allQuestions.Where(x => x.Weight == 1));
            hardQuestions = new List<QuestionModel>(allQuestions.Where(x => x.Weight == 2));
            Shuffle(simpleQuestions);
            Shuffle(averageQuestions);
            Shuffle(hardQuestions);
            questions = new List<QuestionModel>(simpleQuestions);
            questions.AddRange(averageQuestions);
            questions.AddRange(hardQuestions);

        }
        public void NextQuestion()
        {
            if (Coefficient > 1)
            {
                Coefficient -= 0.1f;
            }
            CurrentQuestion++;
            if ((CurrentQuestion + 1) > 1)
            {

            }
            QuestionChanged();
        }
        public void Shuffle(List<QuestionModel> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                int r = Random.Range(0, model.Count);
                var t = model[i];
                model[i] = model[r];
                model[r] = t;
            }
        }

    }
}