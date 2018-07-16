using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseStudyTool
{
    // This is the main class that will handle keeping track of all the vocab and scoring.
    public class Sensei
    {
        public double score; // used to grade the user on their proficiency
        public double maxScore; // max score attainable through the exam
        public List<Word> vocabList = new List<Word>(); // Creating the vocab list
        public List<Word> vocabList2 = new List<Word>(); // This is a copy to subtract from         
        public List<Word> practiceList = new List<Word>(); // This will be a list of X (I'm thinking 10) elements to put in a drop-down menu 

        // THe location to save all the vocab data
        public static string vocabSaveLocation = AppDomain.CurrentDomain.BaseDirectory + "VocabData.txt";
        public string[] ALLVOCABINFO = new string[25]; // Gotta prepare for the worst XD


        public Sensei()
        {
            // Ctor
            LoadVocab();
            SaveVocab();
        }

        public void generatePracticeList()
        {
            Random rnd = new Random(); // create a random number to shuffle words into the practice list.
            

            if(vocabList2.Count <= 10)
            {
                for(int v = 0; v < vocabList.Count; v++)
                {
                    MainWindow.temp = vocabList2[rnd.Next(vocabList2.Count())];
                    practiceList.Add(MainWindow.temp);
                }
            }
        }

        public void SaveVocab()
        {
            for (int w = 0; w < vocabList.Count; w++)
            {
                // So I don't save blanks
                if (vocabList[w].kana != "" || vocabList[w].english != "")
                {
                    ALLVOCABINFO[w] = vocabList.ElementAt(w).kana + ',' + vocabList.ElementAt(w).english + ','
                        + vocabList.ElementAt(w).kanji;
                }
            }

            //System.IO.File.AppendAllLines(SaveInventorylocation, ALLINVENTORYINFO);
            System.IO.File.WriteAllLines(vocabSaveLocation, ALLVOCABINFO);
        }

        public void LoadVocab()
        {
            try
            {

                ALLVOCABINFO = System.IO.File.ReadAllLines(vocabSaveLocation);

                for (int il = 0; il < ALLVOCABINFO.Length; il++)
                {
                    // Take a single loaded Word from the array and separate the components into another array for transfer
                    string[] oneWord = ALLVOCABINFO[il].Split(',');

                    // Check if the oneWord is blank. If not, add to inventory, this is to prevent blanks from being added
                    if (oneWord[0] != "")
                    {
                        vocabList2.Add(new Word());
                        vocabList2[il].kana = oneWord[0];
                        vocabList2[il].english = oneWord[1];
                        vocabList2[il].kanji = oneWord[2];
                    }
                }

                vocabList = vocabList2; // saving an original copy

            }
            catch(Exception e)
            {
                ALLVOCABINFO.Initialize();
            }
        }
    }
}
