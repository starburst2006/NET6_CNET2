using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            txbInfo.Text = "";
            var files = Directory.EnumerateFiles(@"C:\Users\Student\source\repos\starburst2006\BigFiles", "*.txt");

            foreach(var file in files)
            {
                var result = FreqAnalysis.FreqAnalysisFromFile(file);
                txbInfo.Text += result.Source + Environment.NewLine;

                txbInfo.Text += $"________________________ {Environment.NewLine}";

                foreach( var word in result.GetTop10())
                {
                    txbInfo.Text += $"{word.Key} : {word.Value} {Environment.NewLine}";
                }

                txbInfo.Text += Environment.NewLine;

            }

            s.Stop();   // konec časomíry
            txbInfo.Text += $"{Environment.NewLine} Uplynulý čas { s.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }

        private async void btnParallel1_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            txbInfo.Text = "";
            var files = Directory.EnumerateFiles(@"C:\Users\Student\source\repos\starburst2006\BigFiles", "*.txt");


            PBparalel.Value = 0;   // vynulování progressbaru
            PBparalel.Maximum = files.Count();    // nastavení maximální hodnoty

            IProgress<string> progress = new Progress<string>(message =>
            {
                txbInfo.Text += message;
                PBparalel.Value++;
            });

            await Parallel.ForEachAsync(files,async (file, cancellationToken) =>             // paralelní foreach - styl zápisu
            {
                var result = FreqAnalysis.FreqAnalysisFromFile(file);
                string message = "";
                message += result.Source + Environment.NewLine;

                message += $"________________________ {Environment.NewLine}";

                foreach (var word in result.GetTop10())
                {
                    message += $"{word.Key} : {word.Value} {Environment.NewLine}";
                }

                message += Environment.NewLine;
                progress.Report(message);
            });



            s.Stop();   // konec časomíry
            FRMName.Title = $"{Environment.NewLine} Uplynulý čas {s.ElapsedMilliseconds}";   // přepíši titulek okna
            progress.Report($"{Environment.NewLine} Uplynulý čas {s.ElapsedMilliseconds}");   // txbInfo.text => upraveno do progressu kvůli správnému pořadí výpisu  
            Mouse.OverrideCursor = null;
        }

        private void btnTaskFirst_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://www.ictpro.cz";

            var t1 = Task.Run( () => LoadWebPage.LoadUrl(url1));
            var t2 = Task.Run( () => LoadWebPage.LoadUrl(url2));
            var t3 = Task.Run( () => LoadWebPage.LoadUrl(url3));
            Task.WaitAny(t1, t2, t3);


            s.Stop();   // konec časomíry
            Mouse.OverrideCursor = null;

            txbInfo.Text = $"Doběhl první task... {s.ElapsedMilliseconds} ms";

        }

        private void btnTaskAll_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => LoadWebPage.LoadUrl(url1));
            var t2 = Task.Run(() => LoadWebPage.LoadUrl(url2));
            var t3 = Task.Run(() => LoadWebPage.LoadUrl(url3));
            Task.WaitAll(t1, t2, t3);


            s.Stop();   // konec časomíry
            Mouse.OverrideCursor = null;

            txbInfo.Text = $"Doběhly všechny tasky... {s.ElapsedMilliseconds} ms";
        }

        private async void btnTaskFirstWhen_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => LoadWebPage.LoadUrl(url1));
            var t2 = Task.Run(() => LoadWebPage.LoadUrl(url2));
            var t3 = Task.Run(() => LoadWebPage.LoadUrl(url3));
            var firstDone = await Task.WhenAny(t1, t2, t3);
           

            s.Stop();   // konec časomíry
            Mouse.OverrideCursor = null;

            txbInfo.Text = $"Doběhl první task... {s.ElapsedMilliseconds} ms. Web lenght je {firstDone.Result}";


        }

        private async void btnTaskAllWhen_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = Stopwatch.StartNew();  // stopování času
            Mouse.OverrideCursor = Cursors.Wait;  // změní kurzor na hodiny po dobu operace

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://www.ictpro.cz";

            var t1 = Task.Run(() => LoadWebPage.LoadUrl(url1));
            var t2 = Task.Run(() => LoadWebPage.LoadUrl(url2));
            var t3 = Task.Run(() => LoadWebPage.LoadUrl(url3));
            int[] allDone = await Task.WhenAll(t1, t2, t3);


            s.Stop();   // konec časomíry
            Mouse.OverrideCursor = null;

            txbInfo.Text = $"Doběhly všechny tasky... {s.ElapsedMilliseconds} ms. Weby jsou dlouhé {string.Join(", ", allDone)} znaků";


        }
    }
}
