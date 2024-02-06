//Done By: Eyakem Haddish, Elias Degafe, Biruk H/mariam and Solomon Bula 


//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Xml;


//A blueprint for the "Book" we want. It has attributes like title, author, ISBN and year
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public int ISBN { get; set; }
    public int Year { get; set; }


}




public class Program
{
    static List<string> sorted;
    static StringBuilder sortedValues = new StringBuilder();
    static int toSort=0;
    static int numberofBooks = 0;
    static int targetIndex = 0;
    static int forBinarySearch = 0;
    static int IsConsoleBeginning = 0;
    static void Main(string[] args)
    {
        
        List<Book> myCollection = new List<Book>();

        while (true) //Unless we explicitly tell the console to stop, it will run
        {
            IsConsoleBeginning = 0;
            ReadBooksFromWordFile();
            Console.WriteLine("Current Number Of Books: " + (numberofBooks/5));
            Console.WriteLine();
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Check stored Book collections");
            Console.WriteLine("3. Search Book collections(Linear)");
            Console.WriteLine("4. Search Book collections(Binary)");
            Console.WriteLine("5. Sort By Title (Bubble sort)");
            Console.WriteLine("6. Sort By Author (Selection sort)");
            Console.WriteLine("7. Sort By Year (Insertion sort)");
            Console.WriteLine("8. Sort By ISBN Number");
            Console.WriteLine("9. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(myCollection);
                    break;
                case "2":
                    IsConsoleBeginning = 1;
                    ReadBooksFromWordFile();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("1. Search by Title");
                    Console.WriteLine("2. Search by Author");
                    Console.WriteLine("3. Search by ISBN Num.");
                    Console.WriteLine("4. Search by Year");
                    Console.Write("Enter your choice: ");
                    string choi = Console.ReadLine();
                    if(choi=="1")
                    {
                        Console.Write("Enter Title Name: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        LinearSearch(c,1);
                        Console.WriteLine();
                    }
                    else if (choi == "2")
                    {
                        Console.Write("Enter Author Name: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        LinearSearch(c, 2);
                        Console.WriteLine();
                    }
                    else if (choi == "3")
                    {
                        Console.Write("Enter ISBN number: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        LinearSearch(c, 3);
                        Console.WriteLine();
                    }
                    else if (choi == "4")
                    {
                        Console.Write("Enter Publication Year: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        LinearSearch(c, 4);
                        Console.WriteLine();
                    }
                   
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("1. Search by Title");
                    Console.WriteLine("2. Search by Author");
                    Console.WriteLine("3. Search by ISBN Num.");
                    Console.WriteLine("4. Search by Year");
                    Console.Write("Enter your choice: ");
                    string choii = Console.ReadLine();
                    if (choii == "1")
                    {
                        Console.Write("Enter Title of Book: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        BinarySearch(c, 1);
                    }
                    else if (choii == "2")
                    {
                        Console.Write("Enter Author Name: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        BinarySearch(c, 2);
                    }
                    else if (choii == "3")
                    {
                        Console.Write("Enter ISBN number: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                        BinarySearch(c, 3);
                    }
                    else if (choii == "4")
                    {
                        Console.Write("Enter Publication Year: ");
                        string c = Console.ReadLine();
                        Console.WriteLine();
                       BinarySearch(c,4);
                    }
                    break;
                case "5":
                    SortByTitle();
                    break;
                case "6":
                    SortByAuthor();
                    break;
                case "7":
                    SortByYear();
                    break;
                case "8":
                    SortByISBN();
                    break;
                case "9":
                    Console.Clear();
                    Console.WriteLine("Thank you for using our algorithm!!! Bye bye....");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddBook(List<Book> library)
    {
        Console.Clear();
        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine();
        Console.Write("Enter the ISBN number of the book: ");
        int ISBN = int.Parse(Console.ReadLine());
        Console.Write("Enter the publication year of the book: ");
        int year = int.Parse(Console.ReadLine());

        Book newBook = new Book
        {
            Title = title,
            Author = author,
            Year = year,
            ISBN = ISBN
        };

        library.Add(newBook);
        SaveBooksToTextFile(library);
        Console.Clear();
        Console.WriteLine("Book added to Collection.");
    }

    static void SaveBooksToTextFile(List<Book> library)
    {
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter("Library.txt"))
            {
                foreach (var book in library)
                {
                    writer.WriteLine($"Title: {book.Title}");
                    writer.WriteLine($"Author: {book.Author}");
                    writer.WriteLine($"ISBN number: {book.ISBN}");
                    writer.WriteLine($"Year: {book.Year}");
                    writer.WriteLine();
                }
            }
        }

        //if the library file alreadyy exists, it will add on that one
        else {
            using (StreamWriter writer = new StreamWriter("Library.txt",true))
            {
                foreach (var book in library)
                {
                  //  writer.WriteLine();
                    writer.WriteLine($"Title: {book.Title}");
                    writer.WriteLine($"Author: {book.Author}");
                    writer.WriteLine($"ISBN number: {book.ISBN}");
                    writer.WriteLine($"Year: {book.Year}");
                    writer.WriteLine();
                }
            }
        }

        
    }

    static void ReadBooksFromWordFile()
    {
        numberofBooks = 0;
        Console.WriteLine();
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);


        



            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            StringBuilder textContent = new StringBuilder();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    textContent.AppendLine(line);
                numberofBooks++;
                }
            }
            string documentText = textContent.ToString();
        if (IsConsoleBeginning != 0)
        { 
            // Process the document text to extract book details
            // ...

            Console.WriteLine(documentText);

        }

       


    }

//For Binary Searching
//We first have to sort whatever we're searching(title, ISBN, year, author). This will be determined by the searchWhat variable which assigns value 1 for title, 2 for author, 3 for ISBN and 4 for Publication Year
//After it's sorted, we perform a bianry search
    static void BinarySearch(string target, int SearchWhat)
    {
        if (SearchWhat == 1)
        {
            forBinarySearch = 1;
            SortByTitle();
            forBinarySearch = 0;
            forBinarySearch = 0;
            Console.Clear();
            //Console.WriteLine("Should be here");
            //Console.WriteLine(sortedValues);
            string[] lines = sortedValues.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] sorted = new string[lines.Length]; // Initialize the 'sorted' array
            int yo = 0;

            foreach (string line in lines)
            {
                try
                {

                    string[] store = line.Split(' ');
                    int k = 1;
                   
                        while (store[k] != "Author:")
                        {
                            sorted[yo] += store[k];
                        sorted[yo] += ' ';
                        k++;
                        }
                      
                    yo++;
                }
                catch (Exception ex)
                {
                    break;
                }

            }




           // Console.WriteLine(sorted.Length);   

           // foreach (string sort in sorted)
           //{
           //     Console.WriteLine(sort);
           // }


            Console.Clear();
            Console.WriteLine("Sorted and searched for " + "Title " + target + " using Binary Search");
            Console.WriteLine();


            //BINARY SEARCH IMPLEMENTATION
            int left = 0;
            int right = sorted.Length - 1;

          

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                string targetPLUS = target + ' '; // while we we were sorting the array, we added spaces in between each words including the end of the words. 
                int comparisonResult = string.Compare(sorted[mid].ToLower(), targetPLUS.ToLower());

                if (comparisonResult == 0)
                {
                    // Match found
                   
                     Console.WriteLine(lines[mid]);
                    sortedValues.Clear();
                    Main(null);
                   
                  
                }
                else if (comparisonResult < 0)
                {
                  //  Console.WriteLine("right");
                    // sorted[mid] is less than target, search in right half
                    left = mid + 1;
                }
                else
                {
                   // Console.WriteLine("left");
                    // sorted[mid] is greater than target, search in left half
                    right = mid - 1;
                }
            }
         Console.WriteLine("Search not found:(");
   

        }
        else if (SearchWhat == 2)
        {
            forBinarySearch = 1;
            SortByAuthor();
            forBinarySearch = 0;
            forBinarySearch = 0;
            Console.Clear();
            //Console.WriteLine("Should be here");
            //Console.WriteLine(sortedValues);
            string[] lines = sortedValues.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] sorted = new string[lines.Length]; // Initialize the 'sorted' array
            int yo = 0;

            foreach (string line in lines)
            {
                try
                {

                    string[] store = line.Split(' ');
                    int k = 1;

                    while (store[k] != "Title:")
                    {
                        sorted[yo] += store[k];
                        sorted[yo] += ' ';
                        k++;
                    }

                    yo++;
                }
                catch (Exception ex)
                {
                    break;
                }

            }




            // Console.WriteLine(sorted.Length);   

            // foreach (string sort in sorted)
            //{
            //     Console.WriteLine(sort);
            // }


            Console.Clear();
            Console.WriteLine("Sorted and searched for " + "Author " + target + " using Binary Search");
            Console.WriteLine();


            //BINARY SEARCH IMPLEMENTATION
            int left = 0;
            int right = sorted.Length - 1;



            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                string targetPLUS = target + ' '; // while we we were sorting the array, we added spaces in between each words including the end of the words. 
                int comparisonResult = string.Compare(sorted[mid].ToLower(), targetPLUS.ToLower());

                if (comparisonResult == 0)
                {
                    // Match found

                    Console.WriteLine(lines[mid]);
                    sortedValues.Clear();

                    Main(null);


                }
                else if (comparisonResult < 0)
                {
                    //  Console.WriteLine("right");
                    // sorted[mid] is less than target, search in right half
                    left = mid + 1;
                }
                else
                {
                    // Console.WriteLine("left");
                    // sorted[mid] is greater than target, search in left half
                    right = mid - 1;
                }
            }
            Console.WriteLine("Search not found:(");


        }
        else if (SearchWhat == 3)
        {
            forBinarySearch = 1;
            SortByISBN();
            forBinarySearch = 0;
            forBinarySearch = 0;
            //Console.WriteLine("Should be here");
            //Console.WriteLine(sortedValues);
            string[] lines = sortedValues.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] sorted = new string[lines.Length]; // Initialize the 'sorted' array
            int yo = 0;

            foreach (string line in lines)
            {
                try
                {
                    string[] store = line.Split(' ');
                    sorted[yo] = store[2];
                    yo++;
                }
                catch (Exception ex)
                {
                    break;
                }

            }




            //Console.WriteLine(sorted.Length);   

            //foreach (string sort in sorted)
            //{
            //    Console.WriteLine(sort);
            //}


            Console.Clear();
            Console.WriteLine("Sorted and searched for " + "ISBN number " + target + " using Binary Search");
            Console.WriteLine();


            //BINARY SEARCH IMPLEMENTATION
            int left = 0;
            int right = sorted.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sorted[mid] == target)
                {
                    Console.WriteLine(lines[mid]);
                    sortedValues.Clear();

                    Main(null);
                }

                if (BigInteger.Parse(sorted[mid]) < BigInteger.Parse(target))
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            Console.WriteLine("Search not found:(");

        }
        else if (SearchWhat == 4)
        {
            forBinarySearch = 1;
            SortByYear();
            forBinarySearch = 0;
            forBinarySearch = 0;
            //Console.WriteLine("Should be here");
            //Console.WriteLine(sortedValues);
            string[] lines = sortedValues.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] sorted = new string[lines.Length]; // Initialize the 'sorted' array
            int yo = 0;
            
            foreach (string line in lines)
            {
                try {
                    string[] store = line.Split(' ');
                    sorted[yo] = store[1];
                    yo++;
                } catch(Exception ex) {
                    break;
                }
                
            }




            //Console.WriteLine(sorted.Length);   

            //foreach (string sort in sorted)
            //{
            //    Console.WriteLine(sort);
            //}


            Console.Clear();
            Console.WriteLine("Sorted and searched for " + "YEAR "+target + " using Binary Search");
                Console.WriteLine();


            //BINARY SEARCH IMPLEMENTATION
            int left = 0;
            int right = sorted.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sorted[mid] == target)
                {
                    Console.WriteLine(lines[mid]);
                    sortedValues.Clear();

                    Main(null);
                }

                if (int.Parse(sorted[mid]) < int.Parse(target))
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            Console.WriteLine("Search not found:(");
           
        }
        sortedValues.Clear();
    }


    //Here is a function to perform linear search after going through each title,author,sibn or year based on the search criteria
    static void LinearSearch(string target, int SearchWhat)
    {
        
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        StringBuilder textContent = new StringBuilder();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string allText = reader.ReadToEnd();
           // string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
           //Split the text into lines
            string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                string[] words = currentLine.Split(' ');//Split the lines into words

                string[] targetWords = target.Split(' ');
                

               


                for (int x = 0; x < words.Length; x++)
                {
                    //All of the words extracted from the text are turned to Lower case to ensure we get the result we want even if we didn't capitalize while searching
                    //For Example: Searching for "john" would result in John, JOHN, JOhn

                    if ((words[x].Trim()).ToLower() == targetWords[targetIndex].ToLower() && SearchWhat == 1)

                    {
                       

                        int p = 0;
                        double closness = 0;
                        try
                        {
                        if (words[x - 1] == "Author:" || words[x - 2] == "Author:" || words[x - 3] == "Author:") continue; //we don't want to search author, so if there's an author name with this target word, we skip the current index

                        }
                        catch(Exception ex) { 
                        }
                        if (targetWords.Length > 1)
                        {
                            if (targetIndex != 0)
                            {
                                for (int j = 0; j < targetWords.Length - 1; j++)
                                {
                                    if (words[x + p].ToLower() == targetWords[targetIndex + p].ToLower())
                                    {
                                        closness = closness+3;

                                        p++;

                                    }
                                }
                            }
                            else
                            {


                                foreach (string targetword in targetWords)
                                {
                                    try
                                    {
                                        if (words[x + p].ToLower() == targetWords[targetIndex + p].ToLower())
                                        {
                                            closness=closness+3;

                                            p++;

                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        break;
                                    }

                                }
                            }

                                    
                              
                            //THE lord of the rings and Lord of the rings
                            if (words[x - 1] != "Title:") closness--;
                            //  Console.WriteLine(closness);
                            //For some reason
                            if(toSort==1) closness=closness+3;

                            if (closness == targetWords.Length*3)
                            {
                                //Don't display this if u are searching to display a sorted list
                                if (toSort != 1)
                                {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("1 Exact Match");
                                Console.ResetColor();

                                }
                                if (forBinarySearch == 1)
                                {
                                    sortedValues.AppendLine(currentLine + " " + lines[i + 1] + " " + lines[i + 2] + " " + lines[i + 3] + " ");
                               

                                }
                                else
                                {

                                textContent.AppendLine("------------------------------");
                               // Console.ForegroundColor = ConsoleColor.Blue;
                                textContent.AppendLine(currentLine);
                                textContent.AppendLine(lines[i + 1]);
                                textContent.AppendLine(lines[i + 2]);
                                textContent.AppendLine(lines[i + 3]);
                                textContent.AppendLine("------------------------------");
                                }
                            }
                           
                           else if (closness > (targetWords.Length)+2   && toSort !=1 )
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("1 Best Match");
                                    Console.ResetColor();
                                    textContent.AppendLine("------------------------------");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    textContent.AppendLine(currentLine);
                                    textContent.AppendLine(lines[i + 1]);
                                    textContent.AppendLine(lines[i + 2]);
                                    textContent.AppendLine(lines[i + 3]);
                                    textContent.AppendLine("------------------------------");
                                }

                            ////If target index is not on the beginning(0), the closness can be more skewed, and we would still consider it a match
                            //if (toSort == 0 && closness == (targetWords.Length) - 2 || closness == (targetWords.Length) - 3 && toSort != 1 && targetIndex != 0)
                            //{
                            //    Console.ForegroundColor = ConsoleColor.Yellow;
                            //    Console.WriteLine("1 Best Match");
                            //    Console.ResetColor();
                            //    textContent.AppendLine("------------------------------");
                            //    Console.ForegroundColor = ConsoleColor.Yellow;
                            //    textContent.AppendLine(currentLine);
                            //    textContent.AppendLine(lines[i + 1]);
                            //    textContent.AppendLine(lines[i + 2]);
                            //    textContent.AppendLine(lines[i + 3]);
                            //    textContent.AppendLine("------------------------------");
                            //}



                        }
                        else 
                            {
                            textContent.AppendLine("------------------------------");
                                textContent.AppendLine(currentLine);
                                textContent.AppendLine(lines[i + 1]);
                                textContent.AppendLine(lines[i + 2]);
                                textContent.AppendLine(lines[i + 3]);
                                textContent.AppendLine("------------------------------");
                            }
                        
                    }
                    else if ((words[x].Trim()).ToLower() == targetWords[targetIndex].ToLower() && SearchWhat == 2)
                    {
                        int p = 0;
                        int closness = 0;
                        if (words[x - 1] == "Title:") continue; //we don't want to search title, so if there's an title name with this target word, we skip the current index
                        if (toSort==1)
                        {
                            foreach (string targetword in targetWords)
                            {

                                try
                                {
                                    if (words[x + p].ToLower() == targetWords[targetIndex + p].ToLower())
                                    {
                                        closness++;

                                        p++;

                                    }

                                }
                                catch (Exception e)
                                {
                                    break;
                                }

                            }
                            //JAmes smIth and Mr. James Smith
                            if (words[x - 1] != "Author:") closness--;
                            //  Console.WriteLine(closness);
                            if (closness == targetWords.Length )
                            {
                               
                                if (forBinarySearch == 1)
                                {
                                    sortedValues.AppendLine(currentLine + " " + lines[i - 1] + " " + lines[i + 1] + " " + lines[i + 2] + " ");


                                }
                                else
                                {
                                    textContent.AppendLine("------------------------------");

                                    textContent.AppendLine(lines[i - 1]);
                                    textContent.AppendLine(currentLine);
                                    textContent.AppendLine(lines[i + 1]);
                                    textContent.AppendLine(lines[i + 2]);
                                    textContent.AppendLine("------------------------------");
                                }
                               
                            }
                            //If target index is not on the beginning(0), the closness can be more skewed, and we would still consider it a match
                            else if (toSort == 0 && closness == (targetWords.Length) - 2 || closness == (targetWords.Length) - 3 && toSort != 1 && targetIndex != 0)
                            {
                                
                                
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("1 Best Match");
                                    Console.ResetColor();
                                    textContent.AppendLine("------------------------------");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    textContent.AppendLine(currentLine);
                                    textContent.AppendLine(lines[i + 1]);
                                    textContent.AppendLine(lines[i + 2]);
                                    textContent.AppendLine(lines[i + 3]);
                                    textContent.AppendLine("------------------------------");
                                
                               
                            }
                        }
                        else
                        {
                            
                            
                                textContent.AppendLine("------------------------------");
                                textContent.AppendLine(lines[i - 1]);
                                textContent.AppendLine(currentLine);
                                textContent.AppendLine(lines[i + 1]);
                                textContent.AppendLine(lines[i + 2]);
                                textContent.AppendLine("------------------------------");
                            
                           
                        }

                    }
                    else if ((words[x].Trim()).ToLower() == target.ToLower() && SearchWhat == 3)
                    {
                        if (forBinarySearch == 1)
                        {
                            sortedValues.AppendLine(currentLine + " " + lines[i - 2] + " " + lines[i - 1] + " " + lines[i+1] + " ");

                        }
                        else
                        {
                            textContent.AppendLine("------------------------------");
                            textContent.AppendLine(lines[i - 2]);
                            textContent.AppendLine(lines[i - 1]);
                            textContent.AppendLine(currentLine);
                            textContent.AppendLine(lines[i + 1]);
                            textContent.AppendLine("------------------------------");
                        }

                    }
                    else if ((words[x].Trim()).ToLower() == target.ToLower() && SearchWhat == 4)
                    {
                        if (forBinarySearch == 1)
                        {
                            sortedValues.AppendLine(currentLine + " " + lines[i - 3] + " " + lines[i - 2] + " " + lines[i - 1] + " ");
                            
                        }
                        else
                        {
                            textContent.AppendLine("------------------------------");
                            textContent.AppendLine(lines[i - 3]);
                            textContent.AppendLine(lines[i - 2]);
                            textContent.AppendLine(lines[i - 1]);
                            textContent.AppendLine(currentLine);
                            textContent.AppendLine("------------------------------");
                        }
                       

                        
                        
                    }


                    
                   

                }
            }
        }
        if (forBinarySearch == 1)
        {
            return;
        }
        string documentText = textContent.ToString();
        if (string.IsNullOrEmpty(documentText))
        {
                for (int x=0;x<3;x++)
                {
            try
            {
                 //   Console.WriteLine("I'm in");
                    targetIndex++;
                    LinearSearch(target, SearchWhat);

                }
            catch (Exception ex)
            {
                    break;
                }
                
            }
            targetIndex = 0;
            

            if(forBinarySearch == 0)
            {
            Console.WriteLine("Search not found :(");
            Main(null);

            }
           
        }

        if (toSort != 1) {
            string[] lines2 = documentText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);//Split the text into lines
            //Every 4 lines is one item, so we divide the total nummber of lines by 4
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total {(lines2.Length) / 6} item/s found");
            Console.ResetColor();
        }
       
        Console.WriteLine();
        Console.WriteLine(documentText);


        
    }

    //Sort By title using bubble sort. First we extract the titles from the text file and sort them based on their alphabetical order. Once it's done, it'll be displayed
    static void SortByTitle()
    {
        Console.Clear();
        Console.Write("SORTED BY TITLE (USING BUBBLE SORT ALGORITHM)");
        Console.WriteLine();
        Console.WriteLine();
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<string> titles = new List<string>();
        
        
        int x = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string allText = reader.ReadToEnd();
            string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);//Split the text into lines

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                string[] words = currentLine.Split(' ');//Split the lines into words

                for (int j = 0; j < words.Length; j++) 
                {
                    if (words[j] == "Title:") 
                    {
                        string titleValue = string.Empty;
                        int nextIndex = j + 1;
                        while (nextIndex < words.Length)
                        {
                            titleValue += words[nextIndex] + ' ';
                            nextIndex++;

                        }
                        titles.Add(titleValue);

                    }
                }
            }


        }
        // Bubble sort
        for (int i = 0; i < titles.Count - 1; i++)
        {
            for (int j = 0; j < titles.Count - i - 1; j++)
            {
                if (string.Compare(titles[j], titles[j + 1]) > 0)
                {
                    string temp = titles[j];
                    titles[j] = titles[j + 1];
                    titles[j + 1] = temp;
                }
            }
        }
        //foreach (string Title in titles) { 
        //Console.WriteLine(Title);
        //}
        toSort = 1;
        //Search sorted titles and display each one of them
        LinearSearch(titles[0], 1); // This will help us as a starter, because whenever we tried to check if the title is repeated(if (title[i] != title[i-1])), i-1 would be out of range
        for (int i = 1; i < titles.Count; i++)
        {
          
            //Titles with same name should not be searched twice, because one search will display both titles
            if (titles[i].ToLower() != titles[i - 1].ToLower())
                LinearSearch(titles[i], 1);
        }
        toSort = 0;
    }

    //Sort By author using Selection sort. First we extract the authors from the text file and sort them based on their alphabetical order. Once it's done, it'll be displayed

    static void SortByAuthor()
    {
        Console.Clear();
        Console.Write("SORTED BY AUTHORS (USING SELECTION SORT ALGORITHM)");
        Console.WriteLine();
        Console.WriteLine();
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<string> authors = new List<string>();


        int x = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string allText = reader.ReadToEnd();
            string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);//Split the text into lines

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                string[] words = currentLine.Split(' ');//Split the lines into words

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == "Author:")
                    {
                        string authorValue = string.Empty;
                        int nextIndex = j + 1;
                        while (nextIndex<words.Length) {
                             authorValue += words[nextIndex] + " ";
                            nextIndex++;

                        }
                        authors.Add(authorValue.Trim());

                    }
                }
            }


        }
        // Selection sort
        int n = authors.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (string.Compare(authors[j], authors[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            string temp = authors[minIndex];
            authors[minIndex] = authors[i];
            authors[i] = temp;
        }
        toSort = 1;
        //Search sorted authors and display each one of them
        LinearSearch(authors[0], 2);
        for (int i = 1; i < authors.Count; i++)
        {
            if (authors[i] != authors[i - 1])
                LinearSearch(authors[i], 2);
        }
        Console.Write("---------------------------------------------------");

        toSort = 0;
    }

    //Sort By year using insertion sort. First we extract the authors from the text file and sort them based on their value. Once it's done, it'll be displayed

    static void SortByYear()
    {
        Console.Clear();
        Console.Write("SORTED BY PUBLICATION YEAR (USING INSERTION SORT ALGORITHM)");
        Console.WriteLine();
        Console.WriteLine();
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            Main(null);
        }

        List<string> years = new List<string>();


        int x = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string allText = reader.ReadToEnd();
            string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);//Split the text into lines

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                string[] words = currentLine.Split(' ');//Split the lines into words

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == "Year:")
                    {
                        years.Add(words[j + 1]);

                    }
                }
            }


        }
        // Insertion sort
        int n = years.Count;
        for (int i = 1; i < n; ++i)
        {
            int key = int.Parse(years[i]);
            int j = i - 1;

            while (j >= 0 && int.Parse(years[j]) > key)
            {
                years[j + 1] = years[j];
                j = j - 1;
            }
            years[j + 1] = key.ToString();
        }
        //if (forBinarySearch == 1) return years;
        //else
        //{
            toSort = 1;
            //Search sorted year and display each one of them
            LinearSearch(years[0], 4);   // This will help us as a starter, because whenever we tried to check if the year is repeated(if (years[i] != years[i-1])), i-1 would be out of range
            for (int i = 1; i < years.Count; i++)
            {
                if (years[i] != years[i - 1])
                    LinearSearch(years[i], 4);
            }
            toSort = 0;

         

        
           

    }

    //Sort By ISBN using insertion sort. First we extract the ISBN numbers from the text file and sort them based on their given values. Once it's done, it'll be displayed

    static void SortByISBN()
    {
        Console.Clear();
        Console.Write("SORTED BY ISBN Number (USING INSERTION SORT ALGORITHM)");
        Console.WriteLine();
        Console.WriteLine();
        string fileName = "Library.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            Main(null);
        }

        List<string> isbn = new List<string>();


        int x = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string allText = reader.ReadToEnd();
            string[] lines = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);//Split the text into lines

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                string[] words = currentLine.Split(' ');//Split the lines into words

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == "number:")
                    {
                        isbn.Add(words[j + 1]);

                    }
                }
            }


        }
        // Insertion sort
        int n = isbn.Count;
        for (int i = 1; i < n; ++i)
        {
            BigInteger key = BigInteger.Parse(isbn[i]);
            int j = i - 1;

            while (j >= 0 && BigInteger.Parse(isbn[j]) > key)
            {
                isbn[j + 1] = isbn[j];
                j = j - 1;
            }
            isbn[j + 1] = key.ToString();
        }
        //if (forBinarySearch == 1) return years;
        //else
        //{
        toSort = 1;
        //Search sorted year and display each one of them
        LinearSearch(isbn[0], 3);   // This will help us as a starter, because whenever we tried to check if the year is repeated(if (years[i] != years[i-1])), i-1 would be out of range
        for (int i = 1; i < isbn.Count; i++)
        {
            if (isbn[i] != isbn[i - 1])
                LinearSearch(isbn[i], 3);
        }
        toSort = 0;






    }
}