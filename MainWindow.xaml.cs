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
using static System.Windows.Media.Colors;
using System.Drawing;

namespace Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnCalculateOnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(TxtHeight.Text, out double height) &&
            double.TryParse(TxtWeight.Text, out double weight))
        {
            height /= 100;
            double imt = weight / (height * height);

            TxtResult.Text = $"Ваш ИМТ: {imt:F2}";

            string status = "";
            string recomendations = "";

            
            if (imt < 16)
            {
                status = "Выраженный дефицит массы тела";
                recomendations = "Рекомендуется обратиться к врачу для дальнейшей консультации!";
                TxtStatus.Background = Brushes.Red;
            }
            if (imt >= 16 && imt < 18.5)
            {
                status = "Недостаточный вес";
                recomendations = "Рекомендуется обратиться к врачу!";
                TxtStatus.Background = Brushes.Orange;
            }
            if (imt >= 18.5 && imt < 25)
            {
                status = "Нормальный вес";
                recomendations = "Продолжайте в том же духе поддерживать ваше здоровье!";
                TxtStatus.Background = Brushes.Chartreuse;
            }
            if (imt >= 25 && imt < 30)
            {
                status = "Избыточный вес";
                recomendations = "Рекомендуется обратиться к врачу для консультации диеты!";
                TxtStatus.Background = Brushes.Orange;
            }
            if (imt >= 30)
            {
                status = "Ожирение";
                recomendations = "Рекомендуется обратиться к врачу для консультации диеты и дальнейшего лечения!";
                TxtStatus.Background = Brushes.Red;
            }

            TxtStatus.Text = $"Статус: {status}";
            TxtRecomendations.Text = $"Рекомендации: {recomendations}";
        }
        else
        {
            MessageBox.Show("Пожалуйста, введите корректные значения для роста и веса.", "Ошибка ввода");
        }
    }
}