using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteTeacher
{
    public partial class MainPage : ContentPage
    {
        private int rightAnswer = 0;
        private int order = 0;

        private Dictionary<string, string> notesRus = new Dictionary<string, string>
        {
            {"До", "Note0" },
            {"Ре", "Note1" },
            {"Ми", "Note2" },
            {"Фа", "Note3" },
            {"Соль", "Note4" },
            {"Ля", "Note5" },
            {"Си", "Note6" }
        };

        private Dictionary<string, string> notesRusOpp = new Dictionary<string, string>
        {
            {"Note0", "До" },
            {"Note1", "Ре" },
            {"Note2", "Ми" },
            {"Note3", "Фа" },
            {"Note4", "Соль" },
            {"Note5", "Ля" },
            {"Note6", "Си" }
        };
        private string path = null;
        private string previousPath = null;
        private static Random random = new Random();
        public MainPage()
        {
            InitializeComponent();
            NextQuestion();
        }

        private void NextQuestion()
        {
            order = random.Next(3);
            while (true)
            {
                rightAnswer = random.Next(7);
                if (order == 2 && (rightAnswer == 1 || rightAnswer == 0)) continue;
                path = $"Note{rightAnswer}{order}.png";
                if (previousPath == path) continue;
                break;
            }
            image.Source = path;
            previousPath = path;
        }

        public bool CheckAnswer(string answer)
        {
            if (path.Contains(answer)) return true;
            return false;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (path.Contains(notesRus[(sender as Button).Text]))
                DisplayAlert("Правильно", "Правильный ответ", "ОK");
            else DisplayAlert("Неправильно", $"Неправильный ответ\nПравильный ответ - {notesRusOpp[$"Note{rightAnswer}"]}", "ОK");
            NextQuestion();
        }
    }
}
