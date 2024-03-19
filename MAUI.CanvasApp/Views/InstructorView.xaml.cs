namespace MauiApp1;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
	}

	private void BackToHomeClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//MainPage");
	}
}