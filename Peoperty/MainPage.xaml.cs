using System.Diagnostics;
using System.Globalization;

namespace Peoperty
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void AnswerClicked(object sender, EventArgs e)
        {
            QuestionLabel.Text = String.Empty;
            PersonalAnswerLabel.Text = $"Ditt svar är: {AnswerEntry.Text}";
            AnswerLabel.Text = $"Rätt svar är: ";
        }

        private void PointButtonClicked(object sender, EventArgs e)
        {
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

        private string QuestionGiver(int subject, int points)
        {
            if (subject == 0)
            {
                switch (points)
                {
                    case 200:
                        QuestionLabel.Text = "Denna ordklass används för att beskriva en person, en plats, en sak eller abstrakta begrepp.";
                        break;

                    case 400:
                        QuestionLabel.Text = "Det är ett skiljetecken som används vid slutet av en fråga.";
                        break;

                    case 600:
                        QuestionLabel.Text = "När en berättelse återger vad en person tänker eller säger utan att använda citattecken, och det är blandat med berättarens språk.";
                        break;

                    case 800:
                        QuestionLabel.Text = "När en text är uppbyggd så att argumenten presenteras i en genomtänkt och tydlig ordning för att övertyga läsaren.";
                        break;

                    case 1000:
                        QuestionLabel.Text = "När en talare försöker övertyga genom att väcka känslor hos publiken, med exempelvis starka ord eller personliga exempel.";
                        break;
                }
            }
            else if (subject == 1)
            {
                switch (points)
                {
                    case 200:
                        QuestionLabel.Text = "Den största religionen i världen, med flest anhängare, grundad i Mellanöstern.";
                        break;

                    case 400:
                        QuestionLabel.Text = "Sveriges högsta församling där de stiftas lagar, församlingen består av folkvalda representanter. Ett exempel är att de beslutar om statens budget.";
                        break;

                    case 600:
                        QuestionLabel.Text = "Detta år började andra världskriget när Tyskland invaderade Polen.";
                        break;

                    case 800:
                        QuestionLabel.Text = "En samhällsform där medborgarna väljer representanter som styr landet åt dem.";
                        break;

                    case 1000:
                        QuestionLabel.Text = "Denna flod, som rinner genom Egypten och Sudan, har varit central för civilisationer i över 5000 år och kallas ofta ”livets flod” i Afrika.";
                        break;
                }
            }
            else if (subject == 2)
            {
                switch (points)
                {
                    case 200:
                        QuestionLabel.Text = "Resultatet av en multiplikation kallas detta";
                        break;

                    case 400:
                        QuestionLabel.Text = "Ett tal som är delbart med 1 och sig självt, exempelvis 2, 3, 5 och 7";
                        break;

                    case 600:
                        QuestionLabel.Text = "Den del av ett tal som visar hur många gånger grundtalet ska multipliceras med sig självt, exempelvis 2^3";
                        break;

                    case 800:
                        QuestionLabel.Text = "Den här metoden används för att bryta ner ett tal eller ett uttryck i faktorer, till exempel 12=2⋅2⋅3.";
                        break;

                    case 1000:
                        QuestionLabel.Text = "Denna typ av funktion har formen f(x)=a⋅bx = a och används ofta för att beskriva tillväxt, nedbrytning eller förändring som sker procentuellt.";
                        break;
                }

            }
            else if (subject == 3)
            {
                switch (points)
                {
                    case 200:
                        QuestionLabel.Text = "Detta grundämne har kemiskt tecken H och är universums vanligaste.";
                        break;

                    case 400:
                        QuestionLabel.Text = "Detta pH-värde räknas som neutralt.";
                        break;

                    case 600:
                        QuestionLabel.Text = "Detta ämne fungerar som lösningsmedel i de flesta kemiska reaktioner i kroppen.";
                        break;

                    case 800:
                        QuestionLabel.Text = "När ett ämne reagerar med vatten. Ex rost.";
                        break;

                    case 1000:
                        QuestionLabel.Text = "Denna modell beskriver hur elektroner rör sig i bestämda energinivåer runt atomkärnan.";
                        break;
                }

            }
            else if (subject == 4)
            {
                switch (points)
                {
                    case 200:
                        QuestionLabel.Text = "A formal synonym for “help.”";
                        break;

                    case 400:
                        QuestionLabel.Text = "This verb means “to examine critically and in detail.”";
                        break;

                    case 600:
                        QuestionLabel.Text = "This adjective describes language that is intentionally vague or ambiguous.";
                        break;

                    case 800:
                        QuestionLabel.Text = "A noun meaning “a widespread feeling of unease or dissatisfaction.”";
                        break;

                    case 1000:
                        QuestionLabel.Text = "The term for a sentence containing two independent clauses joined without proper punctuation.";
                        break;
                }
            }
            return "";
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
