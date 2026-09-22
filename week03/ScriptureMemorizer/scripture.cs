using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(
            new[] { ' ', '\n', '\r', '\t' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(
            " ",
            _words.Select(word => word.GetDisplayText())
        );

        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }

    public void HideRandomWords(int numberOfWords)
    {
        // Stretch challenge:
        // Only select words that have not already been hidden.
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        int wordsToHide = Math.Min(numberOfWords, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);

            Word selectedWord = visibleWords[randomIndex];
            selectedWord.Hide();

            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}