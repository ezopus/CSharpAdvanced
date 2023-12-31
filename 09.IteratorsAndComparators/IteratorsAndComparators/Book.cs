﻿using System.Collections;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }
    }
}
