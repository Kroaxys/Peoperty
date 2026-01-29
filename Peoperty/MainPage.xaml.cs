using System.Diagnostics;
using Peoperty.Model;

namespace Peoperty
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private List<Question> Questions = new()
        {
            // Svenska (0)
            new Question { Subject = 0, Points = 200, Text = "Denna ordklass används för att beskriva en person, en plats, en sak eller abstrakta begrepp.", Answer = "Vad är ett frågetecken?" },
            new Question { Subject = 0, Points = 400, Text = "Det är ett skiljetecken som används vid slutet av en fråga.", Answer = "Vad är ett frågetecken?" },
            new Question { Subject = 0, Points = 600, Text = "När en berättelse återger vad en person tänker eller säger utan citattecken.", Answer = "Vad är fritt indirekt tal?" },
            new Question { Subject = 0, Points = 800, Text = "När en text är uppbyggd för att övertyga läsaren med tydlig argumentation.", Answer = "Vad är disposition?" },
            new Question { Subject = 0, Points = 1000, Text = "När en talare försöker väcka känslor hos publiken.", Answer = "Vad är pathos?" },

            // SO (1)
            new Question { Subject = 1, Points = 200, Text = "Den största religionen i världen.", Answer = "Vad är kristendomen?" },
            new Question { Subject = 1, Points = 400, Text = "Sveriges högsta lagstiftande församling.", Answer = " Vad är riksdagen?" },
            new Question { Subject = 1, Points = 600, Text = "Året då andra världskriget började.", Answer = "Vad är 1939?" },
            new Question { Subject = 1, Points = 800, Text = "En samhällsform där folket väljer representanter.", Answer = "Vad är representativ demokrati?" },
            new Question { Subject = 1, Points = 1000, Text = "Floden som kallas livets flod i Afrika.", Answer = "Vad är Nilen?" },

            // Matte (2)
            new Question { Subject = 2, Points = 200, Text = "Resultatet av en multiplikation.", Answer = "Vad är en produkt?" },
            new Question { Subject = 2, Points = 400, Text = "Ett tal som bara är delbart med 1 och sig självt.", Answer = "Vad är ett primtal?" },
            new Question { Subject = 2, Points = 600, Text = "Visar hur många gånger grundtalet multipliceras med sig självt.", Answer = "Vad är en exponent?" },
            new Question { Subject = 2, Points = 800, Text = "Metod för att bryta ner ett tal i faktorer.", Answer = "Vad är faktorisering?" },
            new Question { Subject = 2, Points = 1000, Text = "En funktion som beskriver procentuell förändring.", Answer = "Vad är exponentialfunktionen?" },

            // Kemi (3)
            new Question { Subject = 3, Points = 200, Text = "Grundämnet med kemiskt tecken H.", Answer = "Vad är Väte?" },
            new Question { Subject = 3, Points = 400, Text = "Detta pH-värde är neutralt.", Answer = "Vad är pH 7?" },
            new Question { Subject = 3, Points = 600, Text = "Kroppens viktigaste lösningsmedel.", Answer = "Vad är vatten?" },
            new Question { Subject = 3, Points = 800, Text = "När ett ämne reagerar med vatten, ex rost.", Answer = "Vad är oxidation?" },
            new Question { Subject = 3, Points = 1000, Text = "Modell för elektroners energinivåer i atomen.", Answer = "Vad är Bohrs atommodell?" },

            // Engelska (4)
            new Question { Subject = 4, Points = 200, Text = "A formal synonym for 'help'.", Answer = "Vad är assist?" },
            new Question { Subject = 4, Points = 400, Text = "A verb meaning to examine critically.", Answer = "Vad är analyze?" },
            new Question { Subject = 4, Points = 600, Text = "Adjective meaning intentionally vague.", Answer = "Vad är equivocal?" },
            new Question { Subject = 4, Points = 800, Text = "A noun meaning widespread unease.", Answer = "Vad är malaise?" },
            new Question { Subject = 4, Points = 1000, Text = "Sentence with two independent clauses improperly joined.", Answer = "Vad är comma splice?" }
        };


        private void AnswerClicked(object sender, EventArgs e)
        {
            QuestionLabel.Text = String.Empty;
            PersonalAnswerLabel.Text = $"Ditt svar är: {AnswerEntry.Text}";
            
            AnswerEntry.IsVisible = false;
            AnswerLabel.IsVisible = true;
            YesButton.IsVisible = true;
            NoButton.IsVisible = true;
            
        }

        private void PointButtonClicked(object sender, EventArgs e)
        {
            AnswerEntry.IsVisible = true;
            AnswerLabel.IsVisible = false;
            YesButton.IsVisible = false;
            NoButton.IsVisible = false;
            AnswerEntry.Text = "";
            PersonalAnswerLabel.Text = String.Empty;
            Button button = (Button)sender;
            //int buttontext = int.Parse(button.Text);  
            int column = MainGrid.GetColumn(button);
            if (int.TryParse(button.Text, out int buttonText))
            {
                QuestionGiver(column, buttonText);
                AnswerGiver(column, buttonText);
            } 
            else
            {
                Debug.WriteLine("error");
            }

        }

        private void AnswerGiver(int subject, int points)
        {
            var answer = Questions.FirstOrDefault(q => q.Subject == subject && q.Points == points);

            AnswerLabel.Text = $"Rätt svar är: {answer.Answer}";
        }

        private void QuestionGiver(int subject, int points)
        {
            var question = Questions.FirstOrDefault(q => q.Subject == subject && q.Points == points);

            QuestionLabel.Text = question.Text;
        }


        private string SubjectForPoint(int column)
        {
            return column switch
            {
                0 => "Svenska",
                1 => "SO",
                2 => "Matte",
                3 => "Kemi",
                4 => "Engelska",
                _ => "Unknown"
            };
        }
    }
}
