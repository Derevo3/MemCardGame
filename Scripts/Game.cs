using UnityEngine;
using System.Collections.Generic;
using System;
using SysRandom = System.Random;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEditor.ShaderKeywordFilter;

public static class ListExtensions
{
    private static readonly SysRandom rng = new SysRandom();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

public class Game : MonoBehaviour
{
    // Сброс
    List <int> foldMem = new ();
    List <int> foldSituation = new ();
    // Стол
    List <int> tableMem = new (4);
    List <int> tableSituation = new (1);

    // Создание и перемешивание колоды мемов и ситуаций
    List <int> listMem = new ();
    List <int> listSituation = new ();
    int countMem = 40;
    void CreateDeck()
    {
        for (int i = 0; i < countMem + 1; i++)
        {
            listMem.Add(i);
        }
        listMem.Shuffle(); // Метод для перемешивания значений в listMem
        Debug.Log(string.Join(", ", listMem)); //Вывод значений listMem в строку
        for (int i = 0; i < 40; i++)
        {
            listSituation.Add(i);
        }
        listSituation.Shuffle();
    }
    
    // Раздача игрокам карт
    List <int> handPlayer1 = new ();
    List <int> handPlayer2 = new ();
    List <int> handPlayer3 = new ();
    List <int> handPlayer4 = new ();
    void CreateHandPlayers()
    {
        for (int i = 0; i < 5; i++)
        {
            int card = listMem[countMem];
            handPlayer1.Add(card);
            listMem.RemoveAt(countMem);
            countMem--;
        }
        for (int i = 0; i < 5; i++)
        {
            int card = listMem[countMem];
            handPlayer2.Add(card);
            listMem.RemoveAt(countMem);
            countMem--;
        }
        for (int i = 0; i < 5; i++)
        {
            int card = listMem[countMem];
            handPlayer3.Add(card);
            listMem.RemoveAt(countMem);
            countMem--;
        }
        for (int i = 0; i < 5; i++)
        {
            int card = listMem[countMem];
            handPlayer4.Add(card);
            listMem.RemoveAt(countMem);
            countMem--;
        }
        Debug.Log(string.Join(", ", handPlayer1));
        Debug.Log(string.Join(", ", handPlayer2));
        Debug.Log(string.Join(", ", handPlayer3));
        Debug.Log(string.Join(", ", handPlayer4));
        Debug.Log(string.Join(", ", listMem));
    }

    // Выбор игроком карты мема
    int numberPlayer = 0;
    int cardPlayer1 = 0;
    int cardPlayer2 = 0;
    int cardPlayer3 = 0;
    int cardPlayer4 = 0;
    void DrawCardPlayer1()
    {
        void PlayCard()
        {
            numberPlayer++;
            tableMem.Add(handPlayer1[cardPlayer1]);
            Debug.Log(tableMem [0]);
            handPlayer1.RemoveAt(cardPlayer1);
            handPlayer1.Add(listMem[countMem]);
            listMem.RemoveAt(countMem);
            Debug.Log(string.Join(", ", handPlayer1));
            //Debug.Log(string.Join(", ", listMem));
            countMem--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cardPlayer1 = 0;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardPlayer1 = 1;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cardPlayer1 = 2;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cardPlayer1 = 3;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cardPlayer1 = 4;
            PlayCard();
        }
    }
    void DrawCardPlayer2()
    {
        void PlayCard()
        {
            numberPlayer++;
            tableMem.Add(handPlayer2[cardPlayer2]);
            Debug.Log(tableMem [1]);
            handPlayer2.RemoveAt(cardPlayer2);
            handPlayer2.Add(listMem[countMem]);
            listMem.RemoveAt(countMem);
            Debug.Log(string.Join(", ", handPlayer2));
            countMem--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cardPlayer2 = 0;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardPlayer2 = 1;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cardPlayer2 = 2;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cardPlayer2 = 3;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cardPlayer2 = 4;
            PlayCard();
        }
    }
    void DrawCardPlayer3()
    {
        void PlayCard()
        {
            numberPlayer++;
            tableMem.Add(handPlayer3[cardPlayer3]);
            Debug.Log(tableMem [2]);
            handPlayer3.RemoveAt(cardPlayer3);
            handPlayer3.Add(listMem[countMem]);
            listMem.RemoveAt(countMem);
            Debug.Log(string.Join(", ", handPlayer3));
            countMem--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cardPlayer3 = 0;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardPlayer3 = 1;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cardPlayer3 = 2;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cardPlayer3 = 3;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cardPlayer3 = 4;
            PlayCard();
        }
    }
    void DrawCardPlayer4()
    {
        void PlayCard()
        {
            numberPlayer++;
            tableMem.Add(handPlayer4[cardPlayer4]);
            Debug.Log(tableMem [3]);
            handPlayer4.RemoveAt(cardPlayer4);
            handPlayer4.Add(listMem[countMem]);
            listMem.RemoveAt(countMem);
            Debug.Log(string.Join(", ", handPlayer4));
            Debug.Log(string.Join(", ", listMem));
            countMem--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cardPlayer4 = 0;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardPlayer4 = 1;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cardPlayer4 = 2;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cardPlayer4 = 3;
            PlayCard();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cardPlayer4 = 4;
            PlayCard();
        }
    }

    // Выбор игроками мема и засчитывание очков
    int scorePlayer1;
    int scorePlayer2;
    int scorePlayer3;
    int scorePlayer4;
    void ChooseCardPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scorePlayer2++;
            numberPlayer++;
            Debug.Log("Балл игроку 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            scorePlayer3++;
            numberPlayer++;
            Debug.Log("Балл игроку 3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            scorePlayer4++;
            numberPlayer++;
            Debug.Log("Балл игроку 4");
        }
    }
    void ChooseCardPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scorePlayer1++;
            numberPlayer++;
            Debug.Log("Балл игроку 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            scorePlayer3++;
            numberPlayer++;
            Debug.Log("Балл игроку 3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            scorePlayer4++;
            numberPlayer++;
            Debug.Log("Балл игроку 4");
        }
    }
    void ChooseCardPlayer3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scorePlayer1++;
            numberPlayer++;
            Debug.Log("Балл игроку 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scorePlayer2++;
            numberPlayer++;
            Debug.Log("Балл игроку 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            scorePlayer4++;
            numberPlayer++;
            Debug.Log("Балл игроку 4");
        }
    }
    void ChooseCardPlayer4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scorePlayer1++;
            numberPlayer++;
            Debug.Log("Балл игроку 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scorePlayer2++;
            numberPlayer++;
            Debug.Log("Балл игроку 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            scorePlayer3++;
            numberPlayer++;
            Debug.Log("Балл игроку 3");
        }
    }

    public void Start()
    {
        CreateDeck();
        CreateHandPlayers();
    }

    void Update ()
    {
        switch(55 - numberPlayer) // Игроки выбирают свой мем
        {
            case 55:
            DrawCardPlayer1();
            break;
            
            case 54:
            DrawCardPlayer2();
            break;
            
            case 53:
            DrawCardPlayer3();
            break;
            
            case 52:
            DrawCardPlayer4();
            break;

            default:
            break;
        }

        if (Input.GetKeyDown("down"))
        {
            numberPlayer = 10;
            Debug.Log(string.Join(", ", tableMem));
            tableMem.Clear();
        }

        switch(55 - numberPlayer) //Игроки выбирают чужой мем
        {
            case 45:
            ChooseCardPlayer1();
            break;

            case 44:
            ChooseCardPlayer2();
            break;

            case 43:
            ChooseCardPlayer3();
            break;

            case 42:
            ChooseCardPlayer4();
            break;

            default:
            break;
        }

        if (Input.GetKeyDown("space"))
        {
            numberPlayer = 0;
            List <int> finalScore = new ();
            finalScore.Add(scorePlayer1);
            finalScore.Add(scorePlayer2);
            finalScore.Add(scorePlayer3);
            finalScore.Add(scorePlayer4);
            Debug.Log(string.Join(", ", finalScore));
        }
    }
}
