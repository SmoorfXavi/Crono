using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Crono
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : ThemedWindow
	{

		private DispatcherTimer timer;
		private TimeSpan timeElapsed;

		public MainWindow()
		{
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
			tTimer.Text = timeElapsed.ToString(@"hh\:mm\:ss");
		}

		private void bParar_Click(object sender, RoutedEventArgs e)
		{
			timer.Stop();
			timeElapsed = TimeSpan.Zero;
			tTimer.Text = "00:00:00";
			bIniciar.IsEnabled = true;
			bPausar.IsEnabled = false;
			bParar.IsEnabled = false;
		}

		private void bIniciar_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();
			bIniciar.IsEnabled = false;
			bPausar.IsEnabled = true;
			bParar.IsEnabled = true;
		}

		private void bPausar_Click(object sender, RoutedEventArgs e)
		{
			timer.Stop();
			bIniciar.IsEnabled = true;
			bPausar.IsEnabled = false;
		}
	}
}
