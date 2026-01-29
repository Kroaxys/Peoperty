using System;
using System.Collections.Generic;

namespace Peoperty;

public partial class MainPage : ContentPage
{
    // Poäng
    private int score = 0;

    // Info om vald fråga
    private string selectedSubject = "";
    private int selectedPoints = 0;
    private string correctAnswer = "";

    // Alla frågor och svar
    private Dictionary<(string subject, int points), (string question, string answer)> questions =
        new Dictionary<(string, int), (string, string)>
    {
        { ("Matte", 200), ("Vad är 5 + 7?", "12") },
        { ("Matte", 400), ("Vad är 15 × 3?", "45") },
        { ("Matte", 600), ("Vad är roten ur 81?", "9") },
        { ("Matte", 800), ("Vad är 144 ÷ 12?", "12") },
        { ("Matte", 1000), ("Vad är 12²?", "144") },

        { ("Svenska", 200), ("Vad är ett verb?", "handling") },
        { ("Svenska", 400), ("Vad heter ordklassen för 'snabbt'?", "adverb") },
        { ("Svenska", 600), ("Vad kallas motsatsen till 'synonym'?", "antonym") },
        { ("Svenska", 800), ("Vad är ett substantiv?", "namn") },
        { ("Svenska", 1000), ("Vad heter satsdelen som beskriver objektet?", "predikatsfyllnad") },

        { ("Engelska", 200), ("Översätt 'dog' till svenska.", "hund") },
        { ("Engelska", 400), ("Översätt 'beautiful' till svenska.", "vacker") },
        { ("Engelska", 600), ("Vad betyder 'quickly'?", "snabbt") },
        { ("Engelska", 800), ("Vad betyder 'responsibility'?", "ansvar") },
        { ("Engelska", 1000), ("Vad betyder 'achievement'?", "prestation") },

        { ("NO", 200), ("Vilken gas andas vi mest av?", "kväve") },
        { ("NO", 400), ("Vilken planet är närmast solen?", "merkurius") },
        { ("NO", 600), ("Vad heter processen där växter gör syre?", "fotosyntes") },
        { ("NO", 800), ("Vilket ämne har kemiska beteckningen H2O?", "vatten") },
        { ("NO", 1000), ("Vad kallas läran om energi?", "termodynamik") },

        { ("SO", 200), ("Vilket land ligger söder om Sverige?", "danmark") },
        { ("SO", 400), ("Vad heter Sveriges valuta?", "krona") },
        { ("SO", 600), ("Vad heter Sveriges huvudstad?", "stockholm") },
        { ("SO", 800), ("Vilket år startade andra världskriget?", "1939") },
        { ("SO", 1000), ("Vad heter FN på engelska?", "united nations") },

        { ("IT", 200), ("Vad står CPU för?", "Central processing unit") },
        { ("IT", 400), ("Vad är 1 byte i antal bitar?", "8") },
        { ("IT", 600), ("Vad heter minnet som försvinner när datorn stängs av?", "ram") },
        { ("IT", 800), ("Vad betyder 'HTML'?", "hypertext markup language") },
        { ("IT", 1000), ("Vad betyder 'API'?", "application programming interface") },
    };

    public MainPage()
    {
        InitializeComponent();
    }

    // Uppdaterar poängtexten
    private void UpdateScore()
    {
        ScoreLabel.Text = $"Poäng: {score}";
    }

    // När man klickar på en fråga
    private void OnQuestionButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null)
            return;

        // Hämta kolumnen (ämnet)
        int column = Grid.GetColumn(button);

        string[] subjects = { "Matte", "Svenska", "Engelska", "NO", "SO", "IT" };
        selectedSubject = subjects[column];

        // Hämta poängen
        selectedPoints = int.Parse(button.Text);

        // Hämta fråga + svar
        var key = (selectedSubject, selectedPoints);

        if (questions.ContainsKey(key))
        {
            correctAnswer = questions[key].answer;
            QuestionLabel.Text = $"{selectedSubject} {selectedPoints}p:\n{questions[key].question}";
        }

        // Rensa svarsrutan
        AnswerEntry.Text = "";

        // Visa knappar
        SubmitButton.IsVisible = true;
        SubmitButton.IsEnabled = true;
        ResultButtonsLayout.IsVisible = false;
    }

    // När man klickar "Svara"
    private void OnSubmitAnswerClicked(object sender, EventArgs e)
    {
        SubmitButton.IsVisible = false;
        SubmitButton.IsEnabled = false;

        ResultButtonsLayout.IsVisible = true;

        // Visa rätt svar
        QuestionLabel.Text += $"\n\nRätt svar: {correctAnswer}";
    }

    // Om svaret var rätt
    private void OnCorrectClicked(object sender, EventArgs e)
    {
        score += selectedPoints;
        UpdateScore();

        DisableUsedButton();
        ResultButtonsLayout.IsVisible = false;
    }

    // Om svaret var fel
    private void OnWrongClicked(object sender, EventArgs e)
    {
        DisableUsedButton();
        ResultButtonsLayout.IsVisible = false;
    }

    // Stänger av knappen man redan använt
    private void DisableUsedButton()
    {
        string[] subjects = { "Matte", "Svenska", "Engelska", "NO", "SO", "IT" };
        int column = Array.IndexOf(subjects, selectedSubject);

        int row = selectedPoints switch
        {
            200 => 1,
            400 => 2,
            600 => 3,
            800 => 4,
            1000 => 5,
            _ => -1
        };

        foreach (var child in PeopertyGrid.Children)
        {
            if (child is Button btn &&
                Grid.GetRow(btn) == row &&
                Grid.GetColumn(btn) == column)
            {
                btn.IsEnabled = false;
                btn.Opacity = 0.4;
                break;
            }
        }
    }
}
