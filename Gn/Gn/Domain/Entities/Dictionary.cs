namespace Gn.Domain.Entities
{
    class EnglishFrenchDictionary
    {
        private Dictionary<string, List<string>> dictionary = new();

        public void AddWord(string english, string french)
        {
            if (string.IsNullOrWhiteSpace(english) || string.IsNullOrWhiteSpace(french))
            {
                Console.WriteLine("Слова не могут быть пустыми!");
                return;
            }

            english = english.Trim().ToLower();

            if (!dictionary.ContainsKey(english))
            {
                dictionary[english] = new List<string>();
            }

            if (!dictionary[english].Contains(french))
            {
                dictionary[english].Add(french);
                Console.WriteLine($"Добавлен перевод: {english} → {french}");
            }
            else
            {
                Console.WriteLine($"Перевод '{french}' для слова '{english}' уже существует.");
            }
        }

        public bool RemoveWord(string english)
        {
            english = english.Trim().ToLower();
            if (dictionary.Remove(english))
            {
                Console.WriteLine($"Слово '{english}' полностью удалено.");
                return true;
            }
            Console.WriteLine($"Слово '{english}' не найдено.");
            return false;
        }

        public bool RemoveTranslation(string english, string french)
        {
            english = english.Trim().ToLower();

            if (dictionary.TryGetValue(english, out List<string> translations))
            {
                if (translations.Remove(french))
                {
                    Console.WriteLine($"Удалён перевод '{french}' у слова '{english}'");

                    if (translations.Count == 0)
                    {
                        dictionary.Remove(english);
                        Console.WriteLine($"(Слово '{english}' удалено — закончились переводы)");
                    }
                    return true;
                }
            }

            Console.WriteLine($"Перевод '{french}' для '{english}' не найден.");
            return false;
        }

        public bool UpdateTranslation(string english, string oldFrench, string newFrench)
        {
            english = english.Trim().ToLower();

            if (dictionary.TryGetValue(english, out List<string> translations))
            {
                int index = translations.IndexOf(oldFrench);
                if (index != -1)
                {
                    translations[index] = newFrench;
                    Console.WriteLine($"Перевод изменён: {english}  {oldFrench} → {newFrench}");
                    return true;
                }
            }

            Console.WriteLine($"Перевод '{oldFrench}' для '{english}' не найден.");
            return false;
        }

        public void FindTranslations(string english)
        {
            english = english.Trim().ToLower();

            if (dictionary.TryGetValue(english, out List<string> translations))
            {
                Console.WriteLine($"\nСлово '{english}' переводится как:");
                foreach (var tr in translations)
                {
                    Console.WriteLine($"  • {tr}");
                }
            }
            else
            {
                Console.WriteLine($"Слово '{english}' в словаре не найдено.");
            }
        }

        public void ShowDictionary()
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Словарь пуст.");
                return;
            }

            Console.WriteLine("\n=== Англо-французский словарь ===");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"\n{pair.Key,-15}:");
                foreach (var translation in pair.Value)
                {
                    Console.WriteLine($"              → {translation}");
                }
            }
        }
    }
}
