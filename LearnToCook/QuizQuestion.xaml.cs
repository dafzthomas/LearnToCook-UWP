using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LearnToCook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizQuestion : Page
    {
        private List<dynamic> Questions = new List<object>();

        int currentQuestion = 0;
        int correctAnswers = 0;

        public QuizQuestion()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var data = (JsonArray)e.Parameter;

            foreach (JsonValue q in data)
            {
                JsonObject aQuestion = q.GetObject();
                dynamic obj = new ExpandoObject();


                obj.Title = aQuestion["Title"].GetString();
                obj.Q = aQuestion["Q"].GetString();
                obj.Ans1 = aQuestion["Ans1"].GetString();
                obj.Ans2 = aQuestion["Ans2"].GetString();
                obj.Ans3 = aQuestion["Ans3"].GetString();
                obj.Correct = aQuestion["Correct"].GetString();
                obj.Reason = aQuestion["Reason"].GetString();

                Questions.Add(obj);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GoToQuestion(currentQuestion);
        }

        private void ResetQuestionPage()
        {
            Radio1.IsEnabled = true;
            Radio2.IsEnabled = true;
            Radio3.IsEnabled = true;

            Radio1.IsChecked = false;
            Radio2.IsChecked = false;
            Radio3.IsChecked = false;

            QuestionResult.Text = "";
            QuestionResultReason.Text = "";


        }

        private void CheckAnswers(object sender, RoutedEventArgs e)
        {
            DisableRadioButtons();

            RadioButton btn = (RadioButton)sender;
            var a = btn.Content;
            var b = Questions[currentQuestion].Correct;

            if (a.ToString() == b.ToString())
            {
                QuestionResult.Text = "Correct!";
                correctAnswers++;
            } else
            {
                QuestionResult.Text = "Incorrect!";
            }
            
            QuestionResultReason.Text = Questions[currentQuestion].Reason;
        }

        private void DisableRadioButtons()
        {
            Radio1.IsEnabled = false;
            Radio2.IsEnabled = false;
            Radio3.IsEnabled = false;
        }

        private void GoToQuestion(int x)
        {
            QuestionNumber.Text = Questions[x].Title;
            Question.Text = Questions[x].Q;
            Radio1.Content = Questions[x].Ans1;
            Radio2.Content = Questions[x].Ans2;
            Radio3.Content = Questions[x].Ans3;
        }
        

        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion < (Questions.Count - 1))
            {
                currentQuestion++;
                ResetQuestionPage();
                GoToQuestion(currentQuestion);
                if (currentQuestion == (Questions.Count - 1))
                {
                    NextQuestionButton.Content = "Finish";
                }
            } else
            {
                Frame.Navigate(typeof(FinishedQuiz), correctAnswers);
            }
        }
    }
}
