using CommunityToolkit.Maui.Views;

namespace MusicBox.Controls.PopUps;

public partial class AdvanceRequestPopUp : Popup
{
    int count = 0;
    public AdvanceRequestPopUp()
    {
        InitializeComponent();
        BindingContext = new AdvanceRequestPopUpViewModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        if (btn.Text == "Cancel")
        {
            Close(true);
            return;
        }

        if ((BindingContext as AdvanceRequestPopUpViewModel).PlaylistLink != null)
        {
            if (count == 0)
            {
                (BindingContext as AdvanceRequestPopUpViewModel).ImportPlaylistDataCommand.Execute(null);
                count++;
                return;
            }
            else
            {
                Close(false);
            }
        }
    }
}