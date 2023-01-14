using CommunityToolkit.Maui.Views;

namespace MusicBox.Controls.PopUps;

public partial class FeedbackPopUp : Popup
{
	public FeedbackPopUp()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        if (btn.Text == "Cancel")
        {
            Close();
            return;
        }

        feedbackEntry.Text = string.Empty;
        Close();
    }
}