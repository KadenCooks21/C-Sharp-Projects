List<booktype> Book = new List<booktype>();

GetStuffFromFile(Book);

bool run = true;
int hold = printDown(0, Book);

while (run) 
{ 
    Console.WriteLine("\nEnter number to view chapter\nU - up, D - down, X - exit\n"); 
    int number;
    string choice = Console.ReadLine();
    //Console.WriteLine(hold);
    if (choice.Equals("U") || choice.Equals("u"))
    {
        hold = printUp(hold, Book);
    }
    else if (choice.Equals("D") || choice.Equals("d"))
    {
        hold = printDown(hold, Book);
    }
    else if (choice.Equals("X") || choice.Equals("x"))
    {
        run = false;
    }
    else if (int.TryParse(choice, out number))
    {
        if (number >= 0 && number <= Book.Count)
        {
            int hold2 = printBookDown(0, Book, number);
            bool run2 = true;
            while (run2)
            {
                Console.WriteLine("\nU - up, D - down, X - exit\n"); 
                string choice2 = Console.ReadLine();
                if (choice2.Equals("U") || choice2.Equals("u"))
                {
                    hold2 = printBookUp(hold2, Book, number);
                }
                else if (choice2.Equals("D") || choice2.Equals("d"))
                {
                    hold2 = printBookDown(hold2, Book, number);
                }
                else if (choice2.Equals("X") || choice2.Equals("x"))
                {
                    run2 = false;
                }
            }
        }
        else
        {
            Console.WriteLine("Please Enter a valid number.");
        }
    }
}

int printUp(int place, List<booktype> Book)
{
    if (place == 0)
    {
        Console.WriteLine("Cannot move up");
        return place;
    }

    if (place % 20 != 0)
    {
        for (int i = place - (place % 20); i < place; i++)
        {
            Console.WriteLine($"{i}: {Book[i].chapter}");
        }

        return place - (place % 20);
    }
    for (int i = place - 20; i < place; i++)
    {
        Console.WriteLine($"{i}: {Book[i].chapter}");
    }
    return place - 20;
}

int printDown(int place, List<booktype> Book)
{
    if (place == Book.Count)
    {
        Console.WriteLine("Cannot move down");
        return place;
    }
    if (Book.Count - place < 20)
    {
        for (int i = place; i < place + (Book.Count - place); i++)
        {
            Console.WriteLine($"{i}: {Book[i].chapter}");
        }
        return place + (Book.Count - place);
    }
    for (int i = place; i < place + 20; i++)
    {
        Console.WriteLine($"{i}: {Book[i].chapter}");
    }
    return place + 20;
}

int printBookUp(int place, List<booktype> Book, int number)
{
    if (place == 0)
    {
        Console.WriteLine("Cannot move up");
        return place;
    }

    if (place % 20 != 0)
    {
        for (int i = place - (place % 20); i < place; i++)
        {
            Console.WriteLine(Book[number].body[i]);
        }
        return place - (place % 20);
    }
    for (int i = place - 20; i < place; i++)
    {
        Console.WriteLine(Book[number].body[i]);
    }
    return place - 20;
}

int printBookDown(int place, List<booktype> Book, int number)
{
    if (place == Book[number].body.Count)
    {
        Console.WriteLine("Cannot move down");
        return place;
    }
    if (Book[number].body.Count - place < 20)
    {
        for (int i = place; i < place + (Book[number].body.Count - place); i++)
        {
            Console.WriteLine(Book[number].body[i]);
        }
        return place + (Book[number].body.Count - place);
    }
    for (int i = place; i < place + 20; i++)
    {
        Console.WriteLine(Book[number].body[i]);
    }
    return place + 20;
}

void bookMaker(List<booktype> Book, string d)
{
    var book1 = new booktype();
    book1.chapter = d;
    book1.body = new List<string>();
    Book.Add(book1);
}

void GetStuffFromFile(List<booktype> Book)
{
    string d = "";
    int bookCount = 0;
    using var reader = new StreamReader("../../../../LeavesOfGrassWhitman.txt");
    while ((d = reader.ReadLine()) != null)
    {
        if (bookCount == 0)
        {
            bookCount++;
            string s = "TITLE. " + d;
            bookMaker(Book, s);
        }
        else if (d.Contains("BOOK"))
        {
            bookCount++;
            bookMaker(Book, d);
        }
        else
        {
            Book[bookCount - 1].body.Add(d);
        }
    }
}

struct booktype
{
    public string chapter;
    public List<string> body;
}