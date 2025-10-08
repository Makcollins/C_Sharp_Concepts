using LearnLibrary;

namespace WinFormUI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private void combineNameBtn_Click(object sender, System.EventArgs e)
    {
        // TODO: Add event handler implementation
        string fullName = PersonProcessor.JoinName(firstNameText.Text, lastNameText.Text);
        string message = $"Your full name is {fullName}";
        MessageBox.Show(message);
    }
}
