namespace MauiApp1;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
	}

	private void BackToHomeClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//MainPage");
	}
}