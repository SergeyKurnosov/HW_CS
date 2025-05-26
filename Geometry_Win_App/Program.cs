namespace Geometry_Win_App
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{

			ApplicationConfiguration.Initialize();
			Application.Run(new Displayer());
		}
	}
}