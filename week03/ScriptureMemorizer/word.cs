using System;
using System.Linq;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Replace letters and numbers with underscores,
        // while keeping punctuation such as commas and periods.
        return string.Concat(
            _text.Select(character =>
                char.IsLetterOrDigit(character) ? '_' : character.ToString())
        );
    }
}