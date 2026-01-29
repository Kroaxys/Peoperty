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
            new Question { Subject = 0, Points = 200, Text = "Denna ordklass används för att beskriva en person, en plats, en sak eller abstrakta begrepp." },
            new Question { Subject = 0, Points = 400, Text = "Det är ett skiljetecken som används vid slutet av en fråga." },
            new Question { Subject = 0, Points = 600, Text = "När en berättelse återger vad en person tänker eller säger utan citattecken." },
            new Question { Subject = 0, Points = 800, Text = "När en text är uppbyggd för att övertyga läsaren med tydlig argumentation." },
            new Question { Subject = 0, Points = 1000, Text = "När en talare försöker väcka känslor hos publiken." },

            // SO (1)
            new Question { Subject = 1, Points = 200, Text = "Den största religionen i världen." },
            new Question { Subject = 1, Points = 400, Text = "Sveriges högsta lagstiftande församling." },
            new Question { Subject = 1, Points = 600, Text = "Året då andra världskriget började." },
            new Question { Subject = 1, Points = 800, Text = "En samhällsform där folket väljer representanter." },
            new Question { Subject = 1, Points = 1000, Text = "Floden som kallas livets flod i Afrika." },

            // Matte (2)
            new Question { Subject = 2, Points = 200, Text = "Resultatet av en multiplikation." },
            new Question { Subject = 2, Points = 400, Text = "Ett tal som bara är delbart med 1 och sig självt." },
            new Question { Subject = 2, Points = 600, Text = "Visar hur många gånger grundtalet multipliceras med sig självt." },
            new Question { Subject = 2, Points = 800, Text = "Metod för att bryta ner ett tal i faktorer." },
            new Question { Subject = 2, Points = 1000, Text = "En funktion som beskriver procentuell förändring." },

            // Kemi (3)
            new Question { Subject = 3, Points = 200, Text = "Grundämnet med kemiskt tecken H." },
            new Question { Subject = 3, Points = 400, Text = "Detta pH-värde är neutralt." },
            new Question { Subject = 3, Points = 600, Text = "Kroppens viktigaste lösningsmedel." },
            new Question { Subject = 3, Points = 800, Text = "När ett ämne reagerar med vatten, ex rost." },
            new Question { Subject = 3, Points = 1000, Text = "Modell för elektroners energinivåer i atomen." },

            // Engelska (4)
            new Question { Subject = 4, Points = 200, Text = "A formal synonym for 'help'." },
            new Question { Subject = 4, Points = 400, Text = "A verb meaning to examine critically." },
            new Question { Subject = 4, Points = 600, Text = "Adjective meaning intentionally vague." },
            new Question { Subject = 4, Points = 800, Text = "A noun meaning widespread unease." },
            new Question { Subject = 4, Points = 1000, Text = "Sentence with two independent clauses improperly joined." }
        };


        private void AnswerClicked(object sender, EventArgs e)
        {
            QuestionLabel.Text = String.Empty;
            PersonalAnswerLabel.Text = $"Ditt svar är: {AnswerEntry.Text}";
            AnswerLabel.Text = $"Rätt svar är: ";
            AnswerEntry.IsVisible = false;
            AnswerLabel.IsVisible = true;
            
        }

        private void PointButtonClicked(object sender, EventArgs e)
        {
            AnswerEntry.IsVisible = true;
            AnswerLabel.IsVisible = false;
            PersonalAnswerLabel.Text = String.Empty;
            Button button = (Button)sender;
            //int buttontext = int.Parse(button.Text);  
            int column = MainGrid.GetColumn(button);
            if (int.TryParse(button.Text, out int buttonText))
            {
                QuestionGiver(column, buttonText);
            } 
            else
            {
                Debug.WriteLine("error");
            }

        }

        private string AnswerGiver()
        {
            
            
            return "";
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
