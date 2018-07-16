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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JapaneseStudyTool
{
    /// <summary>
    /// Interaction logic for StudyPage.xaml
    /// </summary>
    public partial class StudyPage : Page
    {
        public StudyPage()
        {
            InitializeComponent();
            
            randomPickVocab();

            for (int j = 0; j < MainWindow.satoko.vocabList2.Count; j++)
            {
                if (MainWindow.satoko.vocabList2[j].english != "")
                {
                    DefinitionPicker.Items.Add(MainWindow.satoko.vocabList2[j].english);
                }
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.satoko.maxScore += 1;
            
            for(int y = 0; y < MainWindow.satoko.vocabList2.Count(); y++)
            {
                if(Convert.ToString(MainWindow.satoko.vocabList2[y].kana) == Convert.ToString(VocabWordRealLbl.Content) || Convert.ToString(MainWindow.satoko.vocabList2[y].kanji) == Convert.ToString(VocabWordRealLbl.Content))
                {
                    if(Convert.ToString(MainWindow.satoko.vocabList2[y].english) == Convert.ToString(DefinitionPicker.SelectionBoxItem))
                    {
                        // right answer
                        MainWindow.satoko.score += 1;
                        MainWindow.satoko.vocabList2.RemoveAt(y);
                        DefinitionPicker.Items.Clear();

                        for (int j = 0; j < MainWindow.satoko.vocabList2.Count; j++)
                        {
                            if (MainWindow.satoko.vocabList2[j].english != "")
                            {
                                DefinitionPicker.Items.Add(MainWindow.satoko.vocabList2[j].english);
                            }
                        }

                        DefinitionPicker.Items.Refresh();

                        randomPickVocab();

                    }
                }
            }

            DefinitionPicker.Text = "";

        }

        // Creates the correct answer and makes a list of choices to choose from
        void randomPickVocab()
        {
            Random rnd = new Random();
            int randomPick;

            randomPick = rnd.Next(MainWindow.satoko.vocabList2.Count());

            if (MainWindow.satoko.vocabList2[randomPick].kanji != "")
                VocabWordRealLbl.Content = MainWindow.satoko.vocabList2[randomPick].kanji;
            else
                VocabWordRealLbl.Content = MainWindow.satoko.vocabList2[randomPick].kana;

            // Add the answer to the practice list to ensure it will be avaliable
            MainWindow.satoko.practiceList.Add(MainWindow.satoko.vocabList2[randomPick]);

            // this will make the practiceList 10 elements large, with random answers.
            for(int adder = 0; adder < 9; adder++)
            {

            }
        }
        
        void ShuffleList()
        {

        }
    }
}
