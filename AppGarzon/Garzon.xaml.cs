using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using BLL;
using System.Data;
using System.Timers;
using System.Windows.Threading;

namespace AppGarzon
{
	/// <summary>
	/// Lógica de interacción para Garzon.xaml
	/// </summary>
	public partial class Garzon : MetroWindow
	{
		public string username = null;
		DispatcherTimer oDispatcherTimer = new DispatcherTimer();

		public Garzon()
		{
			InitializeComponent();
		}

		private void lbl_user_Loaded(object sender, RoutedEventArgs e)
		{
			lbl_user.Content = "Nombre de Usuario: " + username;
		}

		private void btn_volver_Click(object sender, RoutedEventArgs e)
		{
			MainWindow log = new MainWindow();
			Close();
			log.ShowDialog();
		}


		private void btn_play_Click(object sender, RoutedEventArgs e)
		{
			oDispatcherTimer.Start();
		}

		private void btn_stop_Click(object sender, RoutedEventArgs e)
		{
			oDispatcherTimer.Stop();
		}

		private void Banner_Loaded_1(object sender, RoutedEventArgs e)
		{
			oDispatcherTimer.Interval = new TimeSpan(0, 0, 3);
			oDispatcherTimer.Tick += (a, b) =>
			{
				BebestibleBLL bebBLL = new BebestibleBLL();
				System.Data.DataTable dt = bebBLL.getbeb_garzon();
				dtg_bebestible.ItemsSource = dt.DefaultView;

				PlatoBLL plaBLL = new PlatoBLL();
				System.Data.DataTable dta = plaBLL.Getplato_garzon();
				dtg_plato.ItemsSource = dta.DefaultView;
			};
		}

        private void Dtg_plato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = dtg_plato.SelectedItem as DataRowView;

                if (item != null)
                {

                    string Orden = item.Row[0].ToString();
                    string bebes = item.Row[2].ToString();
                    PlatoBLL bb = new PlatoBLL();

                    int idb = bb.Platoidbynb(bebes);
                    int ido = Int32.Parse(Orden);
                    bb.Alter_Plato_Despachado(ido, idb);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }





        }

        private void Dtg_bebestible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            try
            {
                var item = dtg_bebestible.SelectedItem as DataRowView;

                if (item != null)
                {

                    string Orden = item.Row[0].ToString();
                    string bebes = item.Row[2].ToString();
                    BebestibleBLL bb = new BebestibleBLL();


                    int idb = bb.Get_bebyid(bebes);
                    int ido = Int32.Parse(Orden);
                    bb.Alter_bebestible_Despachado(ido,idb);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }
    }
}
