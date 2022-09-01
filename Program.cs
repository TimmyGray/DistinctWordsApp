using System.IO;
using System.Text;
using System.Linq;
using DistinctWordsApp.Classes;

string pathread = $"{Directory.GetCurrentDirectory()}\\Books\\book.txt"; //Путь до файла с текстом
string pathwrite = $"{Directory.GetCurrentDirectory()}\\Books\\words.txt"; //Путь до файла в котором
                                                                           //будет находится итоговый,
                                                                           //отсортированный результат

StringBuilder builder = new StringBuilder(); //обьект, в который будет считываться текстовый файл.Используем
                                             //именно стрингбилдер, чтобы сэкономить память

using (StreamReader sr = File.OpenText(pathread)) //читаем текстовый файл
{
	while (!sr.EndOfStream)
	{
       builder.Append(sr.ReadLine());
    }
   
}

string book = builder.ToString(); //преобразует стрингбилдер в строчку, для дальнейшей обработки

char[] splitchars = { 
    '.', ',', '!', '?', ' ',
    '1', '2', '3', '4', '5',
    '6', '7', '8', '9', '0',
    '(',')' };                  //задаем возможные символы, которые отделяют слова
string[] words = book.Split(splitchars); //разделяем весь текст на отдельные слова

var res = words.Distinct().Where(w=>w!=""); //создаем массив из отдельных неповторяющихся слов

List<Word> listofwords = new List<Word>();

 foreach (var item in res)      //для каждого уникального слова, из массива, мы создаем
                                //специальный обьект структуру, которая кроме слова,
                                //хранит количество употрелений этого слова, и добавляем в список
{
    Word word = new Word(item);
    var wordcounts = words.Where(w => w == item).Count();
    word.SetCount(wordcounts);

    Console.WriteLine($"{word.Value()}-{word.Count()}");
    listofwords.Add(word);
}

var orderbycounts = listofwords.OrderByDescending(w => w.Count()); //сортируем список структур по количеству употреблений

using (StreamWriter sw = new StreamWriter(pathwrite,false)) //записываем итоговый результат в отдельный файл
{
    foreach (Word item in orderbycounts)
    {
       sw.WriteLine($"{item.Value()} - {item.Count()}");
    }

    Console.WriteLine("Файл с отсортированными словами успешно создан!");
    Console.ReadKey();
}
